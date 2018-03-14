'<Snippet1>
Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Web.UI
Imports System.Web.UI.Design
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

Namespace ControlParserPersisterDesignerControl_VB

    ' Web control designer provides an interface 
    '   to use the ControlPersister and ControlParser.
    ' The DesignerActionListCollection must run under "FullTrust",
    '   so you must also require your designer to run under "FullTrust".
    <System.Security.Permissions.PermissionSetAttribute( _
        System.Security.Permissions.SecurityAction.InheritanceDemand, _
        Name:="FullTrust")> _
    <System.Security.Permissions.PermissionSetAttribute( _
         Security.Permissions.SecurityAction.Demand, _
         Name:="FullTrust")> _
    Public Class ControlParserPersisterDesigner
        Inherits System.Web.UI.Design.ControlDesigner

        Private _actLists As DesignerActionListCollection

        Public Sub New()
        End Sub

        ' Creates designer menu commands to persist 
        ' a control and to load a persisted control.
        Public Overrides ReadOnly Property ActionLists() As System.ComponentModel.Design.DesignerActionListCollection
            Get
                If IsNothing(_actLists) Then
                    _actLists = New DesignerActionListCollection()
                    _actLists.AddRange(MyBase.ActionLists)
                    _actLists.Add(New ParserActionList(Me))
                End If

                Return _actLists
            End Get
        End Property
        'Public Overrides ReadOnly Property Verbs() _
        'As System.ComponentModel.Design.DesignerVerbCollection
        '    Get
        '        Dim dvc As New DesignerVerbCollection()
        '        dvc.Add(New DesignerVerb("Load Persisted Control...", _
        '            New EventHandler(AddressOf Me.loadPersistedControl)))
        '        dvc.Add(New DesignerVerb("Parse and Save Control...", _
        '            New EventHandler(AddressOf Me.saveControl)))
        '        Return dvc
        '    End Get
        'End Property

        ' Displays a textbox form to receive an HTML 
        ' string that represents a control, and creates
        ' a toolbox item for the control, if not already
        ' present in the selected toolbox category.

        Private Class ParserActionList
            Inherits DesignerActionList

            Private _parent As ControlParserPersisterDesigner
            Private _items As DesignerActionItemCollection

            Public Sub New(ByVal parent As ControlParserPersisterDesigner)
                MyBase.New(parent.Component)
                _parent = parent
            End Sub

            Public Overrides Function GetSortedActionItems() As System.ComponentModel.Design.DesignerActionItemCollection
                If IsNothing(_items) Then
                    _items = New DesignerActionItemCollection()
                    _items.Add(New DesignerActionMethodItem(Me, "saveControl", "Parse and Save Control...", True))
                    _items.Add(New DesignerActionMethodItem(Me, "loadPersistedControl", "Load Persisted Control...", True))
                End If
                Return _items
            End Function

            ' Displays a list of controls in the project, if any,
            ' and displays the HTML markup for the selected control.       
            Private Sub saveControl()
                ' Get the collection of components in the current 
                ' design mode document.
                Dim documentComponents As ComponentCollection = _
                    Me.Component.Site.Container.Components

                ' Filter the components to those that derive from the 
                ' System.Web.UI.Control class.

                ' Create an IComponent array of the maximum possible length needed.
                Dim filterArray(documentComponents.Count) As IComponent

                ' Count the total qualifying components.
                Dim total As Integer = 0
                Dim i As Integer
                For i = 0 To documentComponents.Count - 1
                    ' If the component derives from System.Web.UI.Control, 
                    ' copy a reference to the control to the filterArray 
                    ' array and increment the control count.
                    If GetType(System.Web.UI.Control).IsAssignableFrom(CType(documentComponents(i), Object).GetType()) Then
                        If Not (CType(documentComponents(i), System.Web.UI.Control).UniqueID Is Nothing) Then
                            filterArray(total) = documentComponents(i)
                            total += 1
                        End If
                    End If
                Next i

                If total = 0 Then
                    Throw New Exception( _
                        "Document contains no System.Web.UI.Control components.")
                End If

                ' Move the components that derive from System.Web.UI.Control to a 
                ' new array of the correct size.
                Dim controlArray(total - 1) As System.Web.UI.Control

                For i = 0 To total - 1
                    controlArray(i) = CType(filterArray(i), System.Web.UI.Control)
                Next i

                ' Create a ControlSelectionForm to provide a persistence 
                ' configuration interface.
                Dim selectionForm As New ControlSelectionForm(controlArray)

                ' Display the form.
                If selectionForm.ShowDialog() <> DialogResult.OK Then
                    Return
                End If

                ' Validate the selection.
                If selectionForm.controlList.SelectedIndex = -1 Then
                    Throw New Exception("You must select a control to persist.")
                End If

                '<Snippet3>
                ' Parse the selected control.
                Dim persistedData As String = ControlPersister.PersistControl( _
                    controlArray(selectionForm.controlList.SelectedIndex))
                '</Snippet3>

                ' Display the control persistence string in a text box.
                Dim displayForm As New StringDisplayForm(persistedData)
                displayForm.ShowDialog()
            End Sub

            ' Displays a textbox form to receive an HTML 
            ' string that represents a control, and creates
            ' a toolbox item for the control, if not already
            ' present in the selected toolbox category.
            Private Sub loadPersistedControl()
                ' Display a StringInputForm to obtain a persisted control string.
                Dim inputForm As New StringInputForm()

                If inputForm.ShowDialog() <> DialogResult.OK Then
                    Return
                End If
                If inputForm.TxBox.Text.Length < 2 Then
                    Return
                End If
                ' Obtain an IDesignerHost for the design-mode document.
                Dim host As IDesignerHost = CType(Me.Component.Site.GetService(GetType(IDesignerHost)), IDesignerHost)

                '<Snippet2>
                ' Create a Web control from the persisted control string.
                Dim ctrl As System.Web.UI.Control = ControlParser.ParseControl(host, inputForm.TxBox.Text.Trim())
                '</Snippet2>

                ' Create a Web control toolbox item for the type of the control.
                Dim item As New System.Web.UI.Design.WebControlToolboxItem(ctrl.GetType())

                ' Add the Web control toolbox item to the toolbox.
                Dim toolService As IToolboxService = CType(Me.Component.Site.GetService(GetType(IToolboxService)), IToolboxService)
                If Not (toolService Is Nothing) Then
                    toolService.AddToolboxItem(item)
                Else
                    Throw New Exception("IToolboxService was not found.")
                End If
            End Sub
        End Class
    End Class

    ' Simple text display control hosts the ControlParserPersisterDesigner.
    <DesignerAttribute(GetType(ControlParserPersisterDesigner), _
        GetType(IDesigner))> _
    Public Class ControlParserPersisterDesignerControl
        Inherits System.Web.UI.WebControls.WebControl

        Private _text As String

        <Bindable(True), _
            Category("Appearance"), _
            DefaultValue("")> _
        Public Property [Text]() As String
            Get
                Return _text
            End Get
            Set(ByVal Value As String)
                _text = Value
            End Set
        End Property

        Public Sub New()
            [Text] = "Right-click here to access control persistence " & _
                        "methods in design mode"
        End Sub

        Protected Overrides Sub Render(ByVal output As HtmlTextWriter)
            output.Write([Text])
        End Sub
    End Class

    ' Provides a form with a list for selection.
    Friend Class ControlSelectionForm
        Inherits System.Windows.Forms.Form
        Private controlArray() As System.Web.UI.Control
        Public controlList As System.Windows.Forms.ListBox

        Public Sub New(ByVal controlArray() As System.Web.UI.Control)
            Me.controlArray = controlArray

            Me.Size = New Size(400, 500)
            Me.Text = "Control Persister Selection Form"

            Me.SuspendLayout()

            Dim label1 As New System.Windows.Forms.Label()
            label1.Text = "Select the control to persist:"
            label1.Size = New Size(240, 20)
            label1.Location = New Point(10, 10)
            Me.Controls.Add(label1)

            controlList = New System.Windows.Forms.ListBox()
            controlList.Size = New Size(370, 400)
            controlList.Location = New Point(10, 30)
            controlList.Anchor = AnchorStyles.Left Or AnchorStyles.Top _
                    Or AnchorStyles.Bottom Or AnchorStyles.Right
            Me.Controls.Add(controlList)

            Dim okButton As New System.Windows.Forms.Button()
            okButton.Text = "OK"
            okButton.Size = New Size(80, 24)
            okButton.Location = New Point(Me.Width - 100, Me.Height - 60)
            okButton.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
            okButton.DialogResult = DialogResult.OK
            Me.Controls.Add(okButton)

            Dim cancelButton As New System.Windows.Forms.Button()
            cancelButton.Text = "Cancel"
            cancelButton.Size = New Size(80, 24)
            cancelButton.Location = New Point(Me.Width - 200, Me.Height - 60)
            cancelButton.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
            cancelButton.DialogResult = DialogResult.Cancel
            Me.Controls.Add(cancelButton)

            Dim i As Integer
            For i = 0 To controlArray.Length - 1
                controlList.Items.Add(controlArray(i).UniqueID)
            Next i
            Me.ResumeLayout()
        End Sub
    End Class

    ' Provides a form with a multiline text box display.
    Friend Class StringDisplayForm
        Inherits System.Windows.Forms.Form

        Private tbox As New System.Windows.Forms.TextBox()

        Public Property TxBox() As System.Windows.Forms.TextBox
            Get
                Return tbox
            End Get
            Set(ByVal value As System.Windows.Forms.TextBox)
                tbox = value
            End Set
        End Property

        Public Sub New(ByVal displayText As String)
            Me.Size = New Size(400, 300)
            Me.Text = "Control Persistence String"

            Me.SuspendLayout()
            Dim tbox As New System.Windows.Forms.TextBox()
            tbox.Multiline = True
            tbox.Size = New Size(Me.Width - 40, Me.Height - 90)
            tbox.Text = displayText
            Me.Controls.Add(tbox)

            Dim okButton As New System.Windows.Forms.Button()
            okButton.Text = "OK"
            okButton.Size = New Size(80, 24)
            okButton.Location = New Point(Me.Width - 100, Me.Height - 60)
            okButton.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
            okButton.DialogResult = DialogResult.OK
            Me.Controls.Add(okButton)

            Me.ResumeLayout()
        End Sub
    End Class

    ' Provides a form with a multiline text box for input.
    Friend Class StringInputForm
        Inherits System.Windows.Forms.Form
        Private tbox As New System.Windows.Forms.TextBox()

        Public Property TxBox() As System.Windows.Forms.TextBox
            Get
                Return tbox
            End Get
            Set(ByVal value As System.Windows.Forms.TextBox)
                tbox = value
            End Set
        End Property

        Public Sub New()
            Me.Size = New Size(400, 400)
            Me.Text = "Input Control Persistence String"

            Me.SuspendLayout()
            tbox = New System.Windows.Forms.TextBox()
            tbox.Multiline = True
            tbox.Size = New Size(Me.Width - 40, Me.Height - 90)
            tbox.Text = ""
            Me.Controls.Add(tbox)

            Dim okButton As New System.Windows.Forms.Button()
            okButton.Text = "OK"
            okButton.Size = New Size(80, 24)
            okButton.Location = New Point(Me.Width - 100, Me.Height - 60)
            okButton.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
            okButton.DialogResult = DialogResult.OK
            Me.Controls.Add(okButton)

            Dim cancelButton As New System.Windows.Forms.Button()
            cancelButton.Text = "Cancel"
            cancelButton.Size = New Size(80, 24)
            cancelButton.Location = New Point(Me.Width - 200, Me.Height - 60)
            cancelButton.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
            cancelButton.DialogResult = DialogResult.Cancel
            Me.Controls.Add(cancelButton)

            Me.ResumeLayout()
        End Sub
    End Class
End Namespace
'</Snippet1>