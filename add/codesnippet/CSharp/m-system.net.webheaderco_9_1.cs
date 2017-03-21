		try {
			// Create a web request for "www.msn.com".
		 	HttpWebRequest myHttpWebRequest = (HttpWebRequest) WebRequest.Create("http://www.msn.com");

			// Get the headers associated with the request.
			WebHeaderCollection myWebHeaderCollection = myHttpWebRequest.Headers;

			// Set the Cache-Control header.
			myWebHeaderCollection.Set("Cache-Control", "no-cache");

			// Get the associated response for the above request.
		 	HttpWebResponse myHttpWebResponse = (HttpWebResponse) myHttpWebRequest.GetResponse();

			// Print the headers of the request to console.
			Console.WriteLine("Print request headers after adding Cache-Control for first request:");
			printHeaders(myHttpWebRequest.Headers);

			// Remove the Cache-Control header for the new request.
			myWebHeaderCollection.Remove("Cache-Control");

			// Get the response for the new request.
			myHttpWebResponse = (HttpWebResponse) myHttpWebRequest.GetResponse();

			// Print the headers of the new request without the Cache-Control header.
			Console.WriteLine("Print request headers after removing Cache-Control for the new request:");
			printHeaders(myHttpWebRequest.Headers);
			myHttpWebResponse.Close();
		}
		// Catch exception if trying to remove a restricted header.
		catch(ArgumentException e) {
			Console.WriteLine("Error : Trying to remove a restricted header");
			Console.WriteLine("ArgumentException is thrown. Message is :" + e.Message);
		}
		catch(WebException e) {
			Console.WriteLine("WebException is thrown. Message is :" + e.Message);
			if(e.Status == WebExceptionStatus.ProtocolError) {
				Console.WriteLine("Status Code : {0}", ((HttpWebResponse)e.Response).StatusCode);
				Console.WriteLine("Status Description : {0}", ((HttpWebResponse)e.Response).StatusDescription);
				Console.WriteLine("Server : {0}", ((HttpWebResponse)e.Response).Server);
			}
		}
		catch(Exception e) {
			Console.WriteLine("Exception is thrown. Message is :" + e.Message);
		}