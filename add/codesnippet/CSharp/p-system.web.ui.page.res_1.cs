HttpCookie MyCookie = new HttpCookie("LastVisit");
DateTime now = DateTime.Now;

MyCookie.Value = now.ToString();
MyCookie.Expires = now.AddHours(1);

Response.Cookies.Add(MyCookie);
   