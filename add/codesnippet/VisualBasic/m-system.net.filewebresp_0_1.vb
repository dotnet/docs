    Public Shared Sub GetPage(url As [String])
        Try
            Dim fileUrl As New Uri("file://" + url)
            ' Create a FileWebrequest with the specified Uri. 
            Dim myFileWebRequest As FileWebRequest = CType(WebRequest.Create(fileUrl), FileWebRequest)
            ' Send the 'fileWebRequest' and wait for response.
            Dim myFileWebResponse As FileWebResponse = CType(myFileWebRequest.GetResponse(), FileWebResponse)
            ' Process the response here                        
            Console.WriteLine(ControlChars.Cr + "Response Received.Trying to Close the response stream..")
            ' The method call to release resources of response object.
            myFileWebResponse.Close()
            Console.WriteLine(ControlChars.Cr + "Response Stream successfully closed")
        Catch e As WebException
            Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "The Reason for failure is : {0}", e.Status)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "The following exception was raised : {0}", e.Message)
        End Try