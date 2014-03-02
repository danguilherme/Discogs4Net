using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Discogs4Net.Model.Release
{
    /// <summary>
    /// The Master resource represents a set of similar Releases. Masters (also known as “master releases”)
    /// have a “main release” which is often the chronologically earliest
    /// </summary>
    public class Master : MasterRelease
    {
        protected new class Keys : MasterRelease.Keys
        {
            public const String VersionsUrl = "versions_url";
            public const String MainRelease = "main_release";
            public const String MainReleaseUrl = "main_release_url";
        }

        [JsonProperty(PropertyName = Keys.VersionsUrl)]
        public string VersionsUrl { get; set; }

        [JsonProperty(PropertyName = Keys.MainRelease)]
        public int MainReleaseId { get; set; }

        [JsonProperty(PropertyName = Keys.MainReleaseUrl)]
        public string MainReleaseUrl { get; set; }
    }
}
