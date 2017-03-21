      ' Get current Cookieless.
        Dim currentCookieless _
        As System.Web.HttpCookieMode = _
        formsAuthentication.Cookieless
      
      ' Set current Cookieless.
      formsAuthentication.Cookieless = HttpCookieMode.AutoDetect
      