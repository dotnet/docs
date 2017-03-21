   // Create some Uris.
   Uri^ address1 = gcnew Uri( "http://www.contoso.com/index.htm#search" );
   Uri^ address2 = gcnew Uri( "http://www.contoso.com/index.htm" );
   Uri^ address3 = gcnew Uri( "http://www.contoso.com/index.htm?date=today" );

   // The first two are equal because the fragment is ignored.
   if ( address1 == address2 )
      Console::WriteLine( "{0} is equal to {1}", address1, address2 );

   // The second two are not equal.
   if ( address2 != address3 )
      Console::WriteLine( "{0} is not equal to {1}", address2, address3 );