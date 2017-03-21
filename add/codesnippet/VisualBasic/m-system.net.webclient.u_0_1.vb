
            Console.Write(ControlChars.Cr + "Please enter the URI to post data to : ")
            Dim uriString As String = Console.ReadLine()

            ' Create a new WebClient instance.
            Dim myWebClient As New WebClient()

            Console.WriteLine(ControlChars.Cr & _
                "Please enter the fully qualified path of the file to be uploaded to the URI")

            Dim fileName As String = Console.ReadLine()
            Console.WriteLine("Uploading {0} to {1} ...", fileName, uriString)

            ' Upload the file to the URI.
            ' The 'UploadFile(uriString,fileName)' method implicitly uses HTTP POST method. 
            Dim responseArray As Byte() = myWebClient.UploadFile(uriString, fileName)

            ' Decode and display the response.
            Console.WriteLine(ControlChars.Cr & "Response Received.The contents of the file uploaded are: " & _
                ControlChars.Cr & "{0}", System.Text.Encoding.ASCII.GetString(responseArray))
