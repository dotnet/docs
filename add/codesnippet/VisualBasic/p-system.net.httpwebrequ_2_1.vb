            ' Create a 'HttpWebRequest' object.
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(myUri), HttpWebRequest)
            ' Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            ' Display the contents of the page to the console
            Dim streamResponse As Stream = myHttpWebResponse.GetResponseStream()
            Dim streamRead As New StreamReader(streamResponse)
            Dim readBuffer(256) As [Char]
            Dim count As Integer = streamRead.Read(readBuffer, 0, 256)
            Console.WriteLine(ControlChars.Cr + "The contents of HTML page are.......")
            While count > 0
                Dim outputData As New [String](readBuffer, 0, count)
                Console.Write(outputData)
                count = streamRead.Read(readBuffer, 0, 256)
            End While
            Console.WriteLine(ControlChars.Cr + "HTTP Request  Headers :" + ControlChars.Cr + ControlChars.Cr + "{0}", myHttpWebRequest.Headers)
            Console.WriteLine(ControlChars.Cr + "HTTP Response Headers :" + ControlChars.Cr + ControlChars.Cr + "{0}", myHttpWebResponse.Headers)
            streamRead.Close()
	         streamResponse.Close()
            ' Release the response object resources.
            myHttpWebResponse.Close()
            Console.WriteLine(ControlChars.Cr + "'Pipelined' property is:{0}", myHttpWebRequest.Pipelined)
            Console.WriteLine(ControlChars.Cr + "Press 'Enter' Key to Continue......")
            Console.Read()