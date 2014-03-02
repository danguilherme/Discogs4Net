using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Discogs4Net.Model.Release
{
    public class Track
    {
        protected class Keys
        {
            public const String Title = "title";
            public const String Position = "position";
            public const String Duration = "duration";
        }

        [JsonProperty(PropertyName = Keys.Title)]
        public String Title { get; set; }

        [JsonProperty(PropertyName = Keys.Duration)]
        public String Duration { get; set; }

        [JsonProperty(PropertyName = Keys.Position)]
        public String Position { get; set; }

        public Track(String title, String position, String duration)
        {
            this.Title = title;
            this.Position = position;
            this.Duration = duration;
        }

        public override String ToString()
        {
            return this.Position + ". " + this.Title + " (" + this.Duration + ")";
        }
    }
}
