         char testChar = 'e';
         if ( Uri::IsHexDigit( testChar ) == true )
         {
            Console::WriteLine( "'{0}' is the hexadecimal representation of {1}",
               testChar, Uri::FromHex( testChar ) );
         }
         else
         {
            Console::WriteLine( "'{0}' is not a hex character", testChar );
         }

         String^ returnString = Uri::HexEscape( testChar );
         Console::WriteLine( "The hexadecimal value of '{0}' is {1}", testChar, returnString );