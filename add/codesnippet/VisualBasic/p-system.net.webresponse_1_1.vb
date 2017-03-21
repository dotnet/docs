
            ' Create a 'WebRequest' with the specified url. 	
            Dim myWebRequest As WebRequest = WebRequest.Create("www.contoso.com")

            ' Send the 'WebRequest' and wait for response.
            Dim myWebResponse As WebResponse = myWebRequest.GetResponse()

            ' The ContentLength and ContentType received as headers in the response object are also exposed as properties.
			   ' These provide information about the length and type of the entity body in the response.
            Console.WriteLine(ControlChars.Cr + "Content length :{0}, Content Type : {1}", myWebResponse.ContentLength, myWebResponse.ContentType)
            myWebResponse.Close()
            