   Uri^ baseUri = gcnew Uri( "http://www.contoso.com:8080/" );
   Uri^ myUri = gcnew Uri( baseUri,"shownew.htm?date=today" );
   Console::WriteLine( myUri->Authority );