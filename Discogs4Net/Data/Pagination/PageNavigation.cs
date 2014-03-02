using Newtonsoft.Json;
using System;

namespace Discogs4Net.Data.Pagination
{
    public class PageNavigation
    {
        public class Keys
        {
            public const String PreviousPage = "prev";
            public const String NextPage = "next";
            public const String LastPage = "last";
            public const String FirstPage = "first";
        }

        [JsonProperty(PropertyName = Keys.PreviousPage)]
        public Uri PreviousPageUrl { get; set; }

        [JsonProperty(PropertyName = Keys.NextPage)]
        public Uri NextPageUrl { get; set; }

        [JsonProperty(PropertyName = Keys.LastPage)]
        public Uri LastPageUrl { get; set; }

        [JsonProperty(PropertyName = Keys.FirstPage)]
        public Uri FirstPageUrl { get; set; }
    }
}
