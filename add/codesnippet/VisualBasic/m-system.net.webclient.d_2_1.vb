
            Console.Write(ControlChars.Cr + "Please enter a Url(for example, http://www.msn.com): ")
            Dim remoteUrl As String = Console.ReadLine()
            ' Create a new WebClient instance.
            Dim myWebClient As New WebClient()
            ' Download the home page data.
            Console.WriteLine(("Downloading " + remoteUrl))
            ' DownloadData() method takes a 'uriRemote.ToString()' and downloads the Web resource and saves it into a data buffer.
            Dim myDatabuffer As Byte() = myWebClient.DownloadData(remoteUrl)

            ' Display the downloaded data.
            Dim download As String = Encoding.ASCII.GetString(myDataBuffer)
            Console.WriteLine(download)

            Console.WriteLine("Download successful.")