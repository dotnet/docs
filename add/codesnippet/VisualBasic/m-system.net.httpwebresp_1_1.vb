    Public Shared Sub GetPage(url As [String])
	Try
            Dim ourUri As New Uri(url)
            ' Creates an HttpWebRequest for the specified URL. 
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(ourUri), HttpWebRequest)
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            Console.WriteLine(ControlChars.NewLine + "The server did not issue any challenge.  Please try again with a protected resource URL.")
            ' Releases the resources of the response.
            myHttpWebResponse.Close()
        Catch e As WebException
            Dim response As HttpWebResponse = CType(e.Response, HttpWebResponse)
            If Not (response Is Nothing) Then
                If response.StatusCode = HttpStatusCode.Unauthorized Then
                    Dim challenge As String = Nothing
                    challenge = response.GetResponseHeader("WWW-Authenticate")
                    If Not (challenge Is Nothing) Then
                        Console.WriteLine(ControlChars.NewLine + "The following challenge was raised by the server:{0}", challenge)
                    End If
                Else
                    Console.WriteLine(ControlChars.NewLine + "The following exception was raised : {0}", e.Message)
                End If
            Else
                Console.WriteLine(ControlChars.NewLine + "Response Received from server was null")
            End If 
        Catch e As Exception
            Console.WriteLine(ControlChars.NewLine + "The following exception was raised : {0}", e.Message)
        End Try
    End Sub 