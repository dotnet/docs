using System.Threading.Tasks;
using System;

namespace NewStyle
{
    public class NetworkClient
    {
        // <ExceptionFilter>
        public static async Task<string> MakeRequest()
        { 
            var client = new System.Net.Http.HttpClient();
            var streamTask = client.GetStringAsync("https://localHost:10000");
            try {
                var responseText = await streamTask;
                return responseText;
            } catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("301"))
            {
                return "Site Moved";
            }
        }
        // </ExceptionFilter>

        // <HandleNotChanged>
        public static async Task<string> MakeRequestWithNotModifiedSupport()
        { 
            var client = new System.Net.Http.HttpClient();
            var streamTask = client.GetStringAsync("https://localHost:10000");
            try {
                var responseText = await streamTask;
                return responseText;
            } catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("301"))
            {
                return "Site Moved";
            } catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("304"))
            {
                return "Use the Cache";
            }
        }
        // </HandleNotChanged>
        
        // <AwaitFinally>
        public static async Task<string> MakeRequestAndLogFailures()
        { 
            await logMethodEntrance();
            var client = new System.Net.Http.HttpClient();
            var streamTask = client.GetStringAsync("https://localHost:10000");
            try {
                var responseText = await streamTask;
                return responseText;
            } catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("301"))
            {
                await logError("Recovered from redirect", e);
                return "Site Moved";
            }
            finally
            {
                await logMethodExit();
                client.Dispose();
            }
        }
        // </AwaitFinally>

        private static Task logMethodEntrance()
        {
            return Task.FromResult(true);
        }
        private static Task logMethodExit()
        {
            return Task.FromResult(true);
        }
        private static Task logError(string message, Exception e)
        {
            return Task.FromResult(1);
        }
    }
}

namespace OldStyle
{
    public class NetworkClient
    {
        // <ExceptionFilterOld>
        public static async Task<string> MakeRequest()
        { 
            var client = new System.Net.Http.HttpClient();
            var streamTask = client.GetStringAsync("https://localHost:10000");
            try {
                var responseText = await streamTask;
                return responseText;
            } catch (System.Net.Http.HttpRequestException e)
            {
                if (e.Message.Contains("301"))
                    return "Site Moved";
                else
                    throw;
            }
        }
        // </ExceptionFilterOld>
    }
}