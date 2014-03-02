using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using Discogs4Net.Data;
using Discogs4Net.Data.ContractResolver;

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
            // Code from http://forum.guiadohacker.com.br/showthread.php?t=9358
            // By .IndependentResearch.

            HttpWebResponse httpResponse = null;
            StreamReader reader = null;

            StringBuilder responseString = new StringBuilder();
            try
            {
                // Creates the URL request
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 50000;
                request.Proxy = new WebProxy();
                request.Accept = "application/json";
                request.UserAgent = "User-Agent";

                // Receive data.
                httpResponse = (HttpWebResponse)(request.GetResponse());
                Stream responseStream = httpResponse.GetResponseStream();

                System.Text.Encoding encoding = System.Text.Encoding.UTF8;

                reader = new StreamReader(responseStream, encoding);

                Char[] buffer = new Char[256];
                int count = reader.Read(buffer, 0, buffer.Length);

                // Populate what was received from response
                while (count > 0)
                {
                    responseString.Append(new String(buffer, 0, count));
                    count = reader.Read(buffer, 0, buffer.Length);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                // Close all dependencies
                if (httpResponse != null)
                    httpResponse.Close();
                if (reader != null)
                    reader.Close();
            }

            return responseString.ToString();
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
    }
}
