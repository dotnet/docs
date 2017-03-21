      Try
         Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
         Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
         
         Console.WriteLine(("The encoding method used is: " + myHttpWebResponse.ContentEncoding))
         Console.WriteLine(("The character set used is :" + myHttpWebResponse.CharacterSet))
         
         Dim seperator As Char = "/"c
         Dim contenttype As [String] = myHttpWebResponse.ContentType
         ' Retrieve 'text' if the content type is of 'text/html.
         Dim maintype As [String] = contenttype.Substring(0, contenttype.IndexOf(seperator))
         ' Display only 'text' type.
         If [String].Compare(maintype, "text") = 0 Then
            Console.WriteLine(ControlChars.NewLine + " Content type is 'text'.")
            