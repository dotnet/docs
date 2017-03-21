            ' Create a new WebClient instance.
            Dim myWebClient As New WebClient()

            ' Download home page data. 
            Console.WriteLine("Accessing {0} ...", uriString)

            ' Open a stream to point to the data stream coming from the Web resource.
            Dim myStream As Stream = myWebClient.OpenRead(uriString)

            Console.WriteLine(ControlChars.Cr + "Displaying Data :" + ControlChars.Cr)
	    Dim sr As New StreamReader(myStream)
	    Console.WriteLine(sr.ReadToEnd())


            ' Close the stream.
            myStream.Close()