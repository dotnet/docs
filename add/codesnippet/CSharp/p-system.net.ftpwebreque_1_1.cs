            IWebProxy proxy = request.Proxy;
            if (proxy != null)
            {
                Console.WriteLine("Proxy: {0}", proxy.GetProxy(request.RequestUri));
            } 
            else
            {
                Console.WriteLine("Proxy: (none)");
            }
            
            Console.WriteLine("ConnectionGroup: {0}",
                request.ConnectionGroupName == null ? "none" : request.ConnectionGroupName
            );