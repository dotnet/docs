    Public Shared Sub GetPage(url As [String])
        Try
            Dim fileUrl As New Uri("file://" + url)
            ' Create a 'FileWebrequest' object with the specified Uri. 
            Dim myFileWebRequest As FileWebRequest = CType(WebRequest.Create(fileUrl), FileWebRequest)
            ' Send the 'fileWebRequest' and wait for response.
            Dim myFileWebResponse As FileWebResponse = CType(myFileWebRequest.GetResponse(), FileWebResponse)
            
            ' Display all Headers present in the response received from the Uri.
            Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "The following headers were received in the response: ")
            ' Headers property is a WebHeaderCollection. Using it's properties to traverse the collection and display each header.
            Dim i As Integer
            
            While i < myFileWebResponse.Headers.Count
                Console.WriteLine(ControlChars.Cr + "Header Name:{0}, Header value :{1}", myFileWebResponse.Headers.Keys(i), myFileWebResponse.Headers(i))
                i = i + 1
            End While
            myFileWebResponse.Close()
        
        Catch e As WebException
            Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "The Reason for failure is : {0}", e.Status)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "The following exception was raised : {0}", e.Message)
        End Try