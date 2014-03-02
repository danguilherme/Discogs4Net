using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Discogs4Net.Model.Enumerator;

namespace Discogs4Net.Model.Artist
{
    public class Artist : Model, IComparable<Artist>
    {
        protected new class Keys : Model.Keys
        {
            public const String Active = "active";
            public const String Profile = "profile";
            public const String Images = "images";
            public const String Name = "name";
            public const String RealName = "realname";
            public const String NameVariations = "namevariations";
            public const String ReleasesUrl = "releases_url";
            public const String Urls = "urls";
            public const String Groups = "groups";
            public const String Members = "members";
        }

        [JsonProperty(PropertyName = Keys.Active)]
        public bool IsActive { get; set; }

        [JsonProperty(PropertyName = Keys.Name)]
        public String Name { get; set; }

        [JsonProperty(PropertyName = Keys.RealName)]
        public String RealName { get; set; }

        [JsonProperty(PropertyName = Keys.NameVariations)]
        public List<String> NameVariations = new List<String>();

        [JsonProperty(PropertyName = Keys.Profile)]
        public string Profile { get; set; }

        [JsonProperty(PropertyName = Keys.ReleasesUrl)]
        public string ReleasesUrl { get; set; }

        [JsonProperty(PropertyName = Keys.Urls)]
        private List<String> externalUrls = new List<String>();

        public List<ExternalUrl> ExternalUrls
        {
            get { return this.GetExternalUrls(); }
            set { externalUrls = this.SetExternalUrls(value); }
        }

        [JsonProperty(PropertyName = Keys.Images)]
        public List<Image> Images = new List<Image>();

        [JsonProperty(PropertyName = Keys.Groups)]
        public List<Artist> Groups = new List<Artist>();

        [JsonProperty(PropertyName = Keys.Members)]
        public List<Artist> Members = new List<Artist>();

        public Artist(int id, String name, string discogsUrl)
        {
            this.Id = id;
            this.Name = name;
            this.DiscogsUrl = discogsUrl;
        }

        /// <summary>
        /// Constructor to create a band member
        /// </summary>
        /// <param name="id">The id of the artist</param>
        /// <param name="isActive">True if the artist is in the band, false otherwhise</param>
        /// <param name="name">The name of the artist</param>
        /// <param name="profileUrl">The discogs API url to get artist's individual information</param>
        public Artist(int id, bool isActive, String name, string profileUrl)
        {
            this.Id = id;
            this.IsActive = isActive;
            this.Name = name;
            this.ResourceUrl = profileUrl;
        }

        public Artist()
        {
        }

        private List<ExternalUrl> GetExternalUrls()
        {
            List<ExternalUrl> externalUrlsList = new List<ExternalUrl>();
            foreach (string item in this.externalUrls)
            {
                ExternalUrl url = new ExternalUrl(item, this.Name);
                externalUrlsList.Add(url);
            }
            return externalUrlsList;
        }

        private List<string> SetExternalUrls(List<ExternalUrl> externalUrls)
        {
            List<string> externalUrlsList = new List<string>();
            foreach (ExternalUrl item in externalUrls)
            {
                externalUrlsList.Add(item.Url);
            }
            return externalUrlsList;
        }

        public int CompareTo(Artist another)
        {
            if (this.IsActive == another.IsActive)
            {
                return 0;
            }
            else if (this.IsActive && !another.IsActive)
            {
                return (-1);
            }
            else
            {
                return 1;
            }
        }

        public override String ToString()
        {
            return this.Name;
        }
    }
}
