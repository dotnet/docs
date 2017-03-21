   public static void GetPage(String url) 
    {
        try 
        {     
            Uri fileUrl = new Uri("file://"+url);
            // Create a FileWebrequest with the specified Uri. 
            FileWebRequest myFileWebRequest = (FileWebRequest)WebRequest.Create(fileUrl); 
            // Send the 'fileWebRequest' and wait for response.
            FileWebResponse myFileWebResponse = (FileWebResponse)myFileWebRequest.GetResponse(); 
            // Process the response here.
            Console.WriteLine("\nResponse Received.Trying to Close the response stream..");
            // Release resources of response object.
            myFileWebResponse.Close();
         Console.WriteLine("\nResponse Stream successfully closed.");            
         } 
        catch(WebException e) 
         {
           Console.WriteLine("\r\nWebException thrown.The Reason for failure is : {0}",e.Status); 
       }
        catch(Exception e)
       {
           Console.WriteLine("\nThe following Exception was raised : {0}",e.Message);
        }
   }