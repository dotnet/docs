    void AuthenticationService_CreatingCookie(object sender, 
        System.Web.ApplicationServices.CreatingCookieEventArgs e)
    {
        FormsAuthenticationTicket ticket = new
              FormsAuthenticationTicket
                (1,
                 e.UserName,
                 DateTime.Now,
                 DateTime.Now.AddMinutes(30),
                 e.IsPersistent,
                 e.CustomCredential,
                 FormsAuthentication.FormsCookiePath);

        string encryptedTicket =
             FormsAuthentication.Encrypt(ticket);

        HttpCookie cookie = new HttpCookie
             (FormsAuthentication.FormsCookieName,
              encryptedTicket);
        cookie.Expires = DateTime.Now.AddMinutes(30);

        HttpContext.Current.Response.Cookies.Add(cookie);
        e.CookieIsSet = true;
    }