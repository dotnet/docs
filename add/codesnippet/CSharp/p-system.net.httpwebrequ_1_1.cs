			// Create a new 'HttpWebRequest' Object to the mentioned URL.
			HttpWebRequest myHttpWebRequest=(HttpWebRequest)WebRequest.Create("http://www.microsoft.com");
			// Use the existing 'ProtocolVersion' , and display it onto the console.	
			Console.WriteLine("\nThe 'ProtocolVersion' of the protocol used is {0}",myHttpWebRequest.ProtocolVersion);
			// Set the 'ProtocolVersion' property of the 'HttpWebRequest' to 'Version1.0' .
			myHttpWebRequest.ProtocolVersion=HttpVersion.Version10;
			 // Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
			 HttpWebResponse myHttpWebResponse=(HttpWebResponse)myHttpWebRequest.GetResponse();
			Console.WriteLine("\nThe 'ProtocolVersion' of the protocol changed to {0}",myHttpWebRequest.ProtocolVersion);
			Console.WriteLine("\nThe protocol version of the response object is {0}",myHttpWebResponse.ProtocolVersion);