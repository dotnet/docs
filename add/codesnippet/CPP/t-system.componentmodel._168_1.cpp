         UInt64 myUInt64(123456789123);
         String^ myUInt64String = "184467440737095551";
         Console::WriteLine( TypeDescriptor::GetConverter( myUInt64 )->ConvertTo( myUInt64, String::typeid ) );
         Console::WriteLine( TypeDescriptor::GetConverter( myUInt64 )->ConvertFrom( myUInt64String ) );