        Try
            'Create a web request for an invalid site. Substitute the "invalid site" strong in the Create call with a invalid name.
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("invalid site"), HttpWebRequest)
            
            'Get the associated response for the above request.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            myHttpWebResponse.Close()
        Catch e As WebException
            Console.WriteLine(e.Message)
            
             If e.Status = WebExceptionStatus.ProtocolError Then
                Console.WriteLine("Status Code : {0}", CType(e.Response, HttpWebResponse).StatusCode)
                Console.WriteLine("Status Description : {0}", CType(e.Response, HttpWebResponse).StatusDescription)
            End If

       Catch e As Exception
            Console.WriteLine(e.Message)
        End Try