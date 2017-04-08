Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    
    ' <Snippet1>
    <RecommendedAsConfigurable(True)> _
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
        
        ' Checks to see if the value of the RecommendedAsConfigurableAttribute is Yes.
        If attributes(GetType(RecommendedAsConfigurableAttribute)).Equals(RecommendedAsConfigurableAttribute.Yes) Then
            ' Insert code here.
        End If 
        
        ' This is another way to see if the property is recommended as configurable.
        Dim myAttribute As RecommendedAsConfigurableAttribute = _
            CType(attributes(GetType(RecommendedAsConfigurableAttribute)), RecommendedAsConfigurableAttribute)
        If myAttribute.RecommendedAsConfigurable Then
            ' Insert code here.
        End If
        ' </Snippet2>
    End Sub 'Method1
    
    
    
    Public Sub Method2()
        ' <Snippet3>
        Dim attributes As AttributeCollection = TypeDescriptor.GetAttributes(MyProperty)
        If attributes(GetType(RecommendedAsConfigurableAttribute)).Equals(RecommendedAsConfigurableAttribute.Yes) Then
            ' Insert code here.
        End If 
        ' </Snippet3>
    End Sub 'Method2
End Class 'Form1 
