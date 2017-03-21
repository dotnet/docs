    Public Shared Sub GetPage(url As [String])
       Try
            ' Creates an HttpWebRequest with the specified URL.
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            ' Sends the request and waits for a response.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            If myHttpWebResponse.StatusCode = HttpStatusCode.OK Then
                Console.WriteLine(ControlChars.Lf + ControlChars.NewLine + "Response Status Code is OK and StatusDescription is: {0}", myHttpWebResponse.StatusDescription)
            End If
            ' Release the resources of the response.
            myHttpWebResponse.Close()
        
        Catch e As WebException
            Console.WriteLine(ControlChars.Lf + ControlChars.NewLine + "Exception Raised. The following error occured : {0}", e.Status)
        Catch e As Exception
            Console.WriteLine(ControlChars.NewLine + "The following exception was raised : {0}", e.Message)
        End Try
    End Sub 