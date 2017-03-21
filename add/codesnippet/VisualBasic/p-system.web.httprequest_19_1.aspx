            ' Write the PathInfo property value
            ' or a string if it is empty.
            If Request.PathInfo = String.Empty Then
                sw.WriteLine("The PathInfo property contains no information.")
            Else
                sw.WriteLine(Server.HtmlEncode(Request.PathInfo))
            End If