HttpCookieCollection MyCookieCollection = Request.Cookies;
 HttpCookie MyCookie = MyCookieCollection.Get("LastVisit");
 MyCookie.Value = DateTime.Now.ToString();
 MyCookieCollection.Set(MyCookie);
   