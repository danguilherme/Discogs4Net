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

namespace Discogs4Net.Data
{
    internal class Request
    {
        protected internal static String AppCode;

        public Request()
        {
            if (String.IsNullOrEmpty(AppCode))
                throw new ArgumentException("An application identifier must be provided before instantiating a request object");
        }

        public T Get<T>(string url)
        {
            JsonSerializerSettings jsset = new JsonSerializerSettings();
            jsset.ContractResolver = new SnakeCasePropertyNamesContractResolver();
            return JsonConvert.DeserializeObject<T>(this.Get(url), jsset);
        }

        /// <summary>
        /// Get the pure content from the request string
        /// </summary>
        /// <returns></returns>
        public string Get(string url)
        {
            // Code based on http://forum.guiadohacker.com.br/showthread.php?t=9358
            // By .IndependentResearch.

            String responseString = String.Empty;
            try
            {
                // Creates the URL request
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 10000;
                request.Accept = "application/json";
                request.UserAgent = AppCode;
                request.Headers[HttpRequestHeader.AcceptEncoding] = "gzip; deflate";

                responseString = ExtractResponse(request.GetResponse());
            }
            catch (Exception)
            {
                throw;
            }

            return responseString;
        }

        public string Post(string url, object data)
        {
            return Post(url, JsonConvert.SerializeObject(data));
        }

        public string Post(string url, string data)
        {
            string response = null;

            using (WebClient webClient = new WebClient())
            {
                try
                {
                    response = webClient.UploadString(new Uri(url), "POST", data);
                }
                catch (WebException)
                {

                    throw;
                }
            }

            return response;
        }

        public string Put(string url, object data)
        {
            return Put(url, JsonConvert.SerializeObject(data));
        }

        public string Put(string url, string data)
        {
            string response = null;

            using (WebClient webClient = new WebClient())
            {
                try
                {
                    response = webClient.UploadString(new Uri(url), "PUT", data);
                }
                catch (WebException)
                {

                    throw;
                }
            }

            return response;
        }

        private string ExtractResponse(WebResponse response)
        {
            string stringResponse = null;
            if (!String.IsNullOrEmpty(response.Headers[HttpResponseHeader.ContentEncoding]))
            {
                using (var outStream = new MemoryStream())
                    if (response.Headers[HttpResponseHeader.ContentEncoding].ToLower().Contains("gzip"))
                        using (var zipStream = new GZipStream(response.GetResponseStream(),
                            CompressionMode.Decompress))
                        {
                            zipStream.CopyTo(outStream);
                            outStream.Seek(0, SeekOrigin.Begin);
                            using (var reader = new StreamReader(outStream, Encoding.UTF8))
                            {
                                stringResponse = reader.ReadToEnd();
                            }
                        }
                    else if (response.Headers[HttpResponseHeader.ContentEncoding].ToLower().Contains("deflate"))
                        using (var zipStream = new DeflateStream(response.GetResponseStream(),
                            CompressionMode.Decompress))
                        {
                            zipStream.CopyTo(outStream);
                            outStream.Seek(0, SeekOrigin.Begin);
                            using (var reader = new StreamReader(outStream, Encoding.UTF8))
                            {
                                stringResponse = reader.ReadToEnd();
                            }
                        }
            }
            else
            {
                using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    stringResponse = reader.ReadToEnd();
                }
            }
            return stringResponse;
        }
    }
}
