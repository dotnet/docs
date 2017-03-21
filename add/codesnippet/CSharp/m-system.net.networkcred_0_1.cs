      // Create an empty instance of the NetworkCredential class.
      NetworkCredential myCredentials = new NetworkCredential(userName,password);
      // Create a webrequest with the specified URL. 
      WebRequest myWebRequest = WebRequest.Create(url); 
      myWebRequest.Credentials = myCredentials.GetCredential(new Uri(url),"");
      Console.WriteLine("\n\nUser Credentials:- UserName : {0} , Password : {1}",myCredentials.UserName,myCredentials.Password);
      // Send the request and wait for a response.
      Console.WriteLine("\n\nRequest to Url is sent.Waiting for response...Please wait ...");
      WebResponse myWebResponse = myWebRequest.GetResponse();
      // Process the response.
         Console.WriteLine("\nResponse received sucessfully");
      // Release the resources of the response object.
      myWebResponse.Close();