// <Snippet1>
// This example shows how to use the ServicePoint and ServicePointManager classes.
// The ServicePointManager class uses the ServicePoint class to manage connections
// to a remote host. The networking classes reuse service points for all 
// requests to a given URI. In fact, the same ServicePoint object 
// is used to issue requests to Internet resources identified by the same
// scheme identifier (for example,  HTTP) and host fragment (for example,  www.contoso.com).  
// This should improve your application performance. 
// Reusing service points in this way can help improve application performance.
using System;
using System.Net;
using System.Threading;
using System.Text.RegularExpressions;

namespace Mssc.Services.ConnectionManagement
{
    class TestServicePoint
    {
        private static void ShowProperties (ServicePoint sp)
        {
            Console.WriteLine ("Done calling FindServicePoint()...");

// <Snippet2>
            // Display the ServicePoint Internet resource address.
            Console.WriteLine ("Address = {0} ", sp.Address.ToString ());

// </Snippet2>
// <Snippet3>
            // Display the date and time that the ServicePoint was last 
            // connected to a host.
            Console.WriteLine ("IdleSince = " + sp.IdleSince.ToString ());

            // Display the maximum length of time that the ServicePoint instance  
            // is allowed to maintain an idle connection to an Internet  
            // resource before it is recycled for use in another connection.
            Console.WriteLine ("MaxIdleTime = " + sp.MaxIdleTime);

// </Snippet3>
// <Snippet4>
            Console.WriteLine ("ConnectionName = " + sp.ConnectionName);

            // Display the maximum number of connections allowed on this 
            // ServicePoint instance.
            Console.WriteLine ("ConnectionLimit = " + sp.ConnectionLimit);

            // Display the number of connections associated with this 
            // ServicePoint instance.
            Console.WriteLine ("CurrentConnections = " + sp.CurrentConnections);

// </Snippet4>
// <Snippet5>
            if (sp.Certificate == null)
                Console.WriteLine ("Certificate = (null)");
            else
                Console.WriteLine ("Certificate = " + sp.Certificate.ToString ());

            if (sp.ClientCertificate == null)
                Console.WriteLine ("ClientCertificate = (null)");
            else
                Console. WriteLine ("ClientCertificate = " + sp.ClientCertificate.ToString ());

            Console.WriteLine ("ProtocolVersion = " + sp.ProtocolVersion.ToString ());
            Console.WriteLine ("SupportsPipelining = " + sp.SupportsPipelining);

// </Snippet5>
            // <Snippet9>
            Console.WriteLine ("UseNagleAlgorithm = " + sp.UseNagleAlgorithm.ToString ());
            Console.WriteLine ("Expect 100-continue = " + sp.Expect100Continue.ToString ());
            //</Snippet9>
        }

// <Snippet6>
        private static void makeWebRequest (int hashCode, string Uri)
        {
            HttpWebResponse res = null;

            // Make sure that the idle time has elapsed, so that a new 
            // ServicePoint instance is created.
            Console.WriteLine ("Sleeping for 2 sec.");
            Thread.Sleep (2000);
            try
            {
                // Create a request to the passed URI.
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create (Uri);

                Console.WriteLine ("\nConnecting to " + Uri + " ............");

                // Get the response object.
                res = (HttpWebResponse)req.GetResponse ();
                Console.WriteLine ("Connected.\n");

                ServicePoint currentServicePoint = req.ServicePoint;

                // Display new service point properties.
                int currentHashCode = currentServicePoint.GetHashCode ();

                Console.WriteLine ("New service point hashcode: " + currentHashCode);
                Console.WriteLine ("New service point max idle time: " + currentServicePoint.MaxIdleTime);
                Console.WriteLine ("New service point is idle since " + currentServicePoint.IdleSince );

                // Check that a new ServicePoint instance has been created.
                if (hashCode == currentHashCode)
                    Console.WriteLine ("Service point reused.");
                else
                    Console.WriteLine ("A new service point created.") ;
            }
            catch (Exception e)
            {
                Console.WriteLine ("Source : " + e.Source);
                Console.WriteLine ("Message : " + e.Message);
            }
            finally
            {
                if (res != null)
                    res.Close ();
            }
        }

// </Snippet6>
        // Show the user how to use this program when wrong inputs are entered.
        private static void showUsage ()
        {
            Console.WriteLine ("Enter the proxy name as follows:");
            Console.WriteLine ("\tcs_servicepoint proxyName");
        }

// <Snippet7>
        public static void Main (string[] args)
        {
            int port = 80;

            // Define a regular expression to parse the user's input.
            // This is a security check. It allows only
            // alphanumeric input strings between 2 to 40 characters long.
            Regex rex = new Regex (@"^[a-zA-Z]\w{1,39}$");

            if (args.Length < 1)
            {
                showUsage ();
                return;
            }
            string proxy = args[0];

            if ((rex.Match (proxy)).Success != true)
            {
                Console.WriteLine ("Input string format not allowed.");
                return;
            }
            string proxyAdd = "http://" + proxy + ":" + port;

            // Create a proxy object.  
            WebProxy DefaultProxy = new WebProxy (proxyAdd, true);

            // Set the proxy that all HttpWebRequest instances use.
            WebRequest.DefaultWebProxy = DefaultProxy;

            // Get the base interface for proxy access for the 
            // WebRequest-based classes.
            IWebProxy Iproxy = WebRequest.DefaultWebProxy;

            // <Snippet8>
            // Set the maximum number of ServicePoint instances to 
            // maintain. If a ServicePoint instance for that host already 
            // exists when your application requests a connection to
            // an Internet resource, the ServicePointManager object
            // returns this existing ServicePoint instance. If none exists 
            // for that host, it creates a new ServicePoint instance.
            ServicePointManager.MaxServicePoints = 4;

            // Set the maximum idle time of a ServicePoint instance to 10 seconds.
            // After the idle time expires, the ServicePoint object is eligible for
            // garbage collection and cannot be used by the ServicePointManager object.
            ServicePointManager.MaxServicePointIdleTime = 10000;

            // </Snippet8>


            // <Snippet10>
            ServicePointManager.UseNagleAlgorithm = true;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.CheckCertificateRevocationList = true;
            ServicePointManager.DefaultConnectionLimit = ServicePointManager.DefaultPersistentConnectionLimit;
            // </Snippet10>
            // Create the Uri object for the resource you want to access.
            Uri MS = new Uri ("http://msdn.microsoft.com/");

            // Use the FindServicePoint method to find an existing 
            // ServicePoint object or to create a new one.  
            ServicePoint servicePoint = ServicePointManager.FindServicePoint (MS, Iproxy);

            ShowProperties (servicePoint);

            int hashCode = servicePoint.GetHashCode ();

            Console.WriteLine ("Service point hashcode: " + hashCode);

            // Make a request with the same scheme identifier and host fragment
            // used to create the previous ServicePoint object.
            makeWebRequest (hashCode, "http://msdn.microsoft.com/library/");
        

            
        }

// </Snippet7>
    }
}
// </Snippet1>
