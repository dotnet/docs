            Dim uriString As String
            Console.Write(ControlChars.Cr + "Please enter the URI to post data to{for example, http://www.contoso.com} : ")
            uriString = Console.ReadLine()

            ' Create a new WebClient instance.
            Dim myWebClient As New WebClient()
            Console.WriteLine(ControlChars.Cr + "Please enter the data to be posted to the URI {0}:", uriString)
            Dim postData As String = Console.ReadLine()
            myWebClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded")
            
            ' Display the headers in the request
            Console.Write("Resulting Request Headers: ")
            Console.Writeline(myWebClient.Headers.ToString())

            ' Apply ASCII Encoding to obtain the string as a byte array.
            Dim byteArray As Byte() = Encoding.ASCII.GetBytes(postData)
            Console.WriteLine("Uploading to {0} ...", uriString)
            ' Upload the input string using the HTTP 1.0 POST method.
            Dim responseArray As Byte() = myWebClient.UploadData(uriString, "POST", byteArray)
            ' Decode and display the response.
            Console.WriteLine(ControlChars.Cr + "Response received was :{0}", Encoding.ASCII.GetString(responseArray))