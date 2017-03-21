         SByte mySByte( +121);
         String^ mySByteStr = "-100";
         Console::WriteLine( TypeDescriptor::GetConverter( mySByte )->ConvertTo( mySByte, String::typeid ) );
         Console::WriteLine( TypeDescriptor::GetConverter( mySByte )->ConvertFrom( mySByteStr ) );