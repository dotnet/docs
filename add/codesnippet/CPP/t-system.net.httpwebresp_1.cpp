      HttpWebRequest^ HttpWReq = dynamic_cast<HttpWebRequest^>(WebRequest::Create( "http://www.contoso.com" ));
      HttpWebResponse^ HttpWResp = dynamic_cast<HttpWebResponse^>(HttpWReq->GetResponse());
      
      // Insert code that uses the response object.
      HttpWResp->Close();