using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Discogs4Net.Model.Release
{
    /// <summary>
    /// The Label resource represents a label, company, recording studio, location, or other entity involved with <see cref="Artist"/> and Releases.
    /// Labels were recently expanded in scope to include things that aren’t labels – the name is an artifact of this history.
    /// </summary>
    public class Label : Model
    {
        protected new class Keys : Model.Keys
        {
            public const String Name = "name";
            public const String Profile = "profile";
            public const String ReleasesUrl = "releases_url";
            public const String ContactInfo = "contact_info";
            public const String ParentLabel = "parent_label";
            public const String Sublabels = "sublabels";
            public const String Urls = "urls";
            public const String Images = "images";
        }

        [JsonProperty(PropertyName = Keys.Name)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = Keys.Profile)]
        public string Profile { get; set; }

        [JsonProperty(PropertyName = Keys.ReleasesUrl)]
        public string ReleasesUrl { get; set; }

        [JsonProperty(PropertyName = Keys.ContactInfo)]
        public string ContactInfo { get; set; }

        [JsonProperty(PropertyName = Keys.ParentLabel)]
        public Label ParentLabel { get; set; }

        [JsonProperty(PropertyName = Keys.Sublabels)]
        public List<Label> Sublabels { get; set; }

        [JsonProperty(PropertyName = Keys.Urls)]
        public List<string> Urls { get; set; }

        [JsonProperty(PropertyName = Keys.Images)]
        public List<Image> Images { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
