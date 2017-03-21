
            ' Create a 'WebRequest' object with the specified url 
            Dim myWebRequest As WebRequest = WebRequest.Create("www.contoso.com")

            ' Send the 'WebRequest' and wait for response.
            Dim myWebResponse As WebResponse = myWebRequest.GetResponse()

            ' Call method 'GetResponseStream' to obtain stream associated with the response object
            Dim ReceiveStream As Stream = myWebResponse.GetResponseStream()
            
            Dim encode As Encoding = System.Text.Encoding.GetEncoding("utf-8")

            ' Pipe the stream to a higher level stream reader with the required encoding format.
            Dim readStream As New StreamReader(ReceiveStream, encode)
            Console.WriteLine(ControlChars.Cr + "Response stream received")
            Dim read(256) As [Char]

            ' Read 256 charcters at a time    .
            Dim count As Integer = readStream.Read(read, 0, 256)
            Console.WriteLine("HTML..." + ControlChars.Lf + ControlChars.Cr)
            While count > 0

                ' Dump the 256 characters on a string and display the string onto the console.
                Dim str As New [String](read, 0, count)
                Console.Write(str)
                count = readStream.Read(read, 0, 256)

            End While
            Console.WriteLine("")

            ' Release the resources of stream object.
	         readStream.Close()

	         ' Release the resources of response object.
            myWebResponse.Close()
            