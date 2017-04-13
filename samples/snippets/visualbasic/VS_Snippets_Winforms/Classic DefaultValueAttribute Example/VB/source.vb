Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    ' <Snippet1>
    
    Private MyVar as Boolean = False
    <DefaultValue(False)> _
    Public Property MyProperty() As Boolean
        Get
            Return MyVar
        End Get
        Set
            MyVar = Value
        End Set 
    End Property

    ' </Snippet1>
    Protected Sub Method()
        ' <Snippet2>
        ' Gets the attributes for the property.
        Dim attributes As AttributeCollection = _
            TypeDescriptor.GetProperties(Me)("MyProperty").Attributes
        
        ' Prints the default value by retrieving the DefaultValueAttribute
        ' from the AttributeCollection. 
        Dim myAttribute As DefaultValueAttribute = _
            CType(attributes(GetType(DefaultValueAttribute)), DefaultValueAttribute)
        Console.WriteLine(("The default value is: " & myAttribute.Value.ToString()))
        ' </Snippet2>
    End Sub 'Method 
End Class 'Form1
