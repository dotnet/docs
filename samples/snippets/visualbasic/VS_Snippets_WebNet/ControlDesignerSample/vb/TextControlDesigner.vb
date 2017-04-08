'<Snippet1>
Imports Microsoft.VisualBasic
Imports System.Web.UI
Imports System.Web.UI.Design
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports System.ComponentModel.Design

Namespace ASPNet.Design.Samples.VB

    ' Simple text Web control renders a text string.
    ' This control is associated with the TextSizeWebControlDesigner.
    <DesignerAttribute(GetType(TextSizeWebControlDesigner)), _
        ToolboxData("<{0}:TextControl runat='server'></{0}:TextControl>")> _
    Public Class TextControl
        Inherits Label

        Private _largeText As Boolean = True

        ' Constructor
        Public Sub New()
            Text = "Test Phrase"
            SetSize()
        End Sub

        ' Determines whether the text is large or small
        <Bindable(True), Category("Appearance"), DefaultValue(True)> _
        Public Property LargeText() As Boolean
            Get
                Return _largeText
            End Get
            Set(ByVal value As Boolean)
                _largeText = value
                SetSize()
            End Set
        End Property

        ' Applies the LargeText property to the control
        Private Sub SetSize()
            If LargeText Then
                Me.Font.Size = FontUnit.XLarge
            Else
                Me.Font.Size = FontUnit.Small
            End If
        End Sub
    End Class


    ' This control designer offers DesignerActionList commands
    ' that can alter the design time html of the associated control.
    Public Class TextSizeWebControlDesigner
        Inherits ControlDesigner

        Private _actionLists As DesignerActionListCollection

        ' Do not allow direct resizing of the control
        Public Overrides ReadOnly Property AllowResize() As Boolean
            Get
                Return False
            End Get
        End Property

        ' Return a custom ActionList collection
        Public Overrides ReadOnly Property ActionLists() As System.ComponentModel.Design.DesignerActionListCollection
            Get
                If IsNothing(_actionLists) Then
                    _actionLists = New DesignerActionListCollection()
                    _actionLists.AddRange(MyBase.ActionLists)

                    ' Add a custom DesignerActionList
                    _actionLists.Add(New ActionList(Me))
                End If

                Return _actionLists
            End Get
        End Property

        '<Snippet2>
        ' Create a custom class of DesignerActionList
        Public Class ActionList
            Inherits DesignerActionList
            Private _parent As TextSizeWebControlDesigner
            Private _items As DesignerActionItemCollection

            ' Constructor
            Public Sub New(ByRef parent As TextSizeWebControlDesigner)
                MyBase.New(parent.Component)
                _parent = parent
            End Sub

            ' Create the ActionItem collection and add one command
            Public Overrides Function GetSortedActionItems() As DesignerActionItemCollection
                If IsNothing(_items) Then
                    _items = New DesignerActionItemCollection()
                    _items.Add(New DesignerActionMethodItem(Me, "ToggleLargeText", "Toggle Text Size", True))
                End If

                Return _items
            End Function

            ' ActionList command to change the text size
            Private Sub ToggleLargeText()
                ' Get a reference to the parent designer's associated control
                Dim ctl As TextControl = CType(_parent.Component, TextControl)

                ' Get a reference to the control's LargeText property
                Dim propDesc As PropertyDescriptor = TypeDescriptor.GetProperties(ctl)("LargeText")

                ' Get the current value of the property
                Dim v As Boolean = CType(propDesc.GetValue(ctl), Boolean)
                ' Toggle the property value
                propDesc.SetValue(ctl, (Not v))
            End Sub
        End Class
        '</Snippet2>
    End Class
End Namespace
'</Snippet1>