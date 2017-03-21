   // The extension was configured to run using a configuration file instead of an attribute applied to a 
   // specific XML Web service method. Return a file name based on the class implementing the XML Web service's type.
public:
   virtual Object^ GetInitializer( Type^ WebServiceType ) override
   {
      // Return a file name to log the trace information to based on the passed in type.
      return String::Format( "C:\\{0}.log", WebServiceType->FullName );
   }