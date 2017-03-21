         short myInt16( -10000);
         String^ myInt16String = "+20000";
         Console::WriteLine( TypeDescriptor::GetConverter( myInt16 )->ConvertTo( myInt16, String::typeid ) );
         Console::WriteLine( TypeDescriptor::GetConverter( myInt16 )->ConvertFrom( myInt16String ) );