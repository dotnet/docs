Dim loop1 As Integer
 Dim MyCookie As HttpCookie
 Dim MyCookieCollection As HttpCookieCollection = Request.Cookies
 
 For loop1 = 0 To MyCookieCollection.Count - 1
    MyCookie = MyCookieCollection.Get(loop1)
    If MyCookie.Name = "LastVisit" Then
       MyCookie.Value = DateTime.Now().ToString()
       MyCookieCollection.Set(MyCookie)
    End If
 Next loop1
   