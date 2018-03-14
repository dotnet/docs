'<Snippet1>
Imports Microsoft.VisualBasic
Imports System.Web
Imports System.Web.UI
Imports System.Drawing
Imports System.Collections
Imports System.Web.UI.WebControls
Imports System.Web.UI.Design
Imports System.ComponentModel
Imports System.ComponentModel.Design

Namespace ASPNet.Samples

    ' Create a custom control class with a Label and TextBox
    <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.InheritanceDemand, Name:="FullTrust")> _
    <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
    <Designer("ASPNet.Samples.SampleControlDesigner")> _
    Public Class SampleControl
        Inherits CompositeControl

        Dim defaultWidth As Integer = 150

        Public Sub New()

        End Sub

        ' Create a set of Public properties
        <Bindable(True), DefaultValue(""), _
            PersistenceMode(PersistenceMode.Attribute)> _
        Public Property LabelText() As String
            Get
                EnsureChildControls()
                Return MyLabel.Text
            End Get
            Set(ByVal value As String)
                EnsureChildControls()
                MyLabel.Text = value
            End Set
        End Property

        <Bindable(True), DefaultValue(""), _
            PersistenceMode(PersistenceMode.Attribute)> _
        Public Property BoxText() As String
            Get
                EnsureChildControls()
                Return MyTextBox.Text
            End Get
            Set(ByVal value As String)
                EnsureChildControls()
                MyTextBox.Text = value
            End Set
        End Property

        <Bindable(True), Category("Appearance"), _
            PersistenceMode(PersistenceMode.Attribute)> _
        Public Property BoxWidth() As Unit
            Get
                EnsureChildControls()
                Return MyTextBox.Width
            End Get
            Set(ByVal value As Unit)
                EnsureChildControls()
                MyTextBox.Width = value
            End Set
        End Property

        <Bindable(True), Category("Appearance"), _
            PersistenceMode(PersistenceMode.Attribute)> _
        Public Overrides Property BackColor() As Color
            Get
                EnsureChildControls()
                Return MyTextBox.BackColor()
            End Get
            Set(ByVal value As Color)
                EnsureChildControls()
                MyTextBox.BackColor = value
            End Set
        End Property

        ' Create private properties
        Private ReadOnly Property MyTextBox() As TextBox
            Get
                EnsureChildControls()
                Return CType(FindControl("MyTextBox"), TextBox)
            End Get
        End Property
        Private ReadOnly Property MyLabel() As Label
            Get
                EnsureChildControls()
                Return CType(FindControl("MyLabel"), Label)
            End Get
        End Property

        ' Create a Label and a TextBox
        Protected Overrides Sub CreateChildControls()
            Controls.Clear()
            MyBase.CreateChildControls()

            ' Create a Label control
            Dim localLabel As New Label()
            localLabel.ID = "MyLabel"
            localLabel.Text = localLabel.ID + ": "
            localLabel.EnableViewState = False
            Controls.Add(localLabel)

            ' Create a TextBox control
            Dim localTextBox As New TextBox()
            localTextBox.ID = "MyTextBox"
            localTextBox.Width = defaultWidth
            localTextBox.EnableViewState = False
            Controls.Add(localTextBox)
        End Sub
    End Class

    '-----------------------------------------------
    ' Create a designer class for the SampleControl
    <System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand, Flags:=System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)> _
    Public Class SampleControlDesigner
        Inherits ControlDesigner

        Private sampControl As SampleControl

        ' Constructor
        Public Sub New()
            MyBase.New()
        End Sub

        ' Do not allow resizing; force use of properties to set width
        Public Overrides ReadOnly Property AllowResize() As Boolean
            Get
                Return False
            End Get
        End Property

        '<Snippet2>
        ' Create a custom ActionLists collection
        Public Overrides ReadOnly Property ActionLists() As DesignerActionListCollection
            Get
                ' Create the collection
                Dim lists As New DesignerActionListCollection()

                ' Get the base items, if any
                lists.AddRange(MyBase.ActionLists)

                ' Add my own list of actions
                lists.Add(New CustomControlActionList(Me))

                Return lists
            End Get
        End Property
        '</Snippet2>

        ' Create an embedded DesignerActionList class
        Private Class CustomControlActionList
            Inherits DesignerActionList

            ' Create private fields
            Private _parent As SampleControlDesigner
            Private _items As DesignerActionItemCollection

            ' Constructor
            Public Sub New(ByVal parent As SampleControlDesigner)
                MyBase.New(parent.Component)
                _parent = parent
            End Sub

            ' Create a set of transacted callback methods
            ' Callback for a wide format
            Public Sub FormatWide()
                Dim ctrl As SampleControl = CType(_parent.Component, SampleControl)

                ' Create the callback
                Dim toCall As New TransactedChangeCallback(AddressOf DoFormat)
                ' Create the transacted change in the control
                ControlDesigner.InvokeTransactedChange(ctrl, toCall, "FormatWide", "Use a wide format")
            End Sub

            ' Callback for the medium format
            Public Sub FormatMedium()
                Dim ctrl As SampleControl = CType(_parent.Component, SampleControl)

                ' Create the callback
                Dim toCall As New TransactedChangeCallback(AddressOf DoFormat)
                ' Create the transacted change in the control
                ControlDesigner.InvokeTransactedChange(ctrl, toCall, "FormatMedium", "Use a medium format")
            End Sub

            ' Callback for the narrow format
            Public Sub FormatNarrow()
                Dim ctrl As SampleControl = CType(_parent.Component, SampleControl)

                ' Create the callback
                Dim toCall As New TransactedChangeCallback(AddressOf DoFormat)
                ' Create the transacted change in the control
                ControlDesigner.InvokeTransactedChange(ctrl, toCall, "FormatNarrow", "Use a narrow format")
            End Sub

            '<Snippet3>
            ' Get the sorted list of Action items
            Public Overrides Function GetSortedActionItems() As DesignerActionItemCollection
                If IsNothing(_items) Then
                    ' Create the collection
                    _items = New DesignerActionItemCollection()

                    ' Add a header to the list
                    _items.Add(New DesignerActionHeaderItem("Select a Style:"))

                    ' Add three commands
                    _items.Add(New DesignerActionMethodItem(Me, "FormatWide", "Format Wide", True))
                    _items.Add(New DesignerActionMethodItem(Me, "FormatMedium", "Format Medium", True))
                    _items.Add(New DesignerActionMethodItem(Me, "FormatNarrow", "Format Narrow", True))
                End If

                Return _items
            End Function
            '</Snippet3>

            ' Function for the callback to call
            Public Function DoFormat(ByVal arg As Object) As Boolean
                ' Get a reference to the designer's associated component
                Dim ctl As SampleControl = CType(_parent.ViewControl(), SampleControl)

                ' Get the format name from the arg
                Dim fmt As String = CType(arg, String)

                ' Create property descriptors
                Dim widthProp As PropertyDescriptor = TypeDescriptor.GetProperties(ctl)("BoxWidth")
                Dim backColorProp As PropertyDescriptor = TypeDescriptor.GetProperties(ctl)("BackColor")

                ' For the selected format, set two properties
                Select Case fmt
                    Case "FormatWide"
                        widthProp.SetValue(ctl, Unit.Pixel(250))
                        backColorProp.SetValue(ctl, Color.LightBlue)
                    Case "FormatNarrow"
                        widthProp.SetValue(ctl, Unit.Pixel(100))
                        backColorProp.SetValue(ctl, Color.LightCoral)
                    Case "FormatMedium"
                        widthProp.SetValue(ctl, Unit.Pixel(150))
                        backColorProp.SetValue(ctl, Color.White)
                End Select

                ' Return an indication of success
                Return True

            End Function
        End Class
    End Class

End Namespace
'</Snippet1>