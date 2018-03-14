Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    
    ' <Snippet2>
    Public Shared Function Main() As Integer
        ' Creates a new control.
        Dim myNewControl As New MyControl()
        
        ' Gets the attributes for the collection.
        Dim attributes As AttributeCollection = TypeDescriptor.GetAttributes(myNewControl)
        
        ' Prints the name of the default property by retrieving the
        ' DefaultPropertyAttribute from the AttributeCollection. 
        Dim myAttribute As DefaultPropertyAttribute = _
            CType(attributes(GetType(DefaultPropertyAttribute)), DefaultPropertyAttribute)
        Console.WriteLine(("The default property is: " + myAttribute.Name))
        Return 0
    End Function 'Main
    
    ' </Snippet2>
    ' <Snippet1>
    <DefaultProperty("MyProperty")> _
    Public Class MyControl
        Inherits Control

        Public Property MyProperty() As Integer
            Get
                ' Insert code here.
                Return 0
            End Get
            Set
                ' Insert code here.
            End Set 
        End Property
        ' Insert any additional code.
    End Class 'MyControl
    ' </Snippet1>
End Class 'Form1 


