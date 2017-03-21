            Dim ourUri As New Uri(url)
            ' Creates an HttpWebRequest with the specified URL. 
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(ourUri), HttpWebRequest)
            myHttpWebRequest.ProtocolVersion = HttpVersion.Version10
            ' Sends the request and waits for the response.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            'The ProtocolVersion property is used to ensure that only Http/1.0 responses are accepted. 
            If myHttpWebResponse.ProtocolVersion Is HttpVersion.Version10 Then
                Console.WriteLine(ControlChars.NewLine + "The server responded with a version other than Http/1.0")
            Else
                If myHttpWebResponse.StatusCode = HttpStatusCode.OK Then
                    Console.WriteLine(ControlChars.NewLine + "Request sent using version HTTP/1.0. Successfully received response with version Http/1.0 ")
                End If
            End If
            ' Releases the resources of the response.
            myHttpWebResponse.Close()