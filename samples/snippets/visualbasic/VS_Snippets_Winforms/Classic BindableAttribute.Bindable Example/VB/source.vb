Imports System
Imports System.ComponentModel
Imports System.Security.Permissions
Imports System.Windows.Forms

Public Class Form1
 Inherits Form
 
 Protected textBox1 As TextBox
 
 <PermissionSet(SecurityAction.Demand)> _
 Protected Sub Method() 
' <Snippet1>
   ' Gets the attributes for the property.
   Dim attributes As AttributeCollection = _
      TypeDescriptor.GetProperties(Me)("MyProperty").Attributes
 
        ' Checks to see if the property is bindable.
        Dim myAttribute As BindableAttribute = _
        CType(attributes(System.Type.GetType("BindableAttribute")), BindableAttribute)
        If (myAttribute.Bindable) Then
            ' Insert code here.
        End If

' </Snippet1>
 End Sub
End Class
