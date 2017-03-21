            ' Create a new 'HttpWebRequest' Object to the mentioned URL.
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.microsoft.com"), HttpWebRequest)
            ' Use the existing 'ProtocolVersion' , and display it onto the console.	
            Console.WriteLine(ControlChars.Cr + "The 'ProtocolVersion' of the protocol used is {0}", myHttpWebRequest.ProtocolVersion)
            ' Set the 'ProtocolVersion' property of the 'HttpWebRequest' to 'Version1.0' .
            myHttpWebRequest.ProtocolVersion = HttpVersion.Version10
            '  Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            Console.WriteLine(ControlChars.Cr + "The 'ProtocolVersion' of the protocol changed to {0}", myHttpWebRequest.ProtocolVersion)
            Console.WriteLine(ControlChars.Cr + "The protocol version of the response object is {0}", myHttpWebResponse.ProtocolVersion)