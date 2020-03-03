Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms


Public Class Form1
    Inherits Form
    ' <Snippet1>

    Private _myVar As Boolean = False

    <DefaultValue(False)>
    Public Property MyProperty() As Boolean
        Get
            Return _myVar
        End Get
        Set
            _myVar = Value
        End Set
    End Property

    ' </Snippet1>
    Protected Sub Method()
        ' <Snippet2>
        ' Gets the attributes for the property.
        Dim attributes As AttributeCollection =
                TypeDescriptor.GetProperties(Me)("MyProperty").Attributes

        ' Prints the default value by retrieving the DefaultValueAttribute
        ' from the AttributeCollection. 
        Dim myAttribute As DefaultValueAttribute =
                CType(attributes(GetType(DefaultValueAttribute)), DefaultValueAttribute)
        Console.WriteLine(("The default value is: " & myAttribute.Value.ToString()))
        ' </Snippet2>
    End Sub
End Class
