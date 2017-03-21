            Dim remoteUri As String = "http://www.contoso.com/library/homepage/images/"
            Dim fileName As String = "ms-banner.gif"
            Dim myStringWebResource As String = Nothing
            ' Create a new WebClient instance.
            Dim myWebClient As New WebClient()
            ' Concatenate the domain with the Web resource filename. Because DownloadFile 
            'requires a fully qualified resource name, concatenate the domain with the Web resource file name.
            myStringWebResource = remoteUri + fileName
            Console.WriteLine("Downloading File ""{0}"" from ""{1}"" ......." + ControlChars.Cr + ControlChars.Cr, fileName, myStringWebResource)
            ' The DownloadFile() method downloads the Web resource and saves it into the current file-system folder.
            myWebClient.DownloadFile(myStringWebResource, fileName)
            Console.WriteLine("Successfully Downloaded file ""{0}"" from ""{1}""", fileName, myStringWebResource)
            Console.WriteLine((ControlChars.Cr + "Downloaded file saved in the following file system folder:" + ControlChars.Cr + ControlChars.Tab + Application.StartupPath))