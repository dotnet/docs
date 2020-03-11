using System;
using System.Net.Http;
using System.Net.Security;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace whats_new
{
    public static class httptest
    {
        public static async Task Request()
        {
            // <SnippetRequest>
            var client = new HttpClient() { BaseAddress = new Uri("https://localhost:5001") };

            // HTTP/1.1 request
            using (var response = await client.GetAsync("/"))
                Console.WriteLine(response.Content);

            // HTTP/2 request
            using (var request = new HttpRequestMessage(HttpMethod.Get, "/") { Version = new Version(2, 0) })
            using (var response = await client.SendAsync(request))
                Console.WriteLine(response.Content);
            // </SnippetRequest>
        }

        public static async Task Client()
        {
            // <SnippetClient>
            var client = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:5001"),
                DefaultRequestVersion = new Version(2, 0)
            };

            // HTTP/2 is default
            using (var response = await client.GetAsync("/"))
                Console.WriteLine(response.Content);
            // </SnippetClient>
        }

        public static void SetAppContext()
        {
            // <SnippetAppContext>
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            // </SnippetAppContext>
        }
    }
}
