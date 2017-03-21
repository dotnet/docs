
                     // Create a 'WebRequest' with the specified url.
			WebRequest myWebRequest = WebRequest.Create("http://www.contoso.com"); 

			// Send the 'WebRequest' and wait for response.
			WebResponse myWebResponse = myWebRequest.GetResponse(); 

			// Display the content length and content type received as headers in the response object.
			Console.WriteLine("\nContent length :{0}, Content Type : {1}", 
			                             myWebResponse.ContentLength, 
			                             myWebResponse.ContentType);  
			
			// Release resources of response object.
			myWebResponse.Close(); 
			