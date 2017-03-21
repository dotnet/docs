            ' Write request information to the file with HTML encoding.
            sw.WriteLine(Server.HtmlEncode(Request.RequestType))
            sw.WriteLine(Server.HtmlEncode(Request.UserHostAddress))
            sw.WriteLine(Server.HtmlEncode(Request.UserHostName))
            sw.WriteLine(Server.HtmlEncode(Request.HttpMethod))