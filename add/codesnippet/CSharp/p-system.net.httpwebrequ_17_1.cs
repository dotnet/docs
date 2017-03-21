
			// Create a new 'HttpWebRequest' object to the mentioned Uri.				
			HttpWebRequest myHttpWebRequest=(HttpWebRequest)WebRequest.Create("http://www.contoso.com/codesnippets/next.asp");
			// Set AllowWriteStreamBuffering to 'false'. 
			myHttpWebRequest.AllowWriteStreamBuffering=false;
			Console.WriteLine("\nPlease Enter the data to be posted to the (http://www.contoso.com/codesnippets/next.asp) uri:");
			string inputData =Console.ReadLine();
			string postData="firstone="+inputData;
			// Set 'Method' property of 'HttpWebRequest' class to POST.
			myHttpWebRequest.Method="POST";
			ASCIIEncoding encodedData=new ASCIIEncoding();
			byte[]  byteArray=encodedData.GetBytes(postData);
			// Set 'ContentType' property of the 'HttpWebRequest' class to "application/x-www-form-urlencoded".
			myHttpWebRequest.ContentType="application/x-www-form-urlencoded";
			// If the AllowWriteStreamBuffering property of HttpWebRequest is set to false,the contentlength has to be set to length of data to be posted else Exception(411) is raised.
			myHttpWebRequest.ContentLength=byteArray.Length;
			Stream newStream=myHttpWebRequest.GetRequestStream();
			newStream.Write(byteArray,0,byteArray.Length);
			newStream.Close();
			Console.WriteLine("\nData has been posted to the Uri\n\nPlease wait for the response..........");
			// Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
			HttpWebResponse myHttpWebResponse=(HttpWebResponse)myHttpWebRequest.GetResponse();