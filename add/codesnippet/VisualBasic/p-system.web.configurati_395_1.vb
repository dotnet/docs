        ' Get Cookieless.
        Dim cookieless _
        As System.Web.HttpCookieMode = _
        anonymousIdentificationSection.Cookieless
        Console.WriteLine("Cookieless: {0}", cookieless)