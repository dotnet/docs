            ' Create a new WebClient instance.
            Dim myWebClient As New WebClient()

            ' Set the BaseAddress of the Web resource in the WebClient.
            myWebClient.BaseAddress = hostUri
            Console.WriteLine(("Downloading from " + hostUri + "/" + uriSuffix))
            Console.WriteLine(ControlChars.Cr + "Press Enter key to continue")
            Console.ReadLine()

            ' Download the target Web resource into a byte array.
            Dim myDatabuffer As Byte() = myWebClient.DownloadData(uriSuffix)

            ' Display the downloaded data.
	    Dim download As String = Encoding.ASCII.GetString(myDatabuffer)
	    Console.WriteLine(download)

            Console.WriteLine(("Download of " + myWebClient.BaseAddress.ToString() + uriSuffix + " was successful."))