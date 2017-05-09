Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms


Public Class Form1
    Inherits Form
    
    Protected Sub Method()
' <Snippet1>
 ' Gets the attributes for the property.
 Dim attributes As AttributeCollection = _
    TypeDescriptor.GetProperties(Me)("MyPropertyProperty").Attributes
        
 ' Checks to see if the property is bindable.
 Dim myAttribute As MergablePropertyAttribute = _
    CType(attributes(GetType(MergablePropertyAttribute)), _
    MergablePropertyAttribute)
 If myAttribute.AllowMerge Then
     ' Insert code here.
 End If

' </Snippet1>
    End Sub
End Class

