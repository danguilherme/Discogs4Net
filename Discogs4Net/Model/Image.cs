using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Discogs4Net.Model
{
    public class Image
    {
        class Keys
        {
            public const String Uri = "uri";
            public const String Uri150 = "uri150";
            public const String Height = "height";
            public const String Width = "width";
            public const String Type = "type";
        }

        public Image(string thumb)
        {
            this.ThumbUrl = thumb;
        }

        public Image()
        {

        }

        [JsonProperty(PropertyName = Keys.Uri)]
        public string Url { get; set; }

        [JsonProperty(PropertyName = Keys.Height)]
        public int Height { get; set; }

        [JsonProperty(PropertyName = Keys.Width)]
        public int Width { get; set; }

        [JsonProperty(PropertyName = Keys.Type)]
        public string Type { get; set; }

        [JsonProperty(PropertyName = Keys.Uri150)]
        public string ThumbUrl { get; set; }

        public override String ToString()
        {
            return this.Type + " image (" + this.Url + ", " + this.Width + "x"
                    + this.Height + ")";
        }
    }
}
