         Single s(3.402823E+10F);
         String^ mySStr = "3.402823E+10";
         Console::WriteLine( TypeDescriptor::GetConverter( s )->ConvertTo( s, String::typeid ) );
         Console::WriteLine( TypeDescriptor::GetConverter( s )->ConvertFrom( mySStr ) );