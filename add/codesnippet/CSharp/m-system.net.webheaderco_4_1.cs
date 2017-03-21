		try {
			// Create a web request for "www.msn.com".
		 	HttpWebRequest myHttpWebRequest = (HttpWebRequest) WebRequest.Create("http://www.msn.com");

			// Get the headers associated with the request.
			WebHeaderCollection myWebHeaderCollection = myHttpWebRequest.Headers;

			// Set the Cache-Control header in the request.
			myWebHeaderCollection.Set("Cache-Control", "no-cache");

			// Get the associated response for the above request.
		 	HttpWebResponse myHttpWebResponse = (HttpWebResponse) myHttpWebRequest.GetResponse();

			Console.WriteLine ("Headers after 'Set' method is used on Cache-Control :");
			// Print the headers for the request.
			PrintHeaders(myWebHeaderCollection);
			myHttpWebResponse.Close();
		}
		// Catch exception if trying to set a restricted header.
		catch(ArgumentException e) {
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