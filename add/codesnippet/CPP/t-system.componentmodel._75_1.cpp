         unsigned short myUInt16(10000);
         String^ myUInt16String = "20000";
         Console::WriteLine( TypeDescriptor::GetConverter( myUInt16 )->ConvertTo( myUInt16, String::typeid ) );
         Console::WriteLine( TypeDescriptor::GetConverter( myUInt16 )->ConvertFrom( myUInt16String ) );