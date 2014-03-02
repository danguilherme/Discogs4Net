using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discogs4Net.Model
{
    public abstract class Model
    {
        protected class Keys
        {
            public const String Id = "id";
            public const String Uri = "uri";
            public const String ResourceUrl = "resource_url";
            public const String DataQuality = "data_quality";
        }

        [JsonProperty(PropertyName = Keys.Id)]
        public long Id { get; set; }

        [JsonProperty(PropertyName = Keys.DataQuality)]
        public String DataQuality { get; set; }

        [JsonProperty(PropertyName = Keys.Uri)]
        public string DiscogsUrl { get; set; }

        [JsonProperty(PropertyName = Keys.ResourceUrl)]
        public string ResourceUrl { get; set; }

        public override string ToString()
        {
            return ResourceUrl;
        }
    }
}
