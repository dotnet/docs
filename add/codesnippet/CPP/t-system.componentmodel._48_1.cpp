         Decimal myDec(40);
         String^ myDStr = "20";
         Console::WriteLine( TypeDescriptor::GetConverter( myDec )->ConvertTo( myDec, String::typeid ) );
         Console::WriteLine( TypeDescriptor::GetConverter( myDec )->ConvertFrom( myDStr ) );