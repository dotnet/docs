         // Requires public declaration of the following type.
         // __value enum Servers {Windows=1, Exchange=2, BizTalk=3};
         Servers myServer = Servers::Exchange;
         String^ myServerString = "BizTalk";
         Console::WriteLine( TypeDescriptor::GetConverter( myServer )->ConvertTo( myServer, String::typeid ) );
         Console::WriteLine( TypeDescriptor::GetConverter( myServer )->ConvertFrom( myServerString ) );