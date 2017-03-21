            // Write request information to the file with HTML encoding.
            sw.WriteLine(Server.HtmlEncode(Request.PhysicalApplicationPath));
            sw.WriteLine(Server.HtmlEncode(Request.PhysicalPath));
            sw.WriteLine(Server.HtmlEncode(Request.RawUrl));