using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Discogs4Net.Model.Release
{
    public class Format
    {
        protected class Keys
        {
            public const String Descriptions = "descriptions";
            public const String Name = "name";
            public const String Qty = "qty";
        }

        [JsonProperty(PropertyName = Keys.Descriptions)]
        public List<string> Descriptions { get; set; }

        [JsonProperty(PropertyName = Keys.Name)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = Keys.Qty)]
        public string Quantity { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
