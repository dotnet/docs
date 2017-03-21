			// Create a New 'HttpWebRequest' object .
			HttpWebRequest myHttpWebRequest1=(HttpWebRequest)WebRequest.Create("http://www.contoso.com");
			myHttpWebRequest1.AddRange(1000);	
			Console.WriteLine("Call AddRange(1000)");
			Console.Write("Resulting Headers: ");
			Console.WriteLine(myHttpWebRequest1.Headers.ToString());
			
			// Create a New 'HttpWebRequest' object .
			HttpWebRequest myHttpWebRequest2=(HttpWebRequest)WebRequest.Create("http://www.contoso.com");
			myHttpWebRequest2.AddRange(-1000);	
			Console.WriteLine("Call AddRange(-1000)");
			Console.Write("Resulting Headers: ");
			Console.WriteLine(myHttpWebRequest2.Headers.ToString());