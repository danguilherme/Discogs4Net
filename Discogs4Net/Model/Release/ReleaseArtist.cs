using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Discogs4Net.Model.Release
{
    /// <summary>
    /// Represents an artist coming from a Release, that has tracks s/he participated,
    /// its role on the release, etc.
    /// </summary>
    public class ReleaseArtist : Artist.Artist
    {
        protected new class Keys : Artist.Artist.Keys
        {
            public const String Tracks = "tracks";
            public const String Role = "role";
            public const String Anv = "anv";
            public const String Join = "join";
        }

        [JsonProperty(PropertyName = Keys.Tracks)]
        public string Tracks { get; set; }

        [JsonProperty(PropertyName = Keys.Role)]
        public string Role { get; set; }

        /// <summary>
        /// <see cref="http://www.discogs.com/help/database/submission-guidelines-release-artist#Artist_Name_Variation_ANV"/>
        /// In order to link variations of an artists name, but keep the same artist profile,
        /// Discogs uses a system called Artist Name Variation, or ANV.
        /// </summary>
        [JsonProperty(PropertyName = Keys.Anv)]
        public string ArtistNameVariation { get; set; }

        [JsonProperty(PropertyName = Keys.Join)]
        public string Join { get; set; }
    }
}
