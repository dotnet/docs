        // Get the request principal.
        public string GetRequestPrincipal()
        {
            // Get the request principal.
            return (string.Format(
                "Request principal name: {0}",
                RequestInformation.Principal.Identity.Name));
        }