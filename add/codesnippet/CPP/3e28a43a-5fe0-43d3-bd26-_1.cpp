public:
   // When the SOAP extension is accessed for the first time, cache the 
   // file name passed in by the SoapExtensionAttribute.    
   virtual Object^ GetInitializer( LogicalMethodInfo^ /*methodInfo*/, SoapExtensionAttribute^ attribute ) override
   {
      return (dynamic_cast<TraceExtensionAttribute^>(attribute))->Filename;
   }