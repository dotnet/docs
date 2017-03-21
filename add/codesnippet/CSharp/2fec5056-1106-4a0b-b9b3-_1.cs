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



            ServicePointManager.UseNagleAlgorithm = true;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.CheckCertificateRevocationList = true;
            ServicePointManager.DefaultConnectionLimit = ServicePointManager.DefaultPersistentConnectionLimit;
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
