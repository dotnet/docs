			// Create a new 'Uri' object with the specified string.
			Uri myUri =new Uri("http://www.contoso.com");
			// Create a new request to the above mentioned URL.	
			WebRequest myWebRequest= WebRequest.Create(myUri);
			// Assign the response object of 'WebRequest' to a 'WebResponse' variable.
			WebResponse myWebResponse= myWebRequest.GetResponse();