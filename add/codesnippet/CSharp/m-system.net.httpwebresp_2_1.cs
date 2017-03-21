            // Creates an HttpWebRequest for the specified URL. 
				HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url); 
				// Sends the HttpWebRequest and waits for a response.
				HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse(); 
				Console.WriteLine("\nResponse Received.Trying to Close the response stream..");
				// Releases the resources of the response.
				myHttpWebResponse.Close(); 
				Console.WriteLine("\nResponse Stream successfully closed");