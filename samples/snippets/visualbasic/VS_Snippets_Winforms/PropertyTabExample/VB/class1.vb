 '<Snippet1>
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.IO
Imports System.Reflection
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

' This component adds a TypeCategoryTab to the property browser
' that is available for any components in the current design mode document.
<PropertyTabAttribute(GetType(TypeCategoryTab), PropertyTabScope.Document)>  _
Public Class TypeCategoryTabComponent
   Inherits System.ComponentModel.Component
   
   Public Sub New()
    End Sub
End Class

' A TypeCategoryTab property tab lists properties by the 
' category of the type of each property.
<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
Public Class TypeCategoryTab
    Inherits PropertyTab

    ' This string contains a Base-64 encoded and serialized example property tab image.
    <BrowsableAttribute(True)> _
    Private img As String = "AAEAAAD/////AQAAAAAAAAAMAgAAAFRTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0xLjAuMzMwMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAA9gAAAAJCTfYAAAAAAAAANgAAACgAAAAIAAAACAAAAAEAGAAAAAAAAAAAAMQOAADEDgAAAAAAAAAAAAD///////////////////////////////////9ZgABZgADzPz/zPz/zPz9AgP//////////gAD/gAD/AAD/AAD/AACKyub///////+AAACAAAAAAP8AAP8AAP9AgP////////9ZgABZgABz13hz13hz13hAgP//////////gAD/gACA/wCA/wCA/wAA//////////+AAACAAAAAAP8AAP8AAP9AgP////////////////////////////////////8L"

    Public Sub New()
    End Sub

    '<Snippet2>
    ' Returns the properties of the specified component extended with 
    ' a CategoryAttribute reflecting the name of the type of the property.
    Public Overloads Overrides Function GetProperties(ByVal component As Object, ByVal attributes() As System.Attribute) As System.ComponentModel.PropertyDescriptorCollection
        Dim props As PropertyDescriptorCollection
        If attributes Is Nothing Then
            props = TypeDescriptor.GetProperties(component)
        Else
            props = TypeDescriptor.GetProperties(component, attributes)
        End If
        Dim propArray(props.Count - 1) As PropertyDescriptor
        Dim i As Integer
        For i = 0 To props.Count - 1
            ' Create a new PropertyDescriptor from the old one, with 
            ' a CategoryAttribute matching the name of the type.
            propArray(i) = TypeDescriptor.CreateProperty(props(i).ComponentType, props(i), New CategoryAttribute(props(i).PropertyType.Name))
        Next i
        Return New PropertyDescriptorCollection(propArray)
    End Function

    Public Overloads Overrides Function GetProperties(ByVal component As Object) As System.ComponentModel.PropertyDescriptorCollection
        Return Me.GetProperties(component, Nothing)
    End Function
    '</Snippet2>

    ' Provides the name for the property tab.
    Public Overrides ReadOnly Property TabName() As String
        Get
            Return "Properties by Type"
        End Get
    End Property

    ' Provides an image for the property tab.
    Public Overrides ReadOnly Property Bitmap() As System.Drawing.Bitmap
        Get
            Dim bmp As New Bitmap(DeserializeFromBase64Text(img))
            Return bmp
        End Get
    End Property

    ' This method can be used to retrieve an Image from a block of Base64-encoded text.
    Private Function DeserializeFromBase64Text(ByVal [text] As String) As Image
        Dim img As Image = Nothing
        Dim memBytes As Byte() = Convert.FromBase64String([text])
        Dim formatter As New BinaryFormatter()
        Dim stream As New MemoryStream(memBytes)
        img = CType(formatter.Deserialize(stream), Image)
        stream.Close()
        Return img
    End Function
End Class
'</Snippet1>