         TimeSpan ts(133333330);
         String^ myTSStr = "5000000";
         Console::WriteLine( TypeDescriptor::GetConverter( ts )->ConvertTo( ts, String::typeid ) );
         Console::WriteLine( TypeDescriptor::GetConverter( ts )->ConvertFrom( myTSStr ) );