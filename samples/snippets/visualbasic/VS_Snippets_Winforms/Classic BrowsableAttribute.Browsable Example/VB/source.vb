Option Explicit
Option Strict

Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    
    Protected Sub Method()
        ' <Snippet1>
        ' Gets the attributes for the property.
        Dim attributes As AttributeCollection = TypeDescriptor.GetProperties(Me)("MyProperty").Attributes
        
        ' Checks to see if the property is browsable.
        Dim myAttribute As BrowsableAttribute = CType(attributes(GetType(BrowsableAttribute)), BrowsableAttribute)
        If myAttribute.Browsable Then
            ' Insert code here.
        End If 
        ' </Snippet1>
    End Sub 'Method
End Class 'Form1 

