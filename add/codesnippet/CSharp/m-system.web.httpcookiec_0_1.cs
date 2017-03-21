int loop1;

 HttpCookieCollection MyCookieCollection = Response.Cookies;
 
 for(loop1 = 0; loop1 < MyCookieCollection.Count; loop1++)
 {
    if(MyCookieCollection.GetKey(loop1) == "LastVisit")
    {
       MyCookieCollection[loop1].Value = DateTime.Now.ToString();
       MyCookieCollection.Set(MyCookieCollection[loop1]);
    }
 }
    