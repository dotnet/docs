 Dim httpReq As HttpWebRequest = CType(WebRequest.Create("http://www.contoso.com"), HttpWebRequest)
 httpReq.AllowAutoRedirect = False
        
 Dim httpRes As HttpWebResponse = CType(httpReq.GetResponse(), HttpWebResponse)
        
 If httpRes.StatusCode = HttpStatusCode.Moved Then
     ' Code for moved resources goes here.
 End If

 httpRes.Close()
