   public static void GetPage(String url) 
    {
        try 
         {     
               Uri fileUrl = new Uri("file://"+url);
               // Create a 'FileWebrequest' object with the specified Uri .
               FileWebRequest myFileWebRequest = (FileWebRequest)WebRequest.Create(fileUrl); 
               // Send the 'fileWebRequest' and wait for response.
               FileWebResponse myFileWebResponse = (FileWebResponse)myFileWebRequest.GetResponse(); 
               // Display all Headers present in the response received from the Uri.
               Console.WriteLine("\r\nThe following headers were received in the response:");
               // Display each header and the key of the response object.
               for(int i=0; i < myFileWebResponse.Headers.Count; ++i)  
                   Console.WriteLine("\nHeader Name:{0}, Header value :{1}",myFileWebResponse.Headers.Keys[i],
                                   myFileWebResponse.Headers[i]); 
               myFileWebResponse.Close(); 
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