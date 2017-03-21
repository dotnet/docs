Dim MyCookie As New HttpCookie("LastVisit")
 MyCookie.Value = CStr(DateTime.Now())
 Response.AppendCookie(MyCookie)
    