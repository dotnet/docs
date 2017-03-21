 Dim HttpWReq As HttpWebRequest = _
    CType(WebRequest.Create("http://www.contoso.com"), HttpWebRequest)
        
 Dim HttpWResp As HttpWebResponse = _
    CType(HttpWReq.GetResponse(), HttpWebResponse)
 ' Insert code that uses the response object.
 HttpWResp.Close()