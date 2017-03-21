         // Create some Uris.
         Uri^ address1 = gcnew Uri( "http://www.contoso.com/index.htm#search" );
         Uri^ address2 = gcnew Uri( "http://www.contoso.com/index.htm" );
         if ( address1->Equals( address2 ) )
         {
            Console::WriteLine( "The two addresses are equal" );
         }
         else
         {
            Console::WriteLine( "The two addresses are not equal" );
         }