			Console.Write("\nPlease enter the URI to post data to : ");
			string uriString = Console.ReadLine();
			// Create a new WebClient instance.
			WebClient myWebClient = new WebClient();
			Console.WriteLine("\nPlease enter the data to be posted to the URI {0}:",uriString);
			string postData = Console.ReadLine();
			// Apply ASCII Encoding to obtain the string as a byte array.
			byte[] postArray = Encoding.ASCII.GetBytes(postData);
			Console.WriteLine("Uploading to {0} ...",  uriString);							
         myWebClient.Headers.Add("Content-Type","application/x-www-form-urlencoded");
		
			//UploadData implicitly sets HTTP POST as the request method.
			byte[] responseArray = myWebClient.UploadData(uriString,postArray);

			// Decode and display the response.
			Console.WriteLine("\nResponse received was :{0}", Encoding.ASCII.GetString(responseArray));