            ' A new 'HttpWebRequest' object is created 				
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.contoso.com/codesnippets/next.asp"), HttpWebRequest)
           ' AllowWriteStreamBuffering is set to 'false' 
            myHttpWebRequest.AllowWriteStreamBuffering = False
            Console.WriteLine(ControlChars.Cr + "Please Enter the data to be posted to the (http://www.contoso.com/codesnippets/next.asp) uri:")
            Dim inputData As String = Console.ReadLine()
            Dim postData As String = "firstone" + ChrW(61) + inputData
            ' 'Method' property of 'HttpWebRequest' class is set to POST.
            myHttpWebRequest.Method = "POST"
            Dim encodedData As New ASCIIEncoding()
            Dim byteArray As Byte() = encodedData.GetBytes(postData)
            ' 'ContentType' property of the 'HttpWebRequest' class is set to "application/x-www-form-urlencoded".
            myHttpWebRequest.ContentType = "application/x-www-form-urlencoded"
            ' If the AllowWriteStreamBuffering property of HttpWebRequest is set to false,then contentlength has to be set to length of data to be posted else Exception(411) Length required is raised.
             myHttpWebRequest.ContentLength=byteArray.Length
            Dim newStream As Stream = myHttpWebRequest.GetRequestStream()
            newStream.Write(byteArray, 0, byteArray.Length)
            newStream.Close()
            Console.WriteLine(ControlChars.Cr + "Data has been posted to the Uri" + ControlChars.Cr + ControlChars.Cr + "Please wait for the response..........")
            ' The response object of 'HttpWebRequest' is assigned to a 'HttpWebResponse' variable.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)