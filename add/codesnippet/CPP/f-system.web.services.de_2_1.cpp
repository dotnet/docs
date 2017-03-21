      ServiceDescription^ myDescription = 
         ServiceDescription::Read( "MyWsdl_CS.wsdl" );
      Console::WriteLine( "Namespace : " + ServiceDescription::Namespace );