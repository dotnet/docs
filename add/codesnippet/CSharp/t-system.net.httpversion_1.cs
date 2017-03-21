			// Create a 'HttpWebRequest' object.
			HttpWebRequest myHttpWebRequest=(HttpWebRequest)WebRequest.Create("http://www.microsoft.com");
			Console.WriteLine("\nThe 'ProtocolVersion' of the protocol before assignment is :{0}",myHttpWebRequest.ProtocolVersion);
			// Assign Version10 to ProtocolVersion.
			myHttpWebRequest.ProtocolVersion=HttpVersion.Version10;
			// Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
			HttpWebResponse myHttpWebResponse=(HttpWebResponse)myHttpWebRequest.GetResponse();
			Console.WriteLine("\nThe 'ProtocolVersion' of the protocol after  assignment is :{0}",myHttpWebRequest.ProtocolVersion);
			Console.WriteLine("\nThe 'ProtocolVersion' of the response object is :{0}",myHttpWebResponse.ProtocolVersion);