            ' Create a new 'HttpWebRequest' Object.
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.contoso.com"), HttpWebRequest)
            Dim myHttpWebResponse As HttpWebResponse
            ' Display the 'HaveResponse' property of the 'HttpWebRequest' object to the console.
            Console.WriteLine(ControlChars.Cr + "The value of 'HaveResponse' property before a response object is obtained :{0}", myHttpWebRequest.HaveResponse)
            ' Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
            myHttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            If myHttpWebRequest.HaveResponse Then
                Dim streamResponse As Stream = myHttpWebResponse.GetResponseStream()
                Dim streamRead As New StreamReader(streamResponse)
                Dim readBuff(256) As [Char]
                Dim count As Integer = streamRead.Read(readBuff, 0, 256)
                Console.WriteLine(ControlChars.Cr + "The contents of Html Page are :  " + ControlChars.Cr)
                While count > 0
                    Dim outputData As New [String](readBuff, 0, count)
                    Console.Write(outputData)
                    count = streamRead.Read(readBuff, 0, 256)
                End While
		          '  Close the Stream object.
		          streamResponse.Close()
		          streamRead.Close()
		          ' Release the HttpWebResponse Resource.
		          myHttpWebResponse.Close()
                Console.WriteLine(ControlChars.Cr + "Press 'Enter' key to continue..........")
                Console.Read()
            
            Else
                Console.WriteLine(ControlChars.Cr + "The response is not received ")
            End If