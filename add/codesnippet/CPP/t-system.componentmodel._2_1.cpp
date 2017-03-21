         long myInt64( -123456789123);
         String^ myInt64String = "+184467440737095551";
         Console::WriteLine( TypeDescriptor::GetConverter( myInt64 )->ConvertTo( myInt64, String::typeid ) );
         Console::WriteLine( TypeDescriptor::GetConverter( myInt64 )->ConvertFrom( myInt64String ) );