            WebOperationContext current = WebOperationContext.Current;
            WebHeaderCollection headers = current.IncomingRequest.Headers;

            foreach (string name in headers)
            {
                Console.WriteLine(name + " " + headers.Get(name));
            }