    // The extension was configured to run using a configuration file instead of an attribute applied to a 
    // specific XML Web service method. Return a file name based on the class implementing the XML Web service's type.
    public override object GetInitializer(Type WebServiceType) 
	{
	   // Return a file name to log the trace information to based on the passed in type.
	   return "C:\\" + WebServiceType.FullName + ".log";    
    }