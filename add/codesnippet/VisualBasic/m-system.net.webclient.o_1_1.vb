            Dim uriString As String
            Console.Write(ControlChars.Cr + "Please enter the URI to post data to : ")
            uriString = Console.ReadLine()
            Console.WriteLine(ControlChars.Cr + "Please enter the data to be posted to the URI {0}:", uriString)

            Dim postData As String = Console.ReadLine()

            ' Apply ASCII Encoding to obtain an array of bytes .
            Dim postArray As Byte() = Encoding.ASCII.GetBytes(postData)

            ' Create a new WebClient instance.
            Dim myWebClient As New WebClient()

            Console.WriteLine("Uploading to {0} ...", uriString)

            ' OpenWrite implicitly sets HTTP POST as the request method.
            Dim postStream As Stream = myWebClient.OpenWrite(uriString)
            postStream.Write(postArray, 0, postArray.Length)

            ' Close the stream and release resources.
            postStream.Close()

            Console.WriteLine(ControlChars.Cr + "Successfully posted the data.")