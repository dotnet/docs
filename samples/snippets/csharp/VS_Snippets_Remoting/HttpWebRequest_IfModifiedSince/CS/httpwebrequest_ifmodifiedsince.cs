/*
  System.Net.HttpWebRequest.IfModifiedSince
This program demonstrates the 'IfModifiedSince' property of the 'HttpWebRequest' class .
A new 'HttpWebrequest' object is created.
A new 'DateTime' object is created with the value intialized to the present DateTime.
The 'IfModifiedSince' property of 'HttpWebRequest' object is compared with the 'DateTime' object.
If the requested page has been modified since the time of the DateTime object 
then the output displays the page has been modified 
else the response headers and the contents of the page of the requested Uri are printed to the Console.

 */

using System;
using System.Net;
using System.IO;
using System.Text;

class HttpWebRequest_IfModifiedSince
{
  public static void Main()
  {
    try
    {	
    // <Snippet1>
    // Create a new 'Uri' object with the mentioned string.
    Uri myUri =new Uri("http://www.contoso.com");			
    // Create a new 'HttpWebRequest' object with the above 'Uri' object.
    HttpWebRequest myHttpWebRequest= (HttpWebRequest)WebRequest.Create(myUri);

    // Create a new 'DateTime' object.
    DateTime targetDate = DateTime.Now;
    // Set a target date of a week ago
    targetDate.AddDays(-7.0);
    myHttpWebRequest.IfModifiedSince = targetDate;

    try   
    {
      // Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
      HttpWebResponse myHttpWebResponse=(HttpWebResponse)myHttpWebRequest.GetResponse();
      Console.WriteLine("Response headers for recently modified page\n{0}\n",myHttpWebResponse.Headers);
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
				
      Console.WriteLine("\nPress 'Enter' key to continue.................");	
      Console.Read();
    }
    catch(WebException e)
    {
      if (e.Response != null)
      {
        if ( ((HttpWebResponse)e.Response).StatusCode == HttpStatusCode.NotModified)
          Console.WriteLine("\nThe page has not been modified since "+targetDate);
        else
          Console.WriteLine("\nUnexpected status code = " + ((HttpWebResponse)e.Response).StatusCode);  
      }
      else
        Console.WriteLine("\nUnexpected Web Exception " + e.Message); 
    }
// </Snippet1>
		}
		catch(WebException e)
		{
			Console.WriteLine("\nWebException Caught!");
			Console.WriteLine("Source  :{0}", e.Source);
			Console.WriteLine("Message :{0}",e.Message);
		} 
		catch(Exception e)
		{
			Console.WriteLine("\nException raised!");
			Console.WriteLine("Source  :{0}", e.Source);
			Console.WriteLine("Message :{0}" , e.Message);
		}
	}	
}

