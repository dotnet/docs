            ' ResponseHeaders is a WebHeaderCollection instance that contains the headers sent back 
	         ' in response to the WebClient request. 
            Dim myWebHeaderCollection As WebHeaderCollection = myWebClient.ResponseHeaders
            Console.WriteLine(ControlChars.Cr + "Displaying the response headers" + ControlChars.Cr)
            ' Loop through the ResponseHeaders.
            Dim i As Integer
            For i = 0 To myWebHeaderCollection.Count - 1
                ' Display the headers as name/value pairs.
                Console.WriteLine((ControlChars.Tab + myWebHeaderCollection.GetKey(i) + " " + ChrW(61) + " " + myWebHeaderCollection.Get(i)))
            Next i 