Dim MyCookieCollection as New HttpCookieCollection()
 Dim MyCookie As New HttpCookie("LastVisit")
 MyCookie.Value = DateTime.Now().ToString()
 MyCookieCollection.Add(MyCookie)
    