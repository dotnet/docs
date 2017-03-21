   Uri^ baseUri = gcnew Uri( "http://www.contoso.com/" );
   Uri^ myUri = gcnew Uri( baseUri, "catalog/shownew.htm?date=today" );

   Console::WriteLine( myUri->PathAndQuery );