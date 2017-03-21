            ' Create a new 'HttpWebRequest' Object to the mentioned URL.
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.contoso.com"), HttpWebRequest)
            ' Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            Console.WriteLine(ControlChars.Cr + "The HttpHeaders are " + ControlChars.Cr + ControlChars.Cr + ControlChars.Tab + "Name" + ControlChars.Tab + ControlChars.Tab + "Value" + ControlChars.Cr + "{0}", myHttpWebRequest.Headers)

            ' Print the HTML contents of the page to the console. 
            Dim streamResponse As Stream = myHttpWebResponse.GetResponseStream()
            Dim streamRead As New StreamReader(streamResponse)
            Dim readBuff(256) As [Char]
            Dim count As Integer = streamRead.Read(readBuff, 0, 256)
            Console.WriteLine(ControlChars.Cr + "The HTML contents of page the are  : " + ControlChars.Cr + ControlChars.Cr + " ")
            While count > 0
                Dim outputData As New [String](readBuff, 0, count)
                Console.Write(outputData)
                count = streamRead.Read(readBuff, 0, 256)
            End While
	   ' Close the Stream object.
	   streamResponse.Close()
	   streamRead.Close()
	   ' Release the HttpWebResponse Resource.
	    myHttpWebResponse.Close()