 HttpWebRequest HttpWReq = 
 (HttpWebRequest)WebRequest.Create("http://www.contoso.com");
 
 HttpWebResponse HttpWResp = (HttpWebResponse)HttpWReq.GetResponse();
 // Insert code that uses the response object.
 HttpWResp.Close();