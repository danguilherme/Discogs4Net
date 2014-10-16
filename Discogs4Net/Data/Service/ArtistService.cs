using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Discogs4Net.Model.Artist;
using Discogs4Net.Data.Pagination;
using Discogs4Net.Model;
using System.Text.RegularExpressions;
using Discogs4Net.Connection;

namespace Discogs4Net.Data.Service
{
    internal class ArtistService : BaseService<Artist>
    {
        protected internal new class Url : BaseService<Artist>.Url
        {
            public class Artist
            {
                public const string Retrieve = Base + "artists/{0}";
                public const string Search = Base + "database/search?type=artist&q={0}&per_page={1}&page={2}";
            }
        }

        public ArtistService(Request requestConfig) : base(requestConfig) { }

        public override PaginatedList<Artist> Search(string query, int perPage = 50, int pageIndex = 1)
        {
            // Evanescence: 163505
            string searchUrl = String.Format(Url.Artist.Search, query, perPage, pageIndex);

            SearchResult artistsSearchResult = Request.Get<SearchResult>(searchUrl);

            PaginatedList<Artist> myArtists =
                new PaginatedList<Artist>(artistsSearchResult.Pagination, this.LoadBySearch(artistsSearchResult.Data));

            return myArtists;
        }

        public override Artist GetById(long id)
        {
            var artist = Request.Get<Artist>(String.Format(Url.Artist.Retrieve, id));
            // Evanescence: 163505
            return FixArtistData(artist);
        }

        #region Load methods

        private Artist FixArtistData(Artist artist)
        {
            FixName(artist);
            FixProfile(artist);
            return artist;
        }

        private Artist FixName(Artist artist)
        {
            if (artist == null) return null;

            var namePrefixPattern = ".+(, (The))";
            var duplicatedNameSuffixPattern = @".+( \([0-9]+\))$";

            var prefixMatch = Regex.Match(artist.Name, namePrefixPattern, RegexOptions.IgnoreCase);
            // prefixMatch.Groups[0].Value = "ArtistName, The"
            // prefixMatch.Groups[1].Value = ", The"
            // prefixMatch.Groups[2].Value = "The"

            if (prefixMatch.Success)
                artist.Name = String.Format("{0} {1}", prefixMatch.Groups[2].Value,
                    artist.Name.Replace(prefixMatch.Groups[1].Value, String.Empty));

            var duplicateMatch = Regex.Match(artist.Name, duplicatedNameSuffixPattern, RegexOptions.IgnoreCase);
            // duplicateMatch.Groups[1].Value = " (2)"

            if (duplicateMatch.Success)
                artist.Name = artist.Name.Replace(duplicateMatch.Groups[1].Value, String.Empty);

            return artist;
        }

        /// <summary>
        /// Fix artist's profile text formatting, as set in
        /// http://www.discogs.com/help/account/text-formatting
        /// </summary>
        /// <param name="artist"></param>
        /// <returns></returns>
        private Artist FixProfile(Artist artist)
        {
            if (String.IsNullOrEmpty(artist.Profile)) return artist;

            var urlLinkPattern = @"\[url=(.+)\](.+)\[/url\]";
            var aLinkPattern = @"\[a=([A-Za-z0-9\-\s\(\)]+)\]";
            var idLinkPattern = @"\[a(\d+)\]";

            // find all at once for one not mess with the other on string replace
            var urlMatches = Regex.Matches(artist.Profile, urlLinkPattern);
            var nameMatches = Regex.Matches(artist.Profile, aLinkPattern);
            var idMatches = Regex.Matches(artist.Profile, idLinkPattern);

            foreach (Match item in urlMatches)
            {
                var lastSlash = item.Groups[1].Value.LastIndexOf("/");
                String artistName = item.Groups[1].Value
                    .Replace("+", " ")
                    .Substring(lastSlash + 1, item.Groups[1].Value.Length - lastSlash - 1);
                var referencedArtist = Search(artistName, 1, 1).Data.FirstOrDefault();

                if (referencedArtist != null)
                    artist.Profile = artist.Profile.Replace(item.Groups[0].Value, String.Format("[a={0}]",
                        referencedArtist.Id));
                else
                    artist.Profile = artist.Profile.Replace(item.Groups[0].Value, String.Format("[a={0}]",
                        artistName));
            }

            foreach (Match item in nameMatches)
            {
                var referencedArtist = Search(item.Groups[1].Value, 1, 1).Data.FirstOrDefault();

                if (referencedArtist != null)
                    artist.Profile = artist.Profile.Replace(item.Groups[0].Value, String.Format("[a={0}]",
                        referencedArtist.Id));
                else
                    artist.Profile = artist.Profile.Replace(item.Groups[0].Value, String.Format("[a={0}]",
                        item.Groups[1].Value));
            }

            foreach (Match item in idMatches)
                artist.Profile = artist.Profile.Replace(item.Groups[0].Value, String.Format("[a={0}]",
                    item.Groups[1].Value));

            return artist;
        }

        protected internal Artist LoadBySearch(SearchItem artist)
        {
            Artist target = new Artist(artist.Id, artist.Title, artist.ResourceUrl);

            target.ResourceUrl = artist.ResourceUrl;
            target.Images = new List<Image>(){
                new Image(artist.ThumbUrl)
            };

            return FixArtistData(target);
        }

        protected internal List<Artist> LoadBySearch(List<SearchItem> artists)
        {
            List<Artist> targetArtists = new List<Artist>();

            for (int i = 0; i < artists.Count; i++)
            {
                targetArtists.Add(this.LoadBySearch(artists[i]));
            }

            return targetArtists;
        }
        #endregion
    }
}