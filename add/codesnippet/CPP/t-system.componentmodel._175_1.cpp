         Byte myUint(5);
         String^ myUStr = "2";
         Console::WriteLine( TypeDescriptor::GetConverter( myUint )->ConvertTo( myUint, String::typeid ) );
         Console::WriteLine( TypeDescriptor::GetConverter( myUint )->ConvertFrom( myUStr ) );