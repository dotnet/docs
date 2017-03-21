			// Create a new 'HttpWebRequest' Object to the mentioned URL.
			HttpWebRequest myHttpWebRequest=(HttpWebRequest)WebRequest.Create("http://www.contoso.com");
			Console.WriteLine("\nThe timeout time of the request before setting the property is  {0}  milliSeconds.",myHttpWebRequest.Timeout);
			// Set the  'Timeout' property of the HttpWebRequest to 10 milliseconds.
			myHttpWebRequest.Timeout=10;
			// Display the 'Timeout' property of the 'HttpWebRequest' on the console.
			Console.WriteLine("\nThe timeout time of the request after setting the timeout is {0}  milliSeconds.",myHttpWebRequest.Timeout);
			// A HttpWebResponse object is created and is GetResponse Property of the HttpWebRequest associated with it 
			HttpWebResponse myHttpWebResponse=(HttpWebResponse)myHttpWebRequest.GetResponse();