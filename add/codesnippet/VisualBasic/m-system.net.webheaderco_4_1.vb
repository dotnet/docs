    Public Shared Sub Main()

	Try
            'Create a web request for "www.msn.com".
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.msn.com"), HttpWebRequest)
            
            'Get the headers associated with the request.
            Dim myWebHeaderCollection As WebHeaderCollection = myHttpWebRequest.Headers
            
            'Set the Cache-Control header in the request.
            myWebHeaderCollection.Set("Cache-Control", "no-cache")

            'Get the associated response for the above request.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            
	    Console.WriteLine ("Headers after 'Set' method is used on Cache-Control :")
            'Print the headers for the request.
            PrintHeaders(myWebHeaderCollection)
            myHttpWebResponse.Close()
       'Catch exception if trying to set a restricted header.
        Catch e As ArgumentException
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