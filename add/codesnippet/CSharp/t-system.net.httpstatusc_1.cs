 HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create("http://www.contoso.com");
 httpReq.AllowAutoRedirect = false;
 
 HttpWebResponse httpRes = (HttpWebResponse)httpReq.GetResponse();
 
 if (httpRes.StatusCode==HttpStatusCode.Moved) 
 {
    // Code for moved resources goes here.
 }

 // Close the response.
 httpRes.Close();
   