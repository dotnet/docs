		try {
			//Create a web request for "www.msn.com".
		 	HttpWebRequest myHttpWebRequest = (HttpWebRequest) WebRequest.Create("http://www.msn.com");

			//Get the headers associated with the request.
			WebHeaderCollection myWebHeaderCollection = myHttpWebRequest.Headers;

			Console.WriteLine("Configuring Webrequest to accept Danish and English language using 'Add' method");

			//Add the Accept-Language header (for Danish) in the request.
			myWebHeaderCollection.Add("Accept-Language:da");

			//Include English in the Accept-Langauge header. 
			myWebHeaderCollection.Add("Accept-Language","en;q=0.8");

			//Get the associated response for the above request.
		 	HttpWebResponse myHttpWebResponse = (HttpWebResponse) myHttpWebRequest.GetResponse();

			//Print the headers for the request.
			printHeaders(myWebHeaderCollection);
			myHttpWebResponse.Close();
		}
		//Catch exception if trying to add a restricted header.
		catch(ArgumentException e) {
			Console.WriteLine(e.Message);
		}
		catch(WebException e) {
			Console.WriteLine("\nWebException is thrown. \nMessage is :" + e.Message);
			if(e.Status == WebExceptionStatus.ProtocolError) {
				Console.WriteLine("Status Code : {0}", ((HttpWebResponse)e.Response).StatusCode);
				Console.WriteLine("Status Description : {0}", ((HttpWebResponse)e.Response).StatusDescription);
				Console.WriteLine("Server : {0}", ((HttpWebResponse)e.Response).Server);
			}
		}
		catch(Exception e) {
			Console.WriteLine("Exception is thrown. Message is :" + e.Message);
		}