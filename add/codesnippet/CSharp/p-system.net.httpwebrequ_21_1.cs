         // Create a 'HttpWebRequest' object.
         HttpWebRequest myHttpWebRequest=(HttpWebRequest)WebRequest.Create(myUri);
         // Set the 'Accept' property to accept an image of any type.
         myHttpWebRequest.Accept="image/*";
         // The response object of 'HttpWebRequest' is assigned to a 'HttpWebResponse' variable.
         HttpWebResponse myHttpWebResponse=(HttpWebResponse)myHttpWebRequest.GetResponse();