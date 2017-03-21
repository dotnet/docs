   // Read a ServiceDescription from existing WSDL.
   ServiceDescription^ myServiceDescription = ServiceDescription::Read( "Input_CS.wsdl" );
   myServiceDescription->TargetNamespace = "http://tempuri.org/";

   // Get the ServiceCollection of the ServiceDescription.
   ServiceCollection^ myServiceCollection = myServiceDescription->Services;

   // Remove the Service at index 0 of the collection.
   myServiceCollection->Remove( myServiceDescription->Services[ 0 ] );