
            ' Create a new request to the mentioned URL.	
            Dim myWebRequest As WebRequest = WebRequest.Create("http://www.contoso.com")
            
           ' Assign the response object of 'WebRequest' to a 'WebResponse' variable.
           
            Dim myWebResponse As WebResponse = myWebRequest.GetResponse()
           ' Release the resources of response object.
           
	     myWebResponse.Close()
	    Console.WriteLine(ControlChars.Cr + "The HttpHeaders are " + ControlChars.Cr + "{0}", myWebRequest.Headers)
