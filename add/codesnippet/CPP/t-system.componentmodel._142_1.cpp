         double myDoub(100.55);
         String^ myDoStr = "4000.425";
         Console::WriteLine( TypeDescriptor::GetConverter( myDoub )->ConvertTo( myDoub, String::typeid ) );
         Console::WriteLine( TypeDescriptor::GetConverter( myDoub )->ConvertFrom( myDoStr ) );