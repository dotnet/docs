Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    
    Protected Sub Method()
        ' <Snippet1>
        ' Gets the attributes for the property.
        Dim attributes As AttributeCollection = _
            TypeDescriptor.GetProperties(Me)("MyProperty").Attributes
        
        ' Checks to see if the value of the DesignerSerializationVisibilityAttribute
        ' is set to Content.
        If attributes(GetType(DesignerSerializationVisibilityAttribute)).Equals( _
            DesignerSerializationVisibilityAttribute.Content) Then
            ' Insert code here.
        End If 
        
        ' This is another way to see whether the property is marked as serializing content.
        Dim myAttribute As DesignerSerializationVisibilityAttribute = _
            CType(attributes(GetType(DesignerSerializationVisibilityAttribute)), _
            DesignerSerializationVisibilityAttribute)
        If myAttribute.Visibility = DesignerSerializationVisibility.Content Then
            ' Insert code here.
        End If 
        ' </Snippet1>
    End Sub 'Method
End Class 'Form1 

