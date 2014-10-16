using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using Discogs4Net.Data;
using Discogs4Net.Data.ContractResolver;
using System.IO.Compression;
using System.Diagnostics;
using System.Reflection;

namespace Discogs4Net.Connection
{
    internal class OAuthConfiguration
    {
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string AccessToken { get; set; }
        public string TokenSecret { get; set; }
    }
}
