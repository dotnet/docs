   // Register a specific type with the SoapType attribute.
   Type^ exampleType = ExampleNamespace::ExampleClass::typeid;
   SoapServices::PreLoad( exampleType );