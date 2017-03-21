Dim MyUrl As Uri = Request.Url
 Response.Write("URL Port: " & MyUrl.Port & "<br>")
 Response.Write("URL Protocol: " & Server.HtmlEncode(MyUrl.Scheme) & "<br>")
