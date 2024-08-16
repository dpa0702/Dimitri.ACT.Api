using System.Net.Http.Headers;

namespace Dimitri.ACT.Core.Helpers
{
    public static class HttpClientConfiguration
    {
        public static HttpClient EntryClient()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:9005")
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}