			// Create a new HttpWebRequest Object to the mentioned URL.
			HttpWebRequest myHttpWebRequest=(HttpWebRequest)WebRequest.Create("http://www.contoso.com");	
			myHttpWebRequest.MaximumAutomaticRedirections=1;
			myHttpWebRequest.AllowAutoRedirect=true;
			HttpWebResponse myHttpWebResponse=(HttpWebResponse)myHttpWebRequest.GetResponse();	