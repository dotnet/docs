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
