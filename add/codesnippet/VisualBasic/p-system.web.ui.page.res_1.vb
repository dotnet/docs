Dim MyCookie As New HttpCookie("LastVisit")
Dim now As DateTime = DateTime.Now

MyCookie.Value = now.ToString()
MyCookie.Expires = now.AddHours(1)

Response.Cookies.Add(MyCookie)
   