Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms



Public Class Class1
    
    ' <Snippet1>
    <LicenseProvider(GetType(LicFileLicenseProvider))> _
    Public Class MyControl
        Inherits Control
        
        ' Insert code here.
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            ' All components must dispose of the licenses they grant.
            ' Insert code here to dispose of the license.
        End Sub        

    End Class
    ' </Snippet1>

    ' <Snippet2>
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
    ' </Snippet2>

End Class
