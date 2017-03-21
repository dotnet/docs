         DateTime dt(1990,5,6);
         Console::WriteLine( TypeDescriptor::GetConverter( dt )->ConvertTo( dt, String::typeid ) );
         String^ myStr = "1991-10-10";
         Console::WriteLine( TypeDescriptor::GetConverter( dt )->ConvertFrom( myStr ) );