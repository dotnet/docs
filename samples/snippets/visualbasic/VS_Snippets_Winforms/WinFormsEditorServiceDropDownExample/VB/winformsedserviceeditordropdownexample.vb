 '<Snippet1>
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

' Example UITypeEditor that uses the IWindowsFormsEditorService to 
' display a drop-down control.
<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
Public Class TestDropDownEditor
   Inherits System.Drawing.Design.UITypeEditor
   
   Public Sub New()
    End Sub
   
    Public Overloads Overrides Function GetEditStyle(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.Drawing.Design.UITypeEditorEditStyle
        ' Indicates that this editor can display a control-based 
        ' drop-down interface.
        Return UITypeEditorEditStyle.DropDown
    End Function
    
    Public Overloads Overrides Function EditValue(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal provider As System.IServiceProvider, ByVal value As Object) As Object

        ' Attempts to obtain an IWindowsFormsEditorService.
        Dim edSvc As IWindowsFormsEditorService = CType(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)
        If edSvc Is Nothing Then
            Return value
        End If

        ' Displays a drop-down control.
        Dim inputControl As New StringInputControl(CStr(value), edSvc)
        edSvc.DropDownControl(inputControl)
        Return inputControl.inputTextBox.Text
    End Function

End Class

' Example control for entering a string.
Friend Class StringInputControl
    Inherits System.Windows.Forms.UserControl

    Public inputTextBox As System.Windows.Forms.TextBox
    Private WithEvents ok_button As System.Windows.Forms.Button
    Private WithEvents cancel_button As System.Windows.Forms.Button
    Private edSvc As IWindowsFormsEditorService

    Public Sub New(ByVal [text] As String, ByVal edSvc As IWindowsFormsEditorService)
        InitializeComponent()
        inputTextBox.Text = [text]
        ' Stores IWindowsFormsEditorService reference to use to 
        ' close the control.
        Me.edSvc = edSvc
    End Sub

    Private Sub InitializeComponent()
        Me.inputTextBox = New System.Windows.Forms.TextBox()
        Me.ok_button = New System.Windows.Forms.Button()
        Me.cancel_button = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        Me.inputTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.inputTextBox.Location = New System.Drawing.Point(6, 7)
        Me.inputTextBox.Name = "inputTextBox"
        Me.inputTextBox.Size = New System.Drawing.Size(336, 20)
        Me.inputTextBox.TabIndex = 0
        Me.inputTextBox.Text = ""
        Me.ok_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right
        Me.ok_button.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ok_button.Location = New System.Drawing.Point(186, 38)
        Me.ok_button.Name = "ok_button"
        Me.ok_button.TabIndex = 1
        Me.ok_button.Text = "OK"
        Me.cancel_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right
        Me.cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cancel_button.Location = New System.Drawing.Point(267, 38)
        Me.cancel_button.Name = "cancel_button"
        Me.cancel_button.TabIndex = 2
        Me.cancel_button.Text = "Cancel"
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cancel_button, Me.ok_button, Me.inputTextBox})
        Me.Name = "StringInputControl"
        Me.Size = New System.Drawing.Size(350, 70)
        Me.ResumeLayout(False)
    End Sub

    Private Sub CloseControl(ByVal sender As Object, ByVal e As EventArgs) Handles ok_button.Click, cancel_button.Click
        edSvc.CloseDropDown()
    End Sub

End Class

' Provides an example control that displays instructions in design mode,
' with which the example UITypeEditor is associated.
Public Class WinFormsEdServiceDropDownExampleControl
    Inherits UserControl

    <EditorAttribute(GetType(TestDropDownEditor), GetType(UITypeEditor))> _
    Public Property TestDropDownString() As String
        Get
            Return localDropDownTestString
        End Get
        Set(ByVal Value As String)
            localDropDownTestString = Value
        End Set
    End Property
    Private localDropDownTestString As String

    Public Sub New()
        localDropDownTestString = "Test String"
        Me.Size = New Size(210, 74)
        Me.BackColor = Color.Beige
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        If Me.DesignMode Then
            e.Graphics.DrawString("Use the Properties window to show", New Font("Arial", 8), New SolidBrush(Color.Black), 5, 5)
            e.Graphics.DrawString("a drop-down control, using the", New Font("Arial", 8), New SolidBrush(Color.Black), 5, 17)
            e.Graphics.DrawString("IWindowsFormsEditorService, for", New Font("Arial", 8), New SolidBrush(Color.Black), 5, 29)
            e.Graphics.DrawString("configuring this control's", New Font("Arial", 8), New SolidBrush(Color.Black), 5, 41)
            e.Graphics.DrawString("TestDropDownString property.", New Font("Arial", 8), New SolidBrush(Color.Black), 5, 53)
        Else
            e.Graphics.DrawString("This example requires design mode.", New Font("Arial", 8), New SolidBrush(Color.Black), 5, 5)
        End If
    End Sub

End Class
'</Snippet1>
