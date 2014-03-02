using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Discogs4Net.Model.Enumerator;
using System.Text.RegularExpressions;

namespace Discogs4Net.Model
{
    public class ExternalUrl : IComparable<ExternalUrl>
    {
        [JsonIgnore]
        public string ArtistName { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ExternalUrlTypes Type;
        public string Url { get; set; }

        public ExternalUrl()
        {
        }

        public ExternalUrl(string url, ExternalUrlTypes type, string artistName)
        {
            this.Type = type;
            this.Url = url;
            this.ArtistName = artistName;
        }

        /// <summary>
        /// Constructor that decodes the url and discover its
        /// <see cref="ExternalUrlTypes" /> respective type.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="artistName">Name of the artist.</param>
        public ExternalUrl(string url, string artistName)
        {
            ExternalUrl externalUrl = ExternalUrl.Decode(url, artistName);

            this.ArtistName = artistName;
            this.Type = externalUrl.Type;
            this.Url = url;
        }

        public static ExternalUrl Decode(string url, string artistName)
        {
            ExternalUrl externalUrl = new ExternalUrl();

            string noSpacesArtistName = artistName.Replace(" ", "").ToLower();
            string dashDelimitedArtistName = artistName.Replace(" ", "-").ToLower();

            if (artistName != null
                    && (Regex.Match(url, noSpacesArtistName + @"(\.com|\.net|\.mus)").Success
                    || Regex.Match(url, dashDelimitedArtistName + @"(\.com|\.net|\.mus)").Success))
            {
                // is an official website
                externalUrl.Type = ExternalUrlTypes.ArtistWebsite;
            }
            else if (url.Contains("youtube.com"))
            {
                // is a Youtube url
                externalUrl.Type = ExternalUrlTypes.YouTube;
            }
            else if (url.Contains("wikipedia.org"))
            {
                // is a Wikipedia url
                externalUrl.Type = ExternalUrlTypes.Wikipedia;
            }
            else if (url.Contains("facebook.com"))
            {
                // is a Facebook url
                externalUrl.Type = ExternalUrlTypes.Facebook;
            }
            else if (url.Contains("twitter.com"))
            {
                // is a Twitter url;
                externalUrl.Type = ExternalUrlTypes.Twitter;
            }
            else if (url.Contains("myspace.com"))
            {
                // is a My Space url;
                externalUrl.Type = ExternalUrlTypes.MySpace;
            }
            else if (url.Contains("tumblr.com"))
            {
                // is a Tumblr url;
                externalUrl.Type = ExternalUrlTypes.Tumblr;
            }
            else if (url.Contains("plus.google.com"))
            {
                // is a Google+ url;
                externalUrl.Type = ExternalUrlTypes.GooglePlus;
            }
            else if (url.Contains("vimeo.com"))
            {
                // is a Vimeo url;
                externalUrl.Type = ExternalUrlTypes.Vimeo;
            }
            else
            {
                // is only a url...
                externalUrl.Type = ExternalUrlTypes.OtherWebsite;
            }
            return externalUrl;
        }

        public override String ToString()
        {
            if (this.Url != null)
                return this.Url +
                    " (" + this.Type.ToString() + ")";
            return "";
        }

        public int CompareTo(ExternalUrl another)
        {
            return this.Type.CompareTo(another.Type);
        }
    }
}
