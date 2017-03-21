   Uri^ baseUri = gcnew Uri( "http://www.contoso.com/" );
   Uri^ myUri = gcnew Uri( baseUri,"Hello%20World.htm",false );