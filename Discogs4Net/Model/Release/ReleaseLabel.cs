using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Discogs4Net.Model.Release
{
    /// <summary>
    /// A label/company that comes inside a release
    /// </summary>
    public class ReleaseLabel : Model
    {
        protected new class Keys : Model.Keys
        {
            public const String EntityType = "entity_type";
            public const String EntityTypeName = "entity_type_name";
            public const String CatNo = "catno";
            public const String Name = "name";
        }

        [JsonProperty(PropertyName = Keys.Name)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = Keys.EntityType)]
        public int EntityType { get; set; }

        [JsonProperty(PropertyName = Keys.EntityTypeName)]
        public string EntityTypeName { get; set; }

        [JsonProperty(PropertyName = Keys.CatNo)]
        public string CatNo { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
