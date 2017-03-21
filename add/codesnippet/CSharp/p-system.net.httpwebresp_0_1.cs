        try 
 		  {	
            // Creates an HttpWebRequest for the specified URL. 
				HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url); 
				HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse(); 
				string method ;
				method = myHttpWebResponse.Method;
				if (String.Compare(method,"GET") == 0)
					Console.WriteLine("\nThe 'GET' method was successfully invoked on the following Web Server : {0}",
									   myHttpWebResponse.Server);
				// Releases the resources of the response.
				myHttpWebResponse.Close();
          } 
		catch(WebException e) 
		   {
		        Console.WriteLine("\nWebException raised. The following error occured : {0}",e.Status); 
           }
		catch(Exception e)
			{
				Console.WriteLine("\nThe following Exception was raised : {0}",e.Message);
			}
	}