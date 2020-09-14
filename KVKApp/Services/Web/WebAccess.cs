using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KVKApp.Services.Web
{
    public static class WebAccess
    {
        public static async Task<WebResponse> Get(string url)
        {
            try
            {
                Debug.WriteLine("WebClient call GET on url: " + url);

                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (httpClient)
                {
                    var response = await httpClient.GetAsync(url);
                    Debug.WriteLine("WebClient GET Response code: " + response.StatusCode + " on url " + url);
                    var stream = await response.Content.ReadAsStringAsync();
                    return new WebResponse
                    {
                        Data = stream,
                        StatusCode = response.StatusCode
                    };
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        public static async Task<WebResponse> Post(string url, HttpContent data)
        {
            try
            {
                Debug.WriteLine("WebClient call POST on url: " + url);

                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (httpClient)
                {
                    var response = await httpClient.PostAsync(url, data);
                    Debug.WriteLine("WebClient POST Response code: " + response.StatusCode + " on url " + url);

                    var stream = await response.Content.ReadAsStringAsync();
                    return new WebResponse
                    {
                        Data = stream,
                        StatusCode = response.StatusCode
                    };
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        public static async Task<WebResponse> Put(string url, HttpContent data)
        {
            try
            {
                Debug.WriteLine("WebClient call PUT on url: " + url);

                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (httpClient)
                {
                    var response = await httpClient.PutAsync(url, data);
                    Debug.WriteLine("WebClient PUT Response code: " + response.StatusCode + " on url " + url);

                    var stream = await response.Content.ReadAsStringAsync();
                    return new WebResponse
                    {
                        Data = stream,
                        StatusCode = response.StatusCode
                    };
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        public static async Task<WebResponse> Delete(string url)
        {
            try
            {
                Debug.WriteLine("WebClient call PUT on url: " + url);

                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (httpClient)
                {
                    var response = await httpClient.DeleteAsync(url);
                    Debug.WriteLine("WebClient PUT Response code: " + response.StatusCode + " on url " + url);

                    var stream = await response.Content.ReadAsStringAsync();
                    return new WebResponse
                    {
                        Data = stream,
                        StatusCode = response.StatusCode
                    };
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        ///     Get Image from Url
        /// </summary>
        /// <param name="imageLink"></param>
        /// <returns></returns>
        public static async Task<Stream> GetImageFromUrl(string imageLink)
        {
            try
            {
                var client = new HttpClient { MaxResponseContentBufferSize = int.MaxValue };
                var uri = new Uri(imageLink);
                using (client)
                {
                    var response = await client.GetAsync(uri);
                    response.EnsureSuccessStatusCode();
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return Stream.Null;
            }
        }
    }
}
