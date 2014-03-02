using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Discogs4Net.Model.Community
{
    public class User : Model
    {
        protected new class Keys : Model.Keys
        {
            public const String Profile = "profile";
            public const String WantlistUrl = "wantlist_url";
            public const String Rank = "rank";
            public const String PendingSubmissionsCount = "num_pending";
            public const String ForSaleCount = "ForSaleCount";
            public const String HomePage = "home_page";
            public const String Location = "location";
            public const String CollectionFoldersUrl = "collection_folders_url";
            public const String Username = "username";
            public const String CollectionFieldsUrl = "collection_fields_url";
            public const String ReleasesContributedCount = "releases_contributed";
            public const String Registered = "registered";
            public const String RatingAvg = "rating_avg";
            public const String CollectionItemsCount = "num_collection";
            public const String ReleasesRatedCount = "releases_rated";
            public const String ListsCount = "lists";
            public const String Name = "name";
            public const String WantlistItemsCount = "num_wantlist";
            public const String InventoryUrl = "inventory_url";
        }

        [JsonProperty(PropertyName = Keys.Profile)]
        public string Profile { get; set; }

        [JsonProperty(PropertyName = Keys.Rank)]
        public double Rank { get; set; }

        [JsonProperty(PropertyName = Keys.PendingSubmissionsCount)]
        public int PendingSubmissions { get; set; }

        [JsonProperty(PropertyName = Keys.ForSaleCount)]
        public int ForSale { get; set; }

        [JsonProperty(PropertyName = Keys.HomePage)]
        public string HomePageUrl { get; set; }

        [JsonProperty(PropertyName = Keys.Location)]
        public string Location { get; set; }

        [JsonProperty(PropertyName = Keys.Username)]
        public string Username { get; set; }

        [JsonProperty(PropertyName = Keys.CollectionFieldsUrl)]
        public string CollectionFieldsUrl { get; set; }

        [JsonProperty(PropertyName = Keys.ReleasesContributedCount)]
        public int ReleasesContributed { get; set; }

        [JsonProperty(PropertyName = Keys.Registered)]
        public DateTime Registered { get; set; }

        [JsonProperty(PropertyName = Keys.RatingAvg)]
        public double RatingAverage { get; set; }

        [JsonProperty(PropertyName = Keys.CollectionItemsCount)]
        public int CollectionItems { get; set; }

        [JsonProperty(PropertyName = Keys.ReleasesRatedCount)]
        public int ReleasesRated { get; set; }

        [JsonProperty(PropertyName = Keys.ListsCount)]
        public int Lists { get; set; }

        [JsonProperty(PropertyName = Keys.Name)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = Keys.WantlistItemsCount)]
        public int Wantlist { get; set; }

        [JsonProperty(PropertyName = Keys.InventoryUrl)]
        public string InventoryUrl { get; set; }

        [JsonProperty(PropertyName = Keys.WantlistUrl)]
        public string WantlistUrl { get; set; }

        [JsonProperty(PropertyName = Keys.CollectionFoldersUrl)]
        public string CollectionFoldersUrl { get; set; }

        public override string ToString()
        {
            return Username +
                (String.IsNullOrEmpty(Name) ? "" : " (" + Name + ")");
        }
    }
}
