using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Discogs4Net.Data.Pagination;

namespace Discogs4Net.Model
{
    public class SearchResult
    {
        class Keys
        {
            public const string PagingRoot = Paging.Keys.Root;
            public const string ResultsRoot = "results";
        }

        [JsonProperty(PropertyName = Keys.PagingRoot)]
        public Paging Pagination { get; set; }

        [JsonProperty(PropertyName = Keys.ResultsRoot)]
        public List<SearchItem> Data { get; set; }
    }
}
