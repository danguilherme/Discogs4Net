using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Discogs4Net.Model.Release
{
    public class Video
    {
        protected class Keys
        {
            public const String Uri = "uri";
            public const String Duration = "duration";
            public const String Embed = "embed";
            public const String Description = "description";
            public const String Title = "title";
        }

        [JsonProperty(PropertyName = Keys.Uri)]
        public string Uri { get; set; }

        [JsonProperty(PropertyName = Keys.Duration)]
        public int Duration { get; set; }

        [JsonProperty(PropertyName = Keys.Embed)]
        public bool Embed { get; set; }

        [JsonProperty(PropertyName = Keys.Description)]
        public string Description { get; set; }

        [JsonProperty(PropertyName = Keys.Title)]
        public string Title { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
