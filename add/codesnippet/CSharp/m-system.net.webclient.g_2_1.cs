        protected override WebRequest GetWebRequest (Uri address)
        {
            WebRequest request = (WebRequest) base.GetWebRequest (address);

            // Perform any customizations on the request.
            // This version of WebClient always preauthenticates.
            request.PreAuthenticate = true;
            return request;
        }