            ' Write request information to the file with HTML encoding.
            sw.WriteLine(Server.HtmlEncode(DateTime.Now.ToString()))
            sw.WriteLine(Server.HtmlEncode(Request.CurrentExecutionFilePath))
            sw.WriteLine(Server.HtmlEncode(Request.ApplicationPath))
            sw.WriteLine(Server.HtmlEncode(Request.FilePath))
            sw.WriteLine(Server.HtmlEncode(Request.Path))