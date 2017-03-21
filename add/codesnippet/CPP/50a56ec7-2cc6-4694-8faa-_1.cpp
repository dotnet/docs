      // Returns whether the specified name contains 
      // all valid character types.
      virtual bool IsValidName( String^ name )
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
                  return false;
            }
         }
         return true;
      }