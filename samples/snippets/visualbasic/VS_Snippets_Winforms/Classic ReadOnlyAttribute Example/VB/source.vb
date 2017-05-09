Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    ' <Snippet1>
    Public ReadOnly Property MyProperty() As Integer
        Get
            ' Insert code here.
            Return 0
        End Get
    End Property
    
    ' </Snippet1>
    Public Sub Method1()
        ' <Snippet2>
        ' Gets the attributes for the property.
        Dim attributes As AttributeCollection = _
            TypeDescriptor.GetProperties(Me)("MyProperty").Attributes
        
        ' Checks to see whether the value of the ReadOnlyAttribute is Yes.
        If attributes(GetType(ReadOnlyAttribute)).Equals(ReadOnlyAttribute.Yes) Then
            ' Insert code here.
        End If 
        
        ' This is another way to see whether the property is read-only.
        Dim myAttribute As ReadOnlyAttribute = _
            CType(attributes(GetType(ReadOnlyAttribute)), ReadOnlyAttribute)
            
        If myAttribute.IsReadOnly Then
            ' Insert code here.
        End If 
        ' </Snippet2>
    End Sub 'Method1
    
  
    
    Public Sub Method2()
        ' <Snippet3>
        Dim attributes As AttributeCollection = TypeDescriptor.GetAttributes(MyProperty)
        If attributes(GetType(ReadOnlyAttribute)).Equals(ReadOnlyAttribute.Yes) Then
            ' Insert code here.
        End If 
        ' </Snippet3>
    End Sub 'Method2
End Class 'Form1 
