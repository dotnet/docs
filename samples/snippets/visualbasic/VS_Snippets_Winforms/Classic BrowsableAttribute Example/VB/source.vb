Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    ' <Snippet1>
    
    <Browsable(True)> _
    Public Property MyProperty() As Integer
        Get
            ' Insert code here.
            Return 0
        End Get
        Set
            ' Insert code here.
        End Set 
    End Property
    ' </Snippet1>
    
    Public ReadOnly Property MyProperty2() As Integer
        Get
            ' <Snippet2>
            ' Gets the attributes for the property.
            Dim attributes As AttributeCollection = _
                TypeDescriptor.GetProperties(Me)("MyProperty").Attributes
            
            ' Checks to see if the value of the BrowsableAttribute is Yes.
            If attributes(GetType(BrowsableAttribute)).Equals(BrowsableAttribute.Yes) Then
                ' Insert code here.
            End If 
            
            ' This is another way to see whether the property is browsable.
            Dim myAttribute As BrowsableAttribute = _
                CType(attributes(GetType(BrowsableAttribute)), BrowsableAttribute)
            If myAttribute.Browsable Then
                ' Insert code here.
            End If 
            ' </Snippet2>
            Return 0
        End Get
    End Property
    
    
    Public ReadOnly Property MyProperty3() As Integer
        Get
            ' <Snippet3>
            Dim attributes As AttributeCollection = TypeDescriptor.GetAttributes(MyProperty)
            If attributes(GetType(BrowsableAttribute)).Equals(BrowsableAttribute.Yes) Then
                ' Insert code here.
            End If 
            ' </Snippet3>
            Return 0
        End Get
    End Property
End Class 'Form1
