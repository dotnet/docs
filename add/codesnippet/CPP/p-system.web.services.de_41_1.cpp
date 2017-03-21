   // Read a ServiceDescription from existing WSDL.
   ServiceDescription^ myServiceDescription = ServiceDescription::Read( "Input_CS.wsdl" );
   myServiceDescription->TargetNamespace = "http://tempuri.org/";