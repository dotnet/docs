Imports System
Imports System.Windows.Forms
Imports System.ComponentModel



Public Class Form1
    Inherits Form
    Protected button1 As Button
    Protected textBox1 As TextBox
    
    
    ' <Snippet1>
    Private Sub ContainsAttribute()
        ' Creates a new collection and assigns it the attributes for button1.
        Dim attributes As AttributeCollection
        attributes = TypeDescriptor.GetAttributes(button1)
        
        ' Sets an Attribute to the specific attribute.
        Dim myAttribute As BrowsableAttribute = BrowsableAttribute.Yes
        
        If attributes.Contains(myAttribute) Then
            textBox1.Text = "button1 has a browsable attribute."
        Else
            textBox1.Text = "button1 does not have a browsable attribute."
        End If
    End Sub 'ContainsAttribute
     ' </Snippet1>
    ' <Snippet2>
    Private Sub GetAttributeValue()
        ' Creates a new collection and assigns it the attributes for button1.
        Dim attributes As AttributeCollection
        attributes = TypeDescriptor.GetAttributes(button1)
        
        ' Gets the designer attribute from the collection.
        Dim myDesigner As DesignerAttribute
        myDesigner = CType(attributes(GetType(DesignerAttribute)), DesignerAttribute)
        
        ' Prints the value of the attribute in a text box.
        textBox1.Text = myDesigner.DesignerTypeName
    End Sub 'GetAttributeValue
    ' </Snippet2>
End Class 'Form1 
