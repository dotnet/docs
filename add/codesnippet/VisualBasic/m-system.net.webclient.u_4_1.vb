            Console.Write(ControlChars.Cr + "Please enter the URI to post data to : ")
            Dim uriString As String = Console.ReadLine()

            ' Create a new WebClient instance.
            Dim myWebClient As New WebClient()
            Console.WriteLine(ControlChars.Cr + "Please enter the data to be posted to the URI {0}:", uriString)
            Dim postData As String = Console.ReadLine()
            ' Apply ASCII Encoding to obtain the string as a byte array.
            Dim postArray As Byte() = Encoding.ASCII.GetBytes(postData)
            Console.WriteLine("Uploading to {0} ...", uriString)
            myWebClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded")

            ' UploadData implicitly sets HTTP POST as the request method.
            Dim responseArray As Byte() = myWebClient.UploadData(uriString, postArray)

            ' Decode and display the response.
            Console.WriteLine(ControlChars.Cr + "Response received was :{0}", Encoding.ASCII.GetString(responseArray))