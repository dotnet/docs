HttpCookieCollection MyCookieCollection = new HttpCookieCollection();
 HttpCookie MyCookie = new HttpCookie("LastVisit");
 MyCookie.Value = DateTime.Now.ToString();
 MyCookieCollection.Add(MyCookie);
    