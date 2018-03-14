 '<Snippet1>
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Collections
Imports System.Drawing
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

' This example demonstrates how to implement a component editor that hosts 
' component pages and associate it with a component. This example also 
' demonstrates how to implement a component page that provides a panel-based 
' control system and Help keyword support.
' The ExampleComponentEditor displays two ExampleComponentEditorPage pages.
Public Class ExampleComponentEditor
    Inherits System.Windows.Forms.Design.WindowsFormsComponentEditor

    '<Snippet2>
    ' This method override returns an type array containing the type of 
    ' each component editor page to display.
    Protected Overrides Function GetComponentEditorPages() As Type()
        Return New Type() {GetType(ExampleComponentEditorPage), GetType(ExampleComponentEditorPage)}
    End Function
    '</Snippet2>

    '<Snippet3>
    ' This method override returns the index of the page to display when the 
    ' component editor is first displayed.
    Protected Overrides Function GetInitialComponentEditorPageIndex() As Integer
        Return 1
    End Function
    '</Snippet3>

    Public Overloads Overrides Function EditComponent(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal component As Object) As Boolean

    End Function
End Class

'<Snippet6>
' This example component editor page type provides an example 
' ComponentEditorPage implementation.
Friend Class ExampleComponentEditorPage
    Inherits System.Windows.Forms.Design.ComponentEditorPage
    Private l1 As Label
    Private b1 As Button
    Private pg1 As PropertyGrid

    ' Base64-encoded serialized image data for the required component editor page icon.
    Private icondata As String = "AAEAAAD/////AQAAAAAAAAAMAgAAAFRTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0xLjAuNTAwMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABNTeXN0ZW0uRHJhd2luZy5JY29uAgAAAAhJY29uRGF0YQhJY29uU2l6ZQcEAhNTeXN0ZW0uRHJhd2luZy5TaXplAgAAAAIAAAAJAwAAAAX8////E1N5c3RlbS5EcmF3aW5nLlNpemUCAAAABXdpZHRoBmhlaWdodAAACAgCAAAAAAAAAAAAAAAPAwAAAD4BAAACAAABAAEAEBAQAAAAAAAoAQAAFgAAACgAAAAQAAAAIAAAAAEABAAAAAAAgAAAAAAAAAAAAAAAEAAAABAAAAAAAAAAAACAAACAAAAAgIAAgAAAAIAAgADExAAAgICAAMDAwAA+iPcAY77gACh9kwD/AAAAndPoADpw6wD///8AAAAAAAAAAAAHd3d3d3d3d8IiIiIiIiLHKIiIiIiIiCco///////4Jyj5mfIvIvgnKPnp////+Cco+en7u7v4Jyj56f////gnKPmZ8i8i+Cco///////4JyiIiIiIiIgnJmZmZmZmZifCIiIiIiIiwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACw=="

    Public Sub New()
        ' Initialize the page, which inherits from Panel, and its controls.
        Me.Size = New Size(400, 250)
        Me.Icon = DeserializeIconFromBase64Text(icondata)
        Me.Text = "Example Page"

        b1 = New Button
        b1.Size = New Size(200, 20)
        b1.Location = New Point(200, 0)
        b1.Text = "Set a random background color"
        AddHandler b1.Click, AddressOf Me.randomBackColor
        Me.Controls.Add(b1)

        l1 = New Label
        l1.Size = New Size(190, 20)
        l1.Location = New Point(4, 2)
        l1.Text = "Example Component Editor Page"
        Me.Controls.Add(l1)

        pg1 = New PropertyGrid
        pg1.Size = New Size(400, 280)
        pg1.Location = New Point(0, 30)
        Me.Controls.Add(pg1)
    End Sub

    ' This method indicates that the Help button should be enabled for this 
    ' component editor page.
    Public Overrides Function SupportsHelp() As Boolean
        Return True
    End Function

    '<Snippet4>
    ' This method is called when the Help button for this component editor page is pressed.
    ' This implementation uses the IHelpService to show the Help topic for a sample keyword.
    Public Overrides Sub ShowHelp()
        ' The GetSelectedComponent method of a ComponentEditorPage retrieves the
        ' IComponent associated with the WindowsFormsComponentEditor.
        Dim selectedComponent As IComponent = Me.GetSelectedComponent()

        ' Retrieve the Site of the component, and return if null.
        Dim componentSite As ISite = selectedComponent.Site
        If componentSite Is Nothing Then
            Return
        End If
        ' Acquire the IHelpService to display a help topic using a indexed keyword lookup.
        Dim helpService As IHelpService = CType(componentSite.GetService(GetType(IHelpService)), IHelpService)
        If (helpService IsNot Nothing) Then
            helpService.ShowHelpFromKeyword("System.Windows.Forms.ComboBox")
        End If
    End Sub
    '</Snippet4>

    ' The LoadComponent method is raised when the ComponentEditorPage is displayed.
    Protected Overrides Sub LoadComponent()
        Me.pg1.SelectedObject = Me.Component
    End Sub

    ' The SaveComponent method is raised when the WindowsFormsComponentEditor is closing 
    ' or the current ComponentEditorPage is closing.
    Protected Overrides Sub SaveComponent()
    End Sub

    ' If the associated component is a Control, this method sets the BackColor to a random color.
    ' This method is invoked by the button on this ComponentEditorPage.
    Private Sub randomBackColor(ByVal sender As Object, ByVal e As EventArgs)
        If GetType(System.Windows.Forms.Control).IsAssignableFrom(CType(Me.Component, Object).GetType()) Then
            ' Sets the background color of the Control associated with the
            ' WindowsFormsComponentEditor to a random color.
            Dim rnd As New Random
            CType(Me.Component, System.Windows.Forms.Control).BackColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255))
            pg1.Refresh()
        End If
    End Sub

    ' This method can be used to retrieve an Icon from a block 
    ' of Base64-encoded text.
    Private Function DeserializeIconFromBase64Text(ByVal [text] As String) As icon
        Dim img As Icon = Nothing
        Dim memBytes As Byte() = Convert.FromBase64String([text])
        Dim formatter As New BinaryFormatter
        Dim stream As New MemoryStream(memBytes)
        img = CType(formatter.Deserialize(stream), Icon)
        stream.Close()
        Return img
    End Function
End Class
'</Snippet6>

'<Snippet5>
' This example control is associated with the ExampleComponentEditor 
' through the following EditorAttribute.
<EditorAttribute(GetType(ExampleComponentEditor), GetType(ComponentEditor))> _
Public Class ExampleUserControl
    Inherits System.Windows.Forms.UserControl
End Class
'</Snippet5>
'</Snippet1>