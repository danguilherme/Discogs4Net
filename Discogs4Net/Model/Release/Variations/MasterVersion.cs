using Discogs4Net.Data.Pagination;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Discogs4Net.Model.Release.Variations
{
    /// <summary>
    /// Represents each version coming from a <c>master/{id}/versions</c> request.
    /// </summary>
    public class MasterVersion : BasicRelease
    {
        protected new class Keys : BasicRelease.Keys
        {
            public const String Country = "country";
            public const String Released = "released";
            public const String CatNo = "catno";
        }

        [JsonProperty(PropertyName = Keys.Country)]
        public string Country { get; set; }

        /// <summary>
        /// Not always it is a DateTime object
        /// </summary>
        [JsonProperty(PropertyName = Keys.Released)]
        public string Released { get; set; }

        [JsonProperty(PropertyName = Keys.CatNo)]
        public string CatNo { get; set; }

        /// <summary>
        /// Used to deserialize information from master's versions.
        /// </summary>
        internal class List : PaginatedList<MasterVersion>
        {
            protected new class Keys : PaginatedList<MasterVersion>.Keys
            {
                public new const string ResultsRoot = "versions";
            }

            [JsonProperty(PropertyName = Keys.ResultsRoot)]
            public override List<MasterVersion> Data { get; set; }
        }
    }
}
