using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Discogs4Net.Model.Community;
using Newtonsoft.Json;

namespace Discogs4Net.Model.Release
{
    /// <summary>
    /// The Release resource represents a particular physical or digital object released by one or more <see cref="Artist"/>s.
    /// </summary>
    public class Release : MasterRelease
    {
        protected new class Keys : MasterRelease.Keys
        {
            public const String Status = "status";
            public const String MasterId = "master_id";
            public const String MasterUrl = "master_url";
            public const String Country = "country";
            public const String Released = "released";
            public const String ReleasedFormatted = "released_formatted";
            public const String Notes = "notes";
            public const String EstimatedWeight = "estimated_weight";
            public const String FormatQuantity = "format_quantity";
            public const String Community = "community";
            public const String Labels = "labels";
            public const String Companies = "companies";
            public const String ExtraArtists = "extraartists";
            public const String Formats = "formats";
            public const String Identifiers = "identifiers";
        }

        [JsonProperty(PropertyName = Keys.Status)]
        public string Status { get; set; }

        [JsonProperty(PropertyName = Keys.MasterId)]
        public int MasterId { get; set; }

        [JsonProperty(PropertyName = Keys.MasterUrl)]
        public string MasterUrl { get; set; }

        [JsonProperty(PropertyName = Keys.Country)]
        public string Country { get; set; }

        [JsonProperty(PropertyName = Keys.Released)]
        public string Released { get; set; }

        [JsonProperty(PropertyName = Keys.ReleasedFormatted)]
        public string ReleasedFormatted { get; set; }

        [JsonProperty(PropertyName = Keys.Notes)]
        public string Notes { get; set; }

        [JsonProperty(PropertyName = Keys.EstimatedWeight)]
        public int EstimatedWeight { get; set; }

        [JsonProperty(PropertyName = Keys.FormatQuantity)]
        public int FormatQuantity { get; set; }

        [JsonProperty(PropertyName = Keys.Community)]
        public Community.Community Community { get; set; }

        [JsonProperty(PropertyName = Keys.Labels)]
        public List<ReleaseLabel> Labels { get; set; }

        [JsonProperty(PropertyName = Keys.Companies)]
        public List<ReleaseLabel> Companies { get; set; }

        [JsonProperty(PropertyName = Keys.ExtraArtists)]
        public List<ReleaseArtist> ExtraArtists { get; set; }

        [JsonProperty(PropertyName = Keys.Formats)]
        public List<Format> Formats { get; set; }

        [JsonProperty(PropertyName = Keys.Identifiers)]
        public List<Identifier> Identifiers { get; set; }
    }
}
