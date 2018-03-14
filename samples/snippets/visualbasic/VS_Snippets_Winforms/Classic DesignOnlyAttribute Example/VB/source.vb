Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Globalization

Public Class Class1
    Private myCultureInfo As CultureInfo
    ' <Snippet1>
    <DesignOnly(True)> _
    Public Property GetLanguage() As CultureInfo
        Get
            ' Insert code here.
            Return myCultureInfo
        End Get
        Set
            ' Insert code here.
        End Set
    End Property
    ' </Snippet1>
    
    Private ReadOnly Property Property1() As Integer
        Get
            ' <Snippet2>
            ' Gets the attributes for the property.
            Dim attributes As AttributeCollection = _
                TypeDescriptor.GetProperties(Me)("GetLanguage").Attributes
            
            ' Prints whether the property is marked as DesignOnly 
            ' by retrieving the DesignOnlyAttribute from the AttributeCollection.
            Dim myAttribute As DesignOnlyAttribute = _
                CType(attributes(GetType(DesignOnlyAttribute)), DesignOnlyAttribute)
            Console.WriteLine(("This property is design only :" & _
                myAttribute.IsDesignOnly.ToString()))
            ' </Snippet2>
            Return 1
        End Get
    End Property
End Class
