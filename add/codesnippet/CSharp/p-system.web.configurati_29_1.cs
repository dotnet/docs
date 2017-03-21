            // Get the current Forms property.
            
            FormsAuthenticationConfiguration currentForms = 
                authenticationSection.Forms;

            // Get the Forms attributes.
            string name = currentForms.Name;
            string login = currentForms.LoginUrl;
            string path = currentForms.Path;
            HttpCookieMode cookieLess = currentForms.Cookieless;
            bool requireSSL = currentForms.RequireSSL;
            bool slidingExpiration = currentForms.SlidingExpiration;
            bool enableXappRedirect = currentForms.EnableCrossAppRedirects;

            TimeSpan timeout = currentForms.Timeout;
            FormsProtectionEnum protection = currentForms.Protection;
            string defaultUrl = currentForms.DefaultUrl;
            string domain = currentForms.Domain;
