      Uri^ myUri = gcnew Uri( "http://www.contoso.com/" );
      ServicePoint^ mySP = ServicePointManager::FindServicePoint( myUri );