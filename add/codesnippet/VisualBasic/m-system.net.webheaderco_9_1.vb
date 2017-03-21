    Public Shared Sub Main()
      Try
            'Create a web request for "www.msn.com".
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.msn.com"), HttpWebRequest)
            
            'Get the headers associated with the request.
            Dim myWebHeaderCollection As WebHeaderCollection = myHttpWebRequest.Headers
            
            'Set the Cache-Control header.
            myWebHeaderCollection.Set("Cache-Control", "no-cache")
            
            'Get the associated response for the above request.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            
            'Print the headers of the request to console.
            Console.WriteLine("Print request headers after adding Cache-Control for first request")
            printHeaders(myHttpWebRequest.Headers)
            
       
            'Remove the Cache-Control header for the new request.
            myWebHeaderCollection.Remove("Cache-Control")
            
            'Code example for "Remove" method of "WebHeaderCollection" ends here.
            'Get the response for the new request.
            myHttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            
            'Print the headers of the new request without the Cache-Control header.
            Console.WriteLine("Print request headers after removing Cache-Control for the new request")
            printHeaders(myHttpWebRequest.Headers)
            myHttpWebResponse.Close()
        'Catch exception if trying to remove a restricted header.
        Catch e As ArgumentException
            Console.WriteLine("Error : Trying to remove a restricted header")
            Console.WriteLine(e.Message)
        Catch e As WebException
            Console.WriteLine(e.Message)
            If e.Status = WebExceptionStatus.ProtocolError Then
                Console.WriteLine("Status Code : {0}", CType(e.Response, HttpWebResponse).StatusCode)
                Console.WriteLine("Status Description : {0}", CType(e.Response, HttpWebResponse).StatusDescription)
                Console.WriteLine("Server : {0}", CType(e.Response, HttpWebResponse).Server)
            End If
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

    End Sub 'Main