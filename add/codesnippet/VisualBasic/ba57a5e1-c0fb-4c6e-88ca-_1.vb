            Console.Write(ControlChars.Cr + "Please enter the URL to post data to : ")
            Dim uriString As String = Console.ReadLine()

            ' Create a new WebClient instance.
            Dim myWebClient As New WebClient()

            ' Create a new NameValueCollection instance to hold some custom parameters to be posted to the URL.
            Dim myNameValueCollection As New NameValueCollection()
            
            Console.WriteLine("Please enter the following parameters to be posted to the Url")
            Console.Write("Name:")
            Dim name As String = Console.ReadLine()

            Console.Write("Age:")
            Dim age As String = Console.ReadLine()

            Console.Write("Address:")
            Dim address As String = Console.ReadLine()

            ' Add necessary parameter/value pairs to the name/value container.
            myNameValueCollection.Add("Name", name)
            myNameValueCollection.Add("Address", address)
            myNameValueCollection.Add("Age", age)

            Console.WriteLine(ControlChars.Cr + "Uploading to {0} ...", uriString)

            ' Upload the NameValueCollection.
            Dim responseArray As Byte() = myWebClient.UploadValues(uriString, "POST", myNameValueCollection)
            
            ' Decode and display the response.
            Console.WriteLine(ControlChars.Cr + "Response received was :" + ControlChars.Cr + "{0}", Encoding.ASCII.GetString(responseArray))