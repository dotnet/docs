           ' Create a new 'HttpWebRequest' object to the mentioned URL.
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.contoso.com"), HttpWebRequest)
            myHttpWebRequest.UserAgent= ".NET Framework Test Client"
            ' The response object of 'HttpWebRequest' is assigned to a 'HttpWebResponse' variable.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            ' Display the contents of the page to the console.
            Dim streamResponse As Stream = myHttpWebResponse.GetResponseStream()
            Dim streamRead As New StreamReader(streamResponse)
            Dim readBuff(256) As [Char]
            Dim count As Integer = streamRead.Read(readBuff, 0, 256)
            Console.WriteLine(ControlChars.Cr + "The contents of HTML Page are :" + ControlChars.Cr)
            While count > 0
                Dim outputData As New [String](readBuff, 0, count)
                Console.Write(outputData)
                count = streamRead.Read(readBuff, 0, 256)
            End While
            streamRead.Close()
	         streamResponse.Close()    
          ' Release the response object resources.
	         myHttpWebResponse.Close()