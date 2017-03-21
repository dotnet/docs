            Uri ourUri = new Uri(url);
				// Creates an HttpWebRequest for the specified URL. 
				HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(ourUri); 
				myHttpWebRequest.ProtocolVersion = HttpVersion.Version10;
				// Sends the HttpWebRequest and waits for the response.
				HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse(); 
				// Ensures that only Http/1.0 responses are accepted. 
				if(myHttpWebResponse.ProtocolVersion != HttpVersion.Version10)
					Console.WriteLine("\nThe server responded with a version other than Http/1.0");
				else
				if (myHttpWebResponse.StatusCode == HttpStatusCode.OK)
					Console.WriteLine("\nRequest sent using version Http/1.0. Successfully received response with version HTTP/1.0 ");
				// Releases the resources of the response.
				myHttpWebResponse.Close(); 