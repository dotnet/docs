'<Snippet1>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Drawing.Design
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

' This component obtains the IPropertyValueUIService and adds a
' PropertyValueUIHandler that provides PropertyValueUIItem objects
' which provide an image, tooltip and invoke event handler to
' any properties named HorizontalMargin and VerticalMargin, 
' such as the example integer properties on this component.    
Public Class PropertyUIComponent
    Inherits System.ComponentModel.Component

    ' Example property for which to provide PropertyValueUIItem.
    Public Property HorizontalMargin() As Integer
        Get
            Return hMargin
        End Get
        Set(ByVal Value As Integer)
            hMargin = Value
        End Set
    End Property

    ' Example property for which to provide PropertyValueUIItem.       
    Public Property VerticalMargin() As Integer
        Get
            Return vMargin
        End Get
        Set(ByVal Value As Integer)
            vMargin = Value
        End Set
    End Property

    ' Field storing the value of the HorizontalMargin property
    Private hMargin As Integer

    ' Field storing the value of the VerticalMargin property
    Private vMargin As Integer

    ' Base64-encoded serialized image data for image icon.
    Private imageBlob1 As String = "AAEAAAD/////AQAAAAAAAAAMAgAAAFRTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0xLjAuMzMwMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAA9gAAAAJCTfYAAAAAAAAANgAAACgAAAAIAAAACAAAAAEAGAAAAAAAAAAAAMQOAADEDgAAAAAAAAAAAAD///////////////////////////////////8AAAD///////////////8AAAD///////8AAAD///////////////8AAAD///////8AAAD///8AAAAAAAD///8AAAD///////8AAAD///8AAAAAAAD///8AAAD///////8AAAD///////////////8AAAD///////8AAAD///////////////8AAAD///////////////////////////////////8L"

    ' Constructor.
    Public Sub New(ByVal container As System.ComponentModel.IContainer)
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If
        hMargin = 0
        vMargin = 0
    End Sub

    ' Default component constructor that specifies no container.
    Public Sub New()
        MyClass.New(Nothing)
    End Sub

'<Snippet2>
    ' PropertyValueUIHandler delegate that provides PropertyValueUIItem
    ' objects to any properties named HorizontalMargin or VerticalMargin.
    Private Sub marginPropertyValueUIHandler(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal propDesc As System.ComponentModel.PropertyDescriptor, ByVal itemList As ArrayList)
        ' A PropertyValueUIHandler added to the IPropertyValueUIService
        ' is queried once for each property of a component and passed
        ' a PropertyDescriptor that represents the characteristics of 
        ' the property when the Properties window is set to a new 
        ' component. A PropertyValueUIHandler can determine whether 
        ' to add a PropertyValueUIItem for the object to its ValueUIItem 
        ' list depending on the values of the PropertyDescriptor.
        If propDesc.DisplayName.Equals("HorizontalMargin") Then
            Dim img As Image = DeserializeFromBase64Text(imageBlob1)
            itemList.Add(New PropertyValueUIItem(img, New PropertyValueUIItemInvokeHandler(AddressOf Me.marginInvoke), "Test ToolTip"))
        End If
        If propDesc.DisplayName.Equals("VerticalMargin") Then
            Dim img As Image = DeserializeFromBase64Text(imageBlob1)
            img.RotateFlip(RotateFlipType.Rotate90FlipNone)
            itemList.Add(New PropertyValueUIItem(img, New PropertyValueUIItemInvokeHandler(AddressOf Me.marginInvoke), "Test ToolTip"))
        End If
    End Sub
'</Snippet2>

    ' Invoke handler associated with the PropertyValueUIItem objects 
    ' provided by the marginPropertyValueUIHandler.
    Private Sub marginInvoke(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal propDesc As System.ComponentModel.PropertyDescriptor, ByVal item As PropertyValueUIItem)
        MessageBox.Show("Test invoke message box")
    End Sub

    ' Component.Site override to add the marginPropertyValueUIHandler
    ' when the component is sited, and to remove it when the site is 
    ' set to null.
    Public Overrides Property Site() As System.ComponentModel.ISite
        Get
            Return MyBase.Site
        End Get
        Set(ByVal Value As System.ComponentModel.ISite)
            If (Value IsNot Nothing) Then
                MyBase.Site = Value
                Dim uiService As IPropertyValueUIService = CType(Me.GetService(GetType(IPropertyValueUIService)), IPropertyValueUIService)
                If (uiService IsNot Nothing) Then
                    uiService.AddPropertyValueUIHandler(New PropertyValueUIHandler(AddressOf Me.marginPropertyValueUIHandler))
                End If
            Else
                Dim uiService As IPropertyValueUIService = CType(Me.GetService(GetType(IPropertyValueUIService)), IPropertyValueUIService)
                If (uiService IsNot Nothing) Then
                    uiService.RemovePropertyValueUIHandler(New PropertyValueUIHandler(AddressOf Me.marginPropertyValueUIHandler))
                End If
                MyBase.Site = Value
            End If
        End Set
    End Property

    ' This method can be used to retrieve an Image from a block 
    ' of Base64-encoded text.
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