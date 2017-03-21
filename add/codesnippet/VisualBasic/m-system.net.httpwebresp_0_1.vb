            ' Creates an HttpWebRequest for the specified URL. 
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            ' Sends the request and waits for a response.			
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            ' Calls the method GetResponseStream to return the stream associated with the response.
            Dim receiveStream As Stream = myHttpWebResponse.GetResponseStream()
            Dim encode As Encoding = System.Text.Encoding.GetEncoding("utf-8")
            ' Pipes the response stream to a higher level stream reader with the required encoding format. 
            Dim readStream As New StreamReader(receiveStream, encode)
            Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "Response stream received")
            Dim read(256) As [Char]
            ' Reads 256 characters at a time.    
            Dim count As Integer = readStream.Read(read, 0, 256)
            Console.WriteLine("HTML..." + ControlChars.Lf + ControlChars.Cr)
            While count > 0
                ' Dumps the 256 characters to a string and displays the string to the console.
                Dim str As New [String](read, 0, count)
                Console.Write(str)
                count = readStream.Read(read, 0, 256)
            End While
            Console.WriteLine("")
            ' Releases the resources of the Stream.
            readStream.Close()
	         ' Releases the resources of the response.
            myHttpWebResponse.Close()