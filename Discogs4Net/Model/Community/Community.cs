using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Discogs4Net.Model.Community
{
    public class Community
    {
        protected class Keys
        {
            public const String HaveCount = "have";
            public const String WantCount = "want";
            public const String Rating = "rating";
            public const String Submitter = "submitter";
            public const String Contributors = "contributors";
        }

        [JsonProperty(PropertyName = Keys.HaveCount)]
        public int Have { get; set; }

        [JsonProperty(PropertyName = Keys.WantCount)]
        public int Want { get; set; }
        
        [JsonProperty(PropertyName = Keys.Rating)]
        public Rating Rating { get; set; }
        
        [JsonProperty(PropertyName = Keys.Submitter)]
        public User Submitter { get; set; }

        [JsonProperty(PropertyName = Keys.Contributors)]
        public List<User> Contributors { get; set; }

        public override string ToString()
        {
            return Have + " have; " + Want + " want.";
        }
    }
}
