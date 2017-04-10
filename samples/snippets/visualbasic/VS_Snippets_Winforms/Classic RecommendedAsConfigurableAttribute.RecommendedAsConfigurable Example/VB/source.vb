Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox   
    
    Public Sub Method()
' <Snippet1>
 ' Gets the attributes for the property.
 Dim attributes As AttributeCollection = _
    TypeDescriptor.GetProperties(Me)("MyProperty").Attributes
        
 ' Checks to see if the property is recommended as configurable.
 Dim myAttribute As RecommendedAsConfigurableAttribute = _
    CType(attributes(GetType(RecommendedAsConfigurableAttribute)), _
    RecommendedAsConfigurableAttribute)
    
 If myAttribute.RecommendedAsConfigurable Then
     ' Insert code here.
 End If

' </Snippet1>
    End Sub
End Class

