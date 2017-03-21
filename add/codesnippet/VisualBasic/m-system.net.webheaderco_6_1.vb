            'Create a web request for "www.msn.com".
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.msn.com"), HttpWebRequest)
	    myHttpWebRequest.Timeout = 1000
            'Get the associated response for the above request.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            
            'Get the headers associated with the response.
            Dim myWebHeaderCollection As WebHeaderCollection = myHttpWebResponse.Headers
            Dim i As Integer
            For i = 0 To myWebHeaderCollection.Count - 1
                Dim header As [String] = myWebHeaderCollection.GetKey(i)
                Dim values As [String]() = myWebHeaderCollection.GetValues(header)
                If values.Length > 0 Then
                    Console.WriteLine("The values of {0} header are : ", header)
                    Dim j As Integer
                    For j = 0 To values.Length - 1
                        Console.WriteLine(ControlChars.Tab + "{0}", values(j))
                    Next j
                Else
                    Console.WriteLine("There is no value associated with the header")
                End If
            Next i 