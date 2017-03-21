			// Create a New 'HttpWebRequest' object .
			HttpWebRequest myHttpWebRequest=(HttpWebRequest)WebRequest.Create("http://www.contoso.com");
			myHttpWebRequest.AddRange(50,150);	
			Console.WriteLine("Call AddRange(50,150)");
			Console.Write("Resulting Request Headers: ");
			Console.WriteLine(myHttpWebRequest.Headers.ToString());

			// Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
			HttpWebResponse myHttpWebResponse=(HttpWebResponse)myHttpWebRequest.GetResponse();

      // Displays the headers in the response received
      Console.Write("Resulting Response Headers: ");
			Console.WriteLine(myHttpWebResponse.Headers.ToString());

			// Display the contents of the page to the console.
			Stream streamResponse=myHttpWebResponse.GetResponseStream();
			StreamReader streamRead = new StreamReader( streamResponse );
			Char[] readBuffer = new Char[256];
			int count = streamRead.Read( readBuffer, 0, 256 );
			Console.WriteLine("\nThe HTML contents of the page from 50th to 150 characters are :\n  ");	
			while (count > 0) 
			{
				String outputData = new String(readBuffer, 0, count);
				Console.WriteLine(outputData);
				count = streamRead.Read(readBuffer, 0, 256);
			}
			// Release the response object resources.
			streamRead.Close();
			streamResponse.Close();
			myHttpWebResponse.Close();