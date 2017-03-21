int loop1;
 HttpCookie MyCookie;
 HttpCookieCollection MyCookieCollection;
 
 MyCookieCollection = Request.Cookies;
 
 for (loop1 = 0; loop1 < MyCookieCollection.Count; loop1++)
 {
    MyCookie = MyCookieCollection[loop1];
    if (MyCookie.Name == "UserName")
    {
       //...
    }
 }
    