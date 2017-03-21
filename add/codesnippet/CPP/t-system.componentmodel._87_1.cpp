         char chrA('a');
         String^ strB = "b";
         Console::WriteLine( TypeDescriptor::GetConverter( chrA )->ConvertTo( chrA, String::typeid ) );
         Console::WriteLine( TypeDescriptor::GetConverter( chrA )->ConvertFrom( strB ) );