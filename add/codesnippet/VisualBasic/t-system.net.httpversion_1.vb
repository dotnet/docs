            ' Create a 'HttpWebRequest' object.
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.microsoft.com"), HttpWebRequest)
            Console.WriteLine(ControlChars.Cr + "The 'ProtocolVersion' of the protocol before assignment is :{0}", myHttpWebRequest.ProtocolVersion)
            ' Assign Version10 to ProtocolVersion.
            myHttpWebRequest.ProtocolVersion = HttpVersion.Version10
            ' The response object of 'HttpWebRequest' is assigned to a 'HttpWebResponse' variable.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            Console.WriteLine(ControlChars.Cr + "The 'ProtocolVersion' of the protocol after  assignment is :{0}", myHttpWebRequest.ProtocolVersion)
            Console.WriteLine(ControlChars.Cr + "The 'ProtocolVersion' of the response object is :{0}", myHttpWebResponse.ProtocolVersion)