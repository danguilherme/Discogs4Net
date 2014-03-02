using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Discogs4Net.Model.Release.Variations
{
    /// <summary>
    /// Represents a basic release coming from a list.
    /// It would be from <c>master/{id}/versions</c> (<see cref="MasterVersion"/>)
    /// or <c>artists/{id}/releases</c> (<see cref="ArtistRelease"/>) requests.
    /// </summary>
    public abstract class BasicRelease : Model
    {
        protected new class Keys : Model.Keys
        {
            public const String Title = "title";
            public const String Status = "status";
            public const String Thumb = "thumb";
            public const String Format = "format";
            public const String Label = "label";
        }

        // From any request:

        [JsonProperty(PropertyName = Keys.Title)]
        public string Title { get; set; }

        [JsonProperty(PropertyName = Keys.Status)]
        public string Status { get; set; }

        [JsonProperty(PropertyName = Keys.Thumb)]
        public string Thumb { get; set; }

        /// <summary>
        /// Comma-separated list of formats.
        /// </summary>
        [JsonProperty(PropertyName = Keys.Format)]
        public string Format { get; set; }

        /// <summary>
        /// Comma-separated list of labels.
        /// </summary>
        [JsonProperty(PropertyName = Keys.Label)]
        public string Label { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
