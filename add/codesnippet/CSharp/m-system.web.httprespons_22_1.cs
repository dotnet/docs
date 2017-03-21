HttpCookie MyCookie = new HttpCookie("LastVisit");
 MyCookie.Value = DateTime.Now.ToString();
 Response.AppendCookie(MyCookie);
    