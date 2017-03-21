            Dim myUri As New Uri(url)
            ' Creates an HttpWebRequest for the specified URL.
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(myUri), HttpWebRequest)
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            If myHttpWebResponse.StatusCode = HttpStatusCode.OK Then
                Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "Request succeeded and the requested information is in the response , Description : {0}", myHttpWebResponse.StatusDescription)
            End If
            Dim today As DateTime = DateTime.Now
            ' Uses the LastModified property to compare with today's date.
            If DateTime.Compare(today, myHttpWebResponse.LastModified) = 0 Then
                Console.WriteLine(ControlChars.Cr + "The requested URI entity was modified today")
            Else
                If DateTime.Compare(today, myHttpWebResponse.LastModified) =  1 Then
                    Console.WriteLine(ControlChars.Cr + "The requested Uri was last modified on:{0}", myHttpWebResponse.LastModified)
                End If
            End If
            ' Releases the resources of the response.
            myHttpWebResponse.Close()