            ' Create a 'WebRequest' object with the specified url 	
            Dim myWebRequest As WebRequest = WebRequest.Create("www.contoso.com")
            ' Send the 'WebRequest' and wait for response.	
            Dim myWebResponse As WebResponse = myWebRequest.GetResponse()
            
            '  Process the response here
            Console.WriteLine(ControlChars.Cr + "Response Received.Trying to Close the response stream..")
            ' Release resources of response object
            myWebResponse.Close()
            Console.WriteLine(ControlChars.Cr + "Response Stream successfully closed")