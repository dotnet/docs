Imports System
Imports System.ComponentModel


Public Class Class1
    ' <Snippet1>
    <Localizable(True)> _
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
    Public Sub Method1()
        ' <Snippet2>
        ' Gets the attributes for the property.
        Dim attributes As AttributeCollection = TypeDescriptor.GetProperties(Me)("MyProperty").Attributes
        
        ' Checks to see if the property needs to be localized.
        Dim myAttribute As LocalizableAttribute = CType(attributes(GetType(LocalizableAttribute)), LocalizableAttribute)
        If myAttribute.IsLocalizable Then
             ' Insert code here.
        End If
        ' </Snippet2>
    End Sub 'Method1
End Class 'Class1 
