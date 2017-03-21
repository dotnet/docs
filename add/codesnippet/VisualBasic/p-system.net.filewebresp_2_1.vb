    Public Shared Sub GetPage(url As [String])
        
        Try
            Dim fileUrl As New Uri("file://" + url)
            ' Create a 'FileWebrequest' object with the specified Uri 
            Dim myFileWebRequest As FileWebRequest = CType(WebRequest.Create(fileUrl), FileWebRequest)
            ' Send the 'fileWebRequest' and wait for response.    
            Dim myFileWebResponse As FileWebResponse = CType(myFileWebRequest.GetResponse(), FileWebResponse)
            
            ' The ContentLength and ContentType received as headers in the response object are also exposed as properties.
            ' These provide information about the length and type of the entity body in the response.
            Console.WriteLine(ControlChars.Cr + "Content length :{0}, Content Type : {1}", myFileWebResponse.ContentLength, myFileWebResponse.ContentType)
            myFileWebResponse.Close()
        Catch e As WebException
            Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "The Reason for failure is : {0}", e.Status)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "The following exception was raised : {0}", e.Message)
        End Try