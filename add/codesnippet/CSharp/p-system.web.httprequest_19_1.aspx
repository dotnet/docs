            // Write the PathInfo property value
            // or a string if it is empty.
            if (Request.PathInfo == String.Empty)
            {
                sw.WriteLine("The PathInfo property contains no information.");
            }
            else
            {
                sw.WriteLine(Server.HtmlEncode(Request.PathInfo));
            }