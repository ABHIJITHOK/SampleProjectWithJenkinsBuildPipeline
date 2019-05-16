using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public static CookieContainer cookieContainer = null;
        public static HttpClientHandler clientHandler = null;
        public static HttpClient client = null;

        public static void Main(string[] args)
        {
            var response = new HttpResponseMessage();
            cookieContainer = new CookieContainer();
            clientHandler = new HttpClientHandler
            {
                AllowAutoRedirect = true,
                UseCookies = true,
                CookieContainer = cookieContainer
            };
            client = new HttpClient(clientHandler);
            client.BaseAddress = new Uri("http://localhost:8082", UriKind.Absolute);
            var byteArray = Encoding.ASCII.GetBytes("AbhyKizhakkepat:113191ab7c7075fcf99499dc5e67ede990");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            Console.WriteLine("Triggering build now");
            try
            {
                var parameters = new Dictionary<string, string> {
                        { "token", "ABHIJITH" }
                    };
                var encodedContent = new FormUrlEncodedContent(parameters);
                System.Net.ServicePointManager.Expect100Continue = false;
                response = client.PostAsync("job/AbhyDotNetCorePipeline14May2019/build", encodedContent).Result;
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.Message);
                throw;
            }

            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Successfully triggerred the Jenkins build. \n\n{JsonConvert.SerializeObject(response, Formatting.Indented)}");
            }
            else
            {
                Console.WriteLine($"Failed to trigger the Jenkins build.");
            }            
        }
    }
}
