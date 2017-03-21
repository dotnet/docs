
            ' Create a 'WebRequest' object with the specified url 	
            Dim myWebRequest As WebRequest = WebRequest.Create("www.contoso.com")
            
            ' Send the 'WebRequest' and wait for response.
            Dim myWebResponse As WebResponse = myWebRequest.GetResponse()
            
            ' Display all the Headers present in the response received from the URl.
            Console.WriteLine(ControlChars.Cr + "The following headers were received in the response")
            
            ' Headers property is a 'WebHeaderCollection'. Use it's properties to traverse the collection and display each header
            Dim i As Integer
            
            While i < myWebResponse.Headers.Count
                Console.WriteLine(ControlChars.Cr + "Header Name:{0}, Header value :{1}", myWebResponse.Headers.Keys(i), myWebResponse.Headers(i))
		i = i + 1
            End While

            ' Release resources of response object.
            myWebResponse.Close()
            