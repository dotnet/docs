            ' Creates an HttpWebRequest with the specified URL. 
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            ' Sends the HttpWebRequest and waits for a response.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            ' Displays all the Headers present in the response received from the URI.
            Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "The following headers were received in the response")
            'The Headers property is a WebHeaderCollection. Use it's properties to traverse the collection and display each header.
            Dim i As Integer
            While i < myHttpWebResponse.Headers.Count
                Console.WriteLine(ControlChars.Cr + "Header Name:{0}, Value :{1}", myHttpWebResponse.Headers.Keys(i), myHttpWebResponse.Headers(i))
		      i = i + 1
            End While
            myHttpWebResponse.Close()