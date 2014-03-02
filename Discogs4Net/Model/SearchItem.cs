using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Discogs4Net.Model
{
    public class SearchItem
    {
        class Keys
        {
            public const String Id = "id";
            public const String Thumb = "thumb";
            public const String Title = "title";
            public const String Uri = "uri";
            public const String ResourceUrl = "resource_url";
            public const String Type = "type";
        }

        [JsonProperty(PropertyName = Keys.Id)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = Keys.Title)]
        public string Title { get; set; }

        [JsonProperty(PropertyName = Keys.Thumb)]
        public string ThumbUrl { get; set; }

        [JsonProperty(PropertyName = Keys.ResourceUrl)]
        public string ResourceUrl { get; set; }

        [JsonProperty(PropertyName = Keys.Type)]
        public string Type { get; set; }

        [JsonProperty(PropertyName = Keys.Uri)]
        public string RelativeUrl { get; set; }

        public override string ToString()
        {
            return this.Id + " - " + this.Title + " (" + this.Type + ")";
        }
    }
}
