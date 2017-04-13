Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    Protected image1 As Image
    ' <Snippet1>
    <Description("The image associated with the control"), _
        Category("Appearance")> _
    Public Property MyImage() As Image
        
        Get
            ' Insert code here.
            Return image1
        End Get
        Set
            ' Insert code here.
        End Set 
    End Property
    
    ' </Snippet1>
    Public Sub MyMethod()
        ' <Snippet2>
        ' Gets the attributes for the property.
        Dim attributes As AttributeCollection = _
            TypeDescriptor.GetProperties(Me)("MyImage").Attributes
        
        ' Prints the description by retrieving the CategoryAttribute. 
        ' from the AttributeCollection.
        Dim myAttribute As CategoryAttribute = _
            CType(attributes(GetType(CategoryAttribute)), CategoryAttribute)
            Console.WriteLine(myAttribute.Category)
        ' </Snippet2>
    End Sub 'MyMethod 
End Class 'Form1
