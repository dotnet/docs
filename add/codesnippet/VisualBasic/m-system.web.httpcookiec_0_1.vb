Dim loop1 As Integer
 Dim MyCookie As HttpCookie
 Dim MyCookieCollection As HttpCookieCollection = Request.Cookies
 
 For loop1 = 0 To MyCookieCollection.Count - 1
    If MyCookieCollection.GetKey(loop1) = "LastVisit" Then
       MyCookieCollection(loop1).Value = DateTime.Now().ToString()
       MyCookieCollection.Set(MyCookieCollection(loop1))
       Exit For
    End If
 Next loop1
    