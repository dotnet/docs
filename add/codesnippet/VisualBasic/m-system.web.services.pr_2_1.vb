    ' The extension was configured to run using a configuration file instead of an attribute applied to a 
    ' specific XML Web service method.  Return a file name based on the class implementing the XML Web service's type.
    Public Overloads Overrides Function GetInitializer(WebServiceType As Type) As Object
	   ' Return a file name to log the trace information to based on the passed in type.
        Return "C:\" + WebServiceType.FullName + ".log"
    End Function