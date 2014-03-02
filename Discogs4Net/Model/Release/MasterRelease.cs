using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Discogs4Net.Model.Release
{
    /// <summary>
    /// Contains similar content from Release and Master
    /// </summary>
    public abstract class MasterRelease : Model
    {
        protected new class Keys : Model.Keys
        {
            public const String Title = "title";
            public const String Year = "year";
            public const String Styles = "styles";
            public const String Genres = "genres";
            public const String Videos = "videos";
            public const String Artists = "artists";
            public const String Images = "images";
            public const String TrackList = "tracklist";
        }

        [JsonProperty(PropertyName = Keys.Title)]
        public string Title { get; set; }

        [JsonProperty(PropertyName = Keys.Year)]
        public int Year { get; set; }

        [JsonProperty(PropertyName = Keys.Styles)]
        public List<string> Styles { get; set; }

        [JsonProperty(PropertyName = Keys.Genres)]
        public List<string> Genres { get; set; }

        [JsonProperty(PropertyName = Keys.Videos)]
        public List<Video> Videos { get; set; }

        [JsonProperty(PropertyName = Keys.Artists)]
        public List<ReleaseArtist> Artists { get; set; }

        [JsonProperty(PropertyName = Keys.Images)]
        public List<Image> Images { get; set; }

        [JsonProperty(PropertyName = Keys.TrackList)]
        public List<Track> TrackList { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
