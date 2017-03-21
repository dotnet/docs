	try 
 		  {	
			HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url); 
			HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse(); 

			Console.WriteLine("The encoding method used is: " + myHttpWebResponse.ContentEncoding);
			Console.WriteLine("The character set used is :" + myHttpWebResponse.CharacterSet);

			char seperator = '/';
			String contenttype = myHttpWebResponse.ContentType;
			// Retrieve 'text' if the content type is of 'text/html.
			String maintype = contenttype.Substring(0,contenttype.IndexOf(seperator));
			// Display only 'text' type.
			if (String.Compare(maintype,"text") == 0) 
				{
				Console.WriteLine("\n Content type is 'text'.");
