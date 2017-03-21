			// Create a 'HttpWebRequest' object.
			HttpWebRequest	myHttpWebRequest=(HttpWebRequest)WebRequest.Create(myUri);
			// Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
			HttpWebResponse myHttpWebResponse=(HttpWebResponse)myHttpWebRequest.GetResponse();
			// Display the contents of the page to the console.
			Stream streamResponse=myHttpWebResponse.GetResponseStream();
			StreamReader streamRead = new StreamReader( streamResponse );
			Char[] readBuffer = new Char[256];
			int count = streamRead.Read( readBuffer, 0, 256 );
			Console.WriteLine("\nThe contents of HTML page are.......");	
			while (count > 0) 
			{
				String outputData = new String(readBuffer, 0, count);
				Console.Write(outputData);
				count = streamRead.Read(readBuffer, 0, 256);
			}
			Console.WriteLine("\nHTTP Request  Headers :\n\n{0}",myHttpWebRequest.Headers);
			Console.WriteLine("\nHTTP Response Headers :\n\n{0}",myHttpWebResponse.Headers);
			streamRead.Close();
			streamResponse.Close();
			// Release the response object resources.
			myHttpWebResponse.Close();
			Console.WriteLine("\n'Pipelined' property is:{0}",myHttpWebRequest.Pipelined);	
			Console.WriteLine("\nPress 'Enter' Key to Continue......");
			Console.Read();	