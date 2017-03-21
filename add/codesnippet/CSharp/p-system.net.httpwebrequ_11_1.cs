			// Create a new 'HttpWebRequest' Object.
			HttpWebRequest myHttpWebRequest=(HttpWebRequest)WebRequest.Create("http://www.contoso.com");
			HttpWebResponse myHttpWebResponse;
			// Display the 'HaveResponse' property of the 'HttpWebRequest' object to the console.
			Console.WriteLine("\nThe value of 'HaveResponse' property before a response object is obtained :{0}",myHttpWebRequest.HaveResponse);
			// Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
			myHttpWebResponse=(HttpWebResponse)myHttpWebRequest.GetResponse();
			if (myHttpWebRequest.HaveResponse)
			{
				Stream streamResponse=myHttpWebResponse.GetResponseStream();
				StreamReader streamRead = new StreamReader( streamResponse );
				Char[] readBuff = new Char[256];
				int count = streamRead.Read( readBuff, 0, 256 );
				Console.WriteLine("\nThe contents of Html Page are :  \n");	
				while (count > 0) 
				{
					String outputData = new String(readBuff, 0, count);
					Console.Write(outputData);
					count = streamRead.Read(readBuff, 0, 256);
				}
				// Close the Stream object.
				streamResponse.Close();
				streamRead.Close();
				// Release the HttpWebResponse Resource.
				myHttpWebResponse.Close();
				Console.WriteLine("\nPress 'Enter' key to continue..........");
				Console.Read();
			}
			else
			{
				Console.WriteLine("\nThe response is not received ");
			}