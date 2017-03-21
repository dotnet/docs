
            Dim ourUri As New Uri(url)
            ' Create a 'WebRequest' object with the specified url. 

            Dim myWebRequest As WebRequest = WebRequest.Create(url)

            ' Send the 'WebRequest' and wait for response.
            Dim myWebResponse As WebResponse = myWebRequest.GetResponse()
            
            ' "ResponseUri" property is used to get the actual Uri from where the response was attained.
            If ourUri.Equals(myWebResponse.ResponseUri) Then
                Console.WriteLine(ControlChars.Cr + "Request Url : {0} was not redirected", url)
            Else
                Console.WriteLine(ControlChars.Cr + "Request Url : {0} was redirected to {1}", url, myWebResponse.ResponseUri)
            End If 

            ' Release resources of response object.
            myWebResponse.Close()
            