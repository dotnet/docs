         unsigned int myUInt32(967299);
         String^ myUInt32String = "1345556";
         Console::WriteLine( TypeDescriptor::GetConverter( myUInt32 )->ConvertTo( myUInt32, String::typeid ) );
         Console::WriteLine( TypeDescriptor::GetConverter( myUInt32 )->ConvertFrom( myUInt32String ) );