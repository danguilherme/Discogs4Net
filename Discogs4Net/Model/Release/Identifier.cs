using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Discogs4Net.Model.Release
{
    public class Identifier
    {
        protected class Keys
        {
            public const String Type = "type";
            public const String Description = "description";
            public const String Value = "value";
        }

        [JsonProperty(PropertyName = Keys.Type)]
        public string Type { get; set; }

        [JsonProperty(PropertyName = Keys.Description)]
        public string Description { get; set; }

        [JsonProperty(PropertyName = Keys.Value)]
        public string Value { get; set; }

        public override string ToString()
        {
            return Type + " - " + Value;
        }
    }
}
