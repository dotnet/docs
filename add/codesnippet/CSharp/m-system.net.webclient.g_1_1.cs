        protected override WebResponse GetWebResponse (WebRequest request, IAsyncResult result)
        {
            WebResponse response = base.GetWebResponse (request, result);
            // Perform any custom actions with the response ...
            return response;
        }