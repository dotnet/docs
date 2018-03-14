//<snippet1>
using System;
using System.Net;
using System.IO;
namespace Examples.Http
{
    public class TestGlobalProxySelection
    {
        public static void Main()
        {
            // Create a request for the Web page at www.contoso.com.
            WebRequest request = WebRequest.Create("http://www.contoso.com");
            // This application doesn't want the proxy to be used so it sets 
            // the global proxy to an empty proxy.
            IWebProxy myProxy = GlobalProxySelection.GetEmptyWebProxy();
            GlobalProxySelection.Select = myProxy;
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the response to the console.
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            Console.WriteLine(reader.ReadToEnd());
            // Clean up.
            reader.Close();
            stream.Close();
            response.Close();
        }
    }
}
//</snippet1>