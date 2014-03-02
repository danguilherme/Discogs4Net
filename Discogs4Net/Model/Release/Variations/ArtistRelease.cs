using Discogs4Net.Data.Pagination;
using Discogs4Net.Model.Enumerator;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Discogs4Net.Model.Release.Variations
{
    /// <summary>
    /// Represents each release coming from a <c>artist/{id}/releases</c> request.
    /// </summary>
    public class ArtistRelease : BasicRelease
    {
        protected new class Keys : BasicRelease.Keys
        {
            public const String Artist = "artist";
            public const String Role = "role";
            public const String Type = "type";
            public const String Year = "year";
            public const String MainRelease = "main_release";
        }

        [JsonProperty(PropertyName = Keys.Artist)]
        public string Artist { get; set; }

        [JsonProperty(PropertyName = Keys.Role)]
        public string Role { get; set; }

        [JsonProperty(PropertyName = Keys.Type)]
        public EntityType Type { get; set; }

        [JsonProperty(PropertyName = Keys.Year)]
        public int Year { get; set; }

        /// <summary>
        /// Only filled when the type is "Master"
        /// </summary>
        [JsonProperty(PropertyName = Keys.MainRelease)]
        public int MainReleaseId { get; set; }

        public override string ToString()
        {
            return Title + " (" + Enum.GetName(typeof(EntityType), Type) + ")";
        }

        /// <summary>
        /// Used to deserialize information from artist's releases.
        /// </summary>
        internal class List : PaginatedList<ArtistRelease>
        {
            protected new class Keys : PaginatedList<ArtistRelease>.Keys
            {
                public new const string ResultsRoot = "releases";
            }

            [JsonProperty(PropertyName = Keys.ResultsRoot)]
            public override List<ArtistRelease> Data { get; set; }
        }
    }
}
