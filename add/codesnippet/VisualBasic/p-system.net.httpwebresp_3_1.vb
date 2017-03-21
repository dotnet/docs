      Try
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            Dim method As String
            method = myHttpWebResponse.Method
            If [String].Compare(method, "GET") = 0 Then
                Console.WriteLine(ControlChars.NewLine + "The GET method was successfully invoked on the following Web Server : {0}", myHttpWebResponse.Server)
            End If
            ' Releases the resources of the response.
            myHttpWebResponse.Close()
        Catch e As WebException
            Console.WriteLine(ControlChars.NewLine + "Exception Raised. The following error occured : {0}", e.Status)
        Catch e As Exception
            Console.WriteLine(ControlChars.NewLine + "The following exception was raised : {0}", e.Message)
        End Try