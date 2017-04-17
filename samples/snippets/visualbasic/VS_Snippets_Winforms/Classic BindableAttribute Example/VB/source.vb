Imports System
Imports System.ComponentModel
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    <Bindable(True)> _
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
    
    Public Property MyProperty2() As Integer
        Get
            ' <Snippet2>
            ' Gets the attributes for the property.
            Dim attributes As AttributeCollection = _
                TypeDescriptor.GetProperties(Me)("MyProperty").Attributes
            
            ' Checks to see if the value of the BindableAttribute is Yes.
            If attributes(GetType(BindableAttribute)).Equals(BindableAttribute.Yes) Then
                ' Insert code here.
            End If 
            
            ' This is another way to see whether the property is bindable.
            Dim myAttribute As BindableAttribute = _
                CType(attributes(GetType(BindableAttribute)), BindableAttribute)
            If myAttribute.Bindable Then
                ' Insert code here.
            End If 

 	    ' Yet another way to see whether the property is bindable.
	    If attributes.Contains(BindableAttribute.Yes) Then
		' Insert code here.
	    End If

            ' </Snippet2> 
            Return 0
        End Get
        Set
            ' Insert code here.
        End Set 
    End Property
    
    Public Property MyProperty3() As Integer
        Get
            ' <Snippet3>
            Dim attributes As AttributeCollection = TypeDescriptor.GetAttributes(MyProperty)
            If attributes(GetType(BindableAttribute)).Equals(BindableAttribute.Yes) Then
                ' Insert code here.
            End If 
            ' </Snippet3>
            Return 0
        End Get
        Set
            ' Insert code here.
        End Set 
    End Property
End Class 'Form1

