using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Discogs4Net.Data.Pagination
{
    public class Paging
    {
        public class Keys
        {
            public const String Root = "pagination";

            public const String PerPage = "per_page";
            public const String Items = "items";
            public const String Page = "page";
            public const String Pages = "pages";
            public const String PagesAddresses = "urls";
        }

        /// <summary>
        /// The actual page of the listed items
        /// </summary>
        [JsonProperty(PropertyName = Keys.Page)]
        public int ActualPage { get; set; }

        /// <summary>
        /// The number of items that are returned by page
        /// </summary>
        [JsonProperty(PropertyName = Keys.PerPage)]
        public int ItemsPerPage { get; set; }

        /// <summary>
        /// Total number of items matched
        /// </summary>
        [JsonProperty(PropertyName = Keys.Items)]
        public int ItemsCount { get; set; }

        /// <summary>
        /// Total number of pages
        /// </summary>
        [JsonProperty(PropertyName = Keys.Pages)]
        public int PagesCount { get; set; }

        [JsonProperty(PropertyName = Keys.PagesAddresses, NullValueHandling = NullValueHandling.Ignore)]
        public PageNavigation PageNavigation { get; set; }

        public bool isLast()
        {
            return this.ActualPage == this.PagesCount;
        }

        public bool isFirst()
        {
            return this.ActualPage == 1;
        }

        public override String ToString()
        {
            return "Page " + this.ActualPage + " of " + this.PagesCount;
        }
    }
}
