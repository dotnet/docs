        public void ProcessMessage(Message input)
        {
            try
            {
                Console.WriteLine("ProcessMessage: Message received: " + input.GetBody<string>());
                HttpRequestMessageProperty reqProp = (HttpRequestMessageProperty)input.Properties[HttpRequestMessageProperty.Name];
                string customString = reqProp.Headers.Get("CustomHeader");
                string userAgent = reqProp.Headers[HttpRequestHeader.UserAgent];
                Console.WriteLine();
                Console.WriteLine("ProcessMessage: Got custom header: {0}, User-Agent: {1}", customString, userAgent);
            }
            catch (Exception e)
            {
                Console.WriteLine("ProcessMessage: got exception: " + e.ToString());
            }
        }