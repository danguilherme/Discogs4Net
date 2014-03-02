using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Discogs4Net.Model.Community
{
    public class Rating
    {
        protected class Keys
        {
            public const String Count = "count";
            public const String Average = "average";
        }

        [JsonProperty(PropertyName = Keys.Count)]
        public int Count { get; set; }

        [JsonProperty(PropertyName = Keys.Average)]
        public double Average { get; set; }

        public override string ToString()
        {
            return Average + " - " + Count + " votes";
        }
    }
}
