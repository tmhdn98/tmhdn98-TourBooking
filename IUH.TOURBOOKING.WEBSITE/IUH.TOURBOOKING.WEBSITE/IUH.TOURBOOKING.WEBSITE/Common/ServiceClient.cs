using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IUH.TOURBOOKING.WEBSITE.Common
{
    public class ServiceClient
    {
        private static readonly HttpClient _Client = new HttpClient();
        /// <summary>
        /// Makes an async HTTP Request
        /// </summary>
        /// <param name="pMethod">Those methods you know: GET, POST, HEAD, etc...</param>
        /// <param name="pUrl">Very predictable...</param>
        /// <param name="pJsonContent">String data to POST on the server</param>
        /// <param name="pHeaders">If you use some kind of Authorization you should use this</param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> Request(HttpMethod pMethod, string pUrl, string pJsonContent, Dictionary<string, string> pHeaders)
        {
            var httpRequestMessage = new HttpRequestMessage();

            foreach (var head in pHeaders)
            {
                httpRequestMessage.Headers.Add(head.Key, head.Value);
            }
            switch (pMethod.Method)
            {
                case "POST":
                    httpRequestMessage.Method = pMethod;
                    httpRequestMessage.RequestUri = new Uri(pUrl);
                    HttpContent httpContent = new StringContent(pJsonContent, Encoding.UTF8, "application/json");
                    httpRequestMessage.Content = httpContent;
                    break;
                case "GET":
                    var response = string.Empty;
                    var u = new Uri(pUrl);
                    using (var client = new HttpClient())
                    {
                        HttpResponseMessage result = await client.GetAsync(u);
                        if (result.IsSuccessStatusCode)
                        {
                            return result;
                        }
                    }
                    break;
            }
            return await _Client.SendAsync(httpRequestMessage);
        }
    }
}
