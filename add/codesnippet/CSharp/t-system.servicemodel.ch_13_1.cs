        static Message BuildMessage()
        {
            Message messageToSend = null;
            HttpRequestMessageProperty reqProps = new HttpRequestMessageProperty();
            reqProps.SuppressEntityBody = false;
            reqProps.Headers.Add("CustomHeader", "Test Value");
            reqProps.Headers.Add(HttpRequestHeader.UserAgent, "my user agent");

            try
            {
                messageToSend = Message.CreateMessage(MessageVersion.Soap11, "http://tempuri.org/IUntypedService/ProcessMessage", "Hello WCF");
            }
            catch (Exception e)
            {
                Console.WriteLine("got exception when sending message: " + e.ToString());
            }

            messageToSend.Properties[HttpRequestMessageProperty.Name] = reqProps;
            return messageToSend;
        }