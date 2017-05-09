 '<Snippet1>
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Security.Permissions
Imports System.Windows.Forms

' Component that adds a "Text" data format ToolboxItemCreatorCallback 
' to the Toolbox. This component uses a custom ToolboxItem that 
' creates a TextBox containing the text data.
<PermissionSetAttribute(SecurityAction.Demand, Name:="FullTrust")> _
Public Class TextDataTextBoxComponent
    Inherits System.ComponentModel.Component

    Private creatorAdded As Boolean = False
    Private ts As IToolboxService

    Public Sub New()
    End Sub

    ' ISite override to register TextBox creator
    Public Overrides Property Site() As System.ComponentModel.ISite
        Get
            Return MyBase.Site
        End Get
        Set(ByVal Value As System.ComponentModel.ISite)
            If (Value IsNot Nothing) Then
                MyBase.Site = Value
                If Not creatorAdded Then
                    AddTextTextBoxCreator()
                End If
            Else
                If creatorAdded Then
                    RemoveTextTextBoxCreator()
                End If
                MyBase.Site = Value
            End If
        End Set
    End Property

    ' Adds a "Text" data format creator to the toolbox that creates 
    ' a textbox from a text fragment pasted to the toolbox.
    Private Sub AddTextTextBoxCreator()
        ts = CType(GetService(GetType(IToolboxService)), IToolboxService)
        If (ts IsNot Nothing) Then
            Dim textCreator As _
            New ToolboxItemCreatorCallback(AddressOf Me.CreateTextBoxForText)
            Try
                ts.AddCreator( _
                textCreator, _
                "Text", _
                CType(GetService(GetType(IDesignerHost)), IDesignerHost))

                creatorAdded = True
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "Exception Information")
            End Try
        End If
    End Sub

    ' Removes any "Text" data format creator from the toolbox.
    Private Sub RemoveTextTextBoxCreator()
        If (ts IsNot Nothing) Then
            ts.RemoveCreator( _
            "Text", _
            CType(GetService(GetType(IDesignerHost)), IDesignerHost))
            creatorAdded = False
        End If
    End Sub

    ' ToolboxItemCreatorCallback delegate format method to create 
    ' the toolbox item.
    Private Function CreateTextBoxForText( _
    ByVal serializedObject As Object, _
    ByVal format As String) As ToolboxItem

        Dim o As New DataObject(CType(serializedObject, IDataObject))

        Dim formats As String() = o.GetFormats()

        If o.GetDataPresent("System.String", True) Then

            Return New TextToolboxItem(CStr(o.GetData("System.String", True)))

        End If

        Return Nothing
    End Function

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If creatorAdded Then
            RemoveTextTextBoxCreator()
        End If
    End Sub

End Class

' Custom toolbox item creates a TextBox and sets its Text property
' to the constructor-specified text.
<PermissionSetAttribute(SecurityAction.Demand, Name:="FullTrust")> _
Public Class TextToolboxItem
    Inherits System.Drawing.Design.ToolboxItem

    Private [text] As String

    Delegate Sub SetTextMethodHandler( _
    ByVal c As Control, _
    ByVal [text] As String)

    Public Sub New(ByVal [text] As String)
        Me.text = [text]
    End Sub

    ' ToolboxItem.CreateComponentsCore override to create the TextBox 
    ' and link a method to set its Text property.
    <PermissionSetAttribute(SecurityAction.Demand, Name:="FullTrust")> _
    Protected Overrides Function CreateComponentsCore(ByVal host As IDesignerHost) As IComponent()
        Dim textbox As TextBox = CType(host.CreateComponent(GetType(TextBox)), TextBox)

        ' Because the designer resets the text of the textbox, use 
        ' a SetTextMethodHandler to set the text to the value of 
        ' the text data.
        Dim c As Control = host.RootComponent

        c.BeginInvoke( _
        New SetTextMethodHandler(AddressOf OnSetText), _
        New Object() {textbox, [text]})

        Return New System.ComponentModel.IComponent() {textbox}
    End Function

    ' Method to set the text property of a TextBox after it is initialized.
    Private Sub OnSetText(ByVal c As Control, ByVal [text] As String)
        c.Text = [text]
    End Sub

End Class
'</Snippet1>
