    ' When the SOAP extension is accessed for the first time, 
    ' cache the file name passed in by the SoapExtensionAttribute.

    Public Overloads Overrides Function GetInitializer( _
        methodInfo As LogicalMethodInfo, _
        attribute As SoapExtensionAttribute) As Object    
        Return CType(attribute, TraceExtensionAttribute).Filename
    End Function