        public Message ProcessMessage(Message request)
        {
            Message response = null;

            //The HTTP Method (e.g. GET) from the incoming HTTP request
            //can be found on the HttpRequestMessageProperty. The MessageProperty
            //is added by the HTTP Transport when the message is received.
            HttpRequestMessageProperty requestProperties =
                (HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];

            //Here we dispatch to different internal implementation methods
            //based on the incoming HTTP verb.
            if (requestProperties != null)
            {
                if (String.Equals("GET", requestProperties.Method,
                    StringComparison.OrdinalIgnoreCase))
                {
                    response = GetCustomer(request);
                }
                else if (String.Equals("POST", requestProperties.Method,
                    StringComparison.OrdinalIgnoreCase))
                {
                    response = UpdateCustomer(request);
                }
                else if (String.Equals("PUT", requestProperties.Method,
                    StringComparison.OrdinalIgnoreCase))
                {
                    response = AddCustomer(request);
                }
                else if (String.Equals("DELETE", requestProperties.Method,
                    StringComparison.OrdinalIgnoreCase))
                {
                    response = DeleteCustomer(request);
                }
                else
                {
                    //This service doesn't implement handlers for other HTTP verbs (such as HEAD), so we
                    //construct a response message and use the HttpResponseMessageProperty to
                    //set the HTTP status code to 405 (Method Not Allowed) which indicates the client 
                    //used an HTTP verb not supported by the server.
                    response = Message.CreateMessage(MessageVersion.None, String.Empty, String.Empty);

                    HttpResponseMessageProperty responseProperty = new HttpResponseMessageProperty();
                    responseProperty.StatusCode = HttpStatusCode.MethodNotAllowed;

                    response.Properties.Add( HttpResponseMessageProperty.Name, responseProperty );
                }
            }
            else
            {
                throw new InvalidOperationException( "This service requires the HTTP transport" );
            }

            return response;
        }