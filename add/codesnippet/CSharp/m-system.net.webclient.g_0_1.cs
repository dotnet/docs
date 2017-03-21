        protected override WebResponse GetWebResponse (WebRequest request)
        {
            WebResponse response = base.GetWebResponse (request);
            // Perform any custom actions with the response ...
            return response;
        }