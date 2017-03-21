            ' Set the 'Method' property of the 'Webrequest' to 'POST'.
            myHttpWebRequest.Method = "POST"

            Console.WriteLine(ControlChars.Cr + "Please enter the data to be posted to the (http://www.contoso.com/codesnippets/next.asp) Uri :")
            ' Create a new string object to POST data to the Url.
            Dim inputData As String = Console.ReadLine()
            Dim postData As String = "firstone" + ChrW(61) + inputData
            Dim encoding As New ASCIIEncoding()
            Dim byte1 As Byte() = encoding.GetBytes(postData)
            ' Set the content type of the data being posted.
            myHttpWebRequest.ContentType = "application/x-www-form-urlencoded"
            ' Set the content length of the string being posted.
            myHttpWebRequest.ContentLength = byte1.Length
            Dim newStream As Stream = myHttpWebRequest.GetRequestStream()
            newStream.Write(byte1, 0, byte1.Length)
            Console.WriteLine("The value of 'ContentLength' property after sending the data is {0}", myHttpWebRequest.ContentLength)
            newStream.Close()