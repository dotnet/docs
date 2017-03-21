      WebProxy^ proxyObject = gcnew WebProxy( "http://proxyserver:80/",true );
      WebRequest^ req = WebRequest::Create( "http://www.contoso.com" );
      req->Proxy = proxyObject;