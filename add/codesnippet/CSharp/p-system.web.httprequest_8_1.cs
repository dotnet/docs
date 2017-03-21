Uri MyUrl = Request.UrlReferrer;
 Response.Write("Referrer URL Port: " + Server.HtmlEncode(MyUrl.Port.ToString()) + "<br>");
 Response.Write("Referrer URL Protocol: " + Server.HtmlEncode(MyUrl.Scheme) + "<br>");
   