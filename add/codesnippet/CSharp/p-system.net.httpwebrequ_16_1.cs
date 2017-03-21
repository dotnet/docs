         // A new 'HttpWebRequest' object is created.
         HttpWebRequest myHttpWebRequest=(HttpWebRequest)WebRequest.Create(myUri);
         myHttpWebRequest.SendChunked=true;
         // 'TransferEncoding' property is set to 'gzip'.
         myHttpWebRequest.TransferEncoding="gzip";
         Console.WriteLine("\nPlease Enter the data to be posted to the (http://<machine name>/CodeSnippetTest.asp) uri:");
         string inputData =Console.ReadLine();
         string postData="testdata="+inputData;
         // 'Method' property of 'HttpWebRequest' class is set to POST.
         myHttpWebRequest.Method="POST";
         ASCIIEncoding encodedData=new ASCIIEncoding();
         byte[]  byteArray=encodedData.GetBytes(postData);
         // 'ContentType' property of the 'HttpWebRequest' class is set to "application/x-www-form-urlencoded".
         myHttpWebRequest.ContentType="application/x-www-form-urlencoded";
         // 'ContentLength' property is set to Length of the data to be posted.
         myHttpWebRequest.ContentLength=byteArray.Length;
         Stream newStream=myHttpWebRequest.GetRequestStream();
         newStream.Write(byteArray,0,byteArray.Length);
         newStream.Close();
         Console.WriteLine("\nData has been posted to the Uri\n\nPlease wait for the response..........");
         // The response object of 'HttpWebRequest' is assigned to a 'HttpWebResponse' variable.
         HttpWebResponse myHttpWebResponse=(HttpWebResponse)myHttpWebRequest.GetResponse();
         // Displaying the contents of the page to the console
         Stream streamResponse=myHttpWebResponse.GetResponseStream();
         StreamReader streamRead = new StreamReader( streamResponse );
         Char[] readBuff = new Char[256];
         int count = streamRead.Read( readBuff, 0, 256 );
         Console.WriteLine("\nThe contents of the HTML page are :  ");
         while (count > 0) 
         {
            String outputData = new String(readBuff, 0, count);
            Console.WriteLine(outputData);
            count = streamRead.Read(readBuff, 0, 256);
         }
         // Release the response object resources.
         streamRead.Close();
         streamResponse.Close();
         myHttpWebResponse.Close(); 