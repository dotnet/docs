         int myInt32( -967299);
         String^ myInt32String = "+1345556";
         Console::WriteLine( TypeDescriptor::GetConverter( myInt32 )->ConvertTo( myInt32, String::typeid ) );
         Console::WriteLine( TypeDescriptor::GetConverter( myInt32 )->ConvertFrom( myInt32String ) );