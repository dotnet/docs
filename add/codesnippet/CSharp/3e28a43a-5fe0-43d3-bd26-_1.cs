    // When the SOAP extension is accessed for the first time, cache the 
    // file name passed in by the SoapExtensionAttribute.    
    public override object GetInitializer(LogicalMethodInfo methodInfo,
        SoapExtensionAttribute attribute) 
    {
        return ((TraceExtensionAttribute) attribute).Filename;
    }