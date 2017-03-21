      // Throws an exception if the specified name does not contain 
      // all valid character types.
      virtual void ValidateName( String^ name )
      {
         for ( int i = 0; i < name->Length; i++ )
         {
            Char ch = name[ i ];
            UnicodeCategory uc = Char::GetUnicodeCategory( ch );
            switch ( uc )
            {
               case UnicodeCategory::UppercaseLetter:
               case UnicodeCategory::LowercaseLetter:
               case UnicodeCategory::TitlecaseLetter:
               case UnicodeCategory::DecimalDigitNumber:
                  break;

               default:
                  throw gcnew Exception( String::Format( "The name '{0}' is not a valid identifier.", name ) );
            }
         }
      }