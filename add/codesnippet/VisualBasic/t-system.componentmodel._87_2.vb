    Public Shared Function Main() As Integer
        ' Creates a new component.
        Dim myNewControl As New MyControl()
        
        ' Gets the attributes for the component.
        Dim attributes As AttributeCollection = TypeDescriptor.GetAttributes(myNewControl)
        
        ' Prints the name of the license provider by retrieving the LicenseProviderAttribute 
        ' from the AttributeCollection. 
        Dim myAttribute As LicenseProviderAttribute = _
            CType(attributes(GetType(LicenseProviderAttribute)), LicenseProviderAttribute)
            
        Console.WriteLine(("The license provider for this class is: " & _
            myAttribute.LicenseProvider.ToString()))
        Return 0
    End Function