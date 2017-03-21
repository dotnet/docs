            Dim myUri As New Uri(url)
            ' Create a 'HttpWebRequest' object for the specified url 
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(myUri), HttpWebRequest)
            ' Send the request and wait for response.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            If myHttpWebResponse.StatusCode = HttpStatusCode.OK Then
                Console.WriteLine(ControlChars.Cr + "Request succeeded and the requested information is in the response , Description : {0}", myHttpWebResponse.StatusDescription)
            End If
            If myUri.Equals(myHttpWebResponse.ResponseUri) Then
                Console.WriteLine(ControlChars.Cr + "The Request Uri was not redirected by the server")
            Else
                Console.WriteLine(ControlChars.Cr + "The Request Uri was redirected to :{0}", myHttpWebResponse.ResponseUri)
            End If
            ' Release resources of response object.
            myHttpWebResponse.Close()