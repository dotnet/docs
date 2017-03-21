         bool bVal(true);
         String^ strA = "false";
         Console::WriteLine( TypeDescriptor::GetConverter( bVal )->ConvertTo( bVal, String::typeid ) );
         Console::WriteLine( TypeDescriptor::GetConverter( bVal )->ConvertFrom( strA ) );