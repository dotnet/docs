Dim MyCookie As HttpCookie = New HttpCookie("Cookie1")
 MyCookie.Values("Val1") = "1"
 MyCookie.Values("Val2") = "2"
 MyCookie.Values("Val3") = "3"
 Response.Cookies.Add(MyCookie)
    