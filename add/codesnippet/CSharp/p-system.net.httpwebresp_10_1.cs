			Uri myUri = new Uri(url);
			// Create a 'HttpWebRequest' object for the specified url. 
			HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(myUri); 
			// Send the request and wait for response.
			HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse(); 
			if (myHttpWebResponse.StatusCode == HttpStatusCode.OK)
                Console.WriteLine("\nRequest succeeded and the requested information is in the response ,Description : {0}",
									myHttpWebResponse.StatusDescription);
			if (myUri.Equals(myHttpWebResponse.ResponseUri))
				Console.WriteLine("\nThe Request Uri was not redirected by the server");
			else
				Console.WriteLine("\nThe Request Uri was redirected to :{0}",myHttpWebResponse.ResponseUri);
			// Release resources of response object.
			myHttpWebResponse.Close(); 