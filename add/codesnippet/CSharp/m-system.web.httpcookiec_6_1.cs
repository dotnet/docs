int loop1;
 HttpCookie MyCookie;
 HttpCookieCollection MyCookieCollection = Response.Cookies;
 
 for(loop1 = 0; loop1 < MyCookieCollection.Count; loop1++)
 {
    MyCookie = MyCookieCollection.Get(loop1);
    if(MyCookie.Value == "LastVisit")
    {
       MyCookie.Value = DateTime.Now.ToString();
       MyCookieCollection.Set(MyCookie);
    }
 }
   