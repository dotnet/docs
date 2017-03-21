      Uri^ proxyURI = gcnew Uri( "http://webproxy:80" );
      GlobalProxySelection::Select = gcnew WebProxy( proxyURI );