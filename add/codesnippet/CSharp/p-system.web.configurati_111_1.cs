            // Get current Cookieless.
            System.Web.HttpCookieMode currentCookieless = 
                formsAuthentication.Cookieless;
 
            // Set current Cookieless.
            formsAuthentication.Cookieless = 
                HttpCookieMode.AutoDetect;
