      HttpWebRequest^ httpReq = dynamic_cast<HttpWebRequest^>(WebRequest::Create( "http://www.contoso.com" ));
      httpReq->AllowAutoRedirect = false;
      HttpWebResponse^ httpRes = dynamic_cast<HttpWebResponse^>(httpReq->GetResponse());
      if ( httpRes->StatusCode == HttpStatusCode::Moved )
      {
         // Code for moved resources goes here.
      }

      // Close the response.
      httpRes->Close();