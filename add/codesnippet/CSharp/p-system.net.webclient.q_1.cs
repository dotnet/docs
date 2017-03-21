			string uriString = "http://www.contoso.com/search";
			// Create a new WebClient instance.
			WebClient myWebClient = new WebClient();
			// Create a new NameValueCollection instance to hold the QueryString parameters and values.
			NameValueCollection myQueryStringCollection = new NameValueCollection();
			Console.Write("Enter the word(s), separated by space character to search for in " +  uriString + ": ");
			// Read user input phrase to search for at uriString.
			string searchPhrase = Console.ReadLine();
			if (searchPhrase.Length > 1)
				// Assign the user-defined search phrase.
				myQueryStringCollection.Add("q",searchPhrase);
			else
				// If error, default to search for 'Microsoft'.
				myQueryStringCollection.Add("q","Microsoft");		
			// Assign auxilliary parameters required for the search.
			Console.WriteLine("Searching " + uriString + " .......");
			// Attach QueryString to the WebClient.
			myWebClient.QueryString = myQueryStringCollection;
			// Download the search results Web page into 'searchresult.htm' for inspection.
			myWebClient.DownloadFile (uriString, "searchresult.htm");
			Console.WriteLine("\nDownload of " + uriString + " was successful. Please see 'searchresult.htm' for results.");