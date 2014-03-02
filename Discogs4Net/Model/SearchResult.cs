using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Discogs4Net.Data.Pagination;

namespace Discogs4Net.Model
{
    /// <summary>
    /// Class to be used in more precise search
    /// (e.g. when doing <c>/database/search</c> with 'type' parameter set)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SearchResult<T> : PaginatedList<T>
    {
        protected new class Keys : PaginatedList<SearchItem>.Keys
        {
            public new const string ResultsRoot = "results";
        }

        [JsonProperty(PropertyName = Keys.ResultsRoot)]
        public override List<T> Data { get; set; }
    }

    /// <summary>
    /// Used in more generic search, using the generic <see cref="SearchItem"/> class
    /// to deserialize the results.
    /// </summary>
    public class SearchResult : SearchResult<SearchItem> { }
}
