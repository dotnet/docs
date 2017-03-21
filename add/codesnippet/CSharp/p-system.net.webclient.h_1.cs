     	string uriString;
			Console.Write("\nPlease enter the URI to post data to {for example, http://www.contoso.com} : ");
			uriString = Console.ReadLine();

			// Create a new WebClient instance.
			WebClient myWebClient = new WebClient();
			Console.WriteLine("\nPlease enter the data to be posted to the URI {0}:",uriString);
			string postData = Console.ReadLine();
			myWebClient.Headers.Add("Content-Type","application/x-www-form-urlencoded");

      // Display the headers in the request
			Console.Write("Resulting Request Headers: ");
			Console.WriteLine(myWebClient.Headers.ToString());
			
			// Apply ASCII Encoding to obtain the string as a byte array.
     
			byte[] byteArray = Encoding.ASCII.GetBytes(postData);
			Console.WriteLine("Uploading to {0} ...",  uriString);						
			// Upload the input string using the HTTP 1.0 POST method.
			byte[] responseArray = myWebClient.UploadData(uriString,"POST",byteArray);
			
			// Decode and display the response.
			Console.WriteLine("\nResponse received was {0}",
	        Encoding.ASCII.GetString(responseArray));
				      