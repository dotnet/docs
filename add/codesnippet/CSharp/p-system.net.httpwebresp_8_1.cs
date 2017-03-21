    public static void GetPage(String url) 
	{
		try 
 		  {	
				// Creates an HttpWebRequest for the specified URL. 
				HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url); 
				// Sends the HttpWebRequest and waits for a response.
				HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse(); 
				if (myHttpWebResponse.StatusCode == HttpStatusCode.OK)
				   Console.WriteLine("\r\nResponse Status Code is OK and StatusDescription is: {0}",
										myHttpWebResponse.StatusDescription);
				// Releases the resources of the response.
				myHttpWebResponse.Close(); 
			
        	} 
		catch(WebException e) 
		   {
		        Console.WriteLine("\r\nWebException Raised. The following error occured : {0}",e.Status); 
           }
		catch(Exception e)
		{
			Console.WriteLine("\nThe following Exception was raised : {0}",e.Message);
		}
	}