Dim MyCookieCollection As HttpCookieCollection = Request.Cookies
 Dim MyCookie As HttpCookie = MyCookieCollection.Get("LastVisit")
 MyCookie.Value = DateTime.Now().ToString()
 MyCookieCollection.Set(MyCookie)
   