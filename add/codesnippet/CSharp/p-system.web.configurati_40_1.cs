            // Get CookieProtection.
            System.Web.Security.CookieProtection cookieProtection =
                anonymousIdentificationSection.CookieProtection;
            Console.WriteLine("Cookie protection: {0}",
                       cookieProtection);