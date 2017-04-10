 '<Snippet1>
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

' Example UITypeEditor that uses the IWindowsFormsEditorService 
' to display a Form.
<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> Public Class TestDialogEditor
   Inherits System.Drawing.Design.UITypeEditor
   
   Public Sub New()
    End Sub

    Public Overloads Overrides Function GetEditStyle(ByVal context As ITypeDescriptorContext) As UITypeEditorEditStyle
        ' Indicates that this editor can display a Form-based interface.
        Return UITypeEditorEditStyle.Modal
    End Function

    Public Overloads Overrides Function EditValue(ByVal context As ITypeDescriptorContext, ByVal provider As IServiceProvider, ByVal value As Object) As Object

        ' Attempts to obtain an IWindowsFormsEditorService.
        Dim edSvc As IWindowsFormsEditorService = CType(provider.GetService( _
        GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)
        If edSvc Is Nothing Then
            Return Nothing
        End If

        ' Displays a StringInputDialog Form to get a user-adjustable 
        ' string value.
        Using form As New StringInputDialog(CStr(value))
            If edSvc.ShowDialog(form) = DialogResult.OK Then
                Return form.inputTextBox.Text
            End If
        End Using

        ' If OK was not pressed, return the original value
        Return value

    End Function
End Class

' Example Form for entering a string.
Friend Class StringInputDialog
    Inherits System.Windows.Forms.Form

    Private ok_button As System.Windows.Forms.Button
    Private cancel_button As System.Windows.Forms.Button
    Public inputTextBox As System.Windows.Forms.TextBox

    Public Sub New(ByVal [text] As String)
        InitializeComponent()
        inputTextBox.Text = [text]
    End Sub

    Private Sub InitializeComponent()
        Me.ok_button = New System.Windows.Forms.Button()
        Me.cancel_button = New System.Windows.Forms.Button()
        Me.inputTextBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        Me.ok_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right
        Me.ok_button.Location = New System.Drawing.Point(180, 43)
        Me.ok_button.Name = "ok_button"
        Me.ok_button.TabIndex = 1
        Me.ok_button.Text = "OK"
        Me.ok_button.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cancel_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right
        Me.cancel_button.Location = New System.Drawing.Point(260, 43)
        Me.cancel_button.Name = "cancel_button"
        Me.cancel_button.TabIndex = 2
        Me.cancel_button.Text = "Cancel"
        Me.cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.inputTextBox.Location = New System.Drawing.Point(6, 9)
        Me.inputTextBox.Name = "inputTextBox"
        Me.inputTextBox.Size = New System.Drawing.Size(327, 20)
        Me.inputTextBox.TabIndex = 0
        Me.inputTextBox.Text = ""
        Me.inputTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.ClientSize = New System.Drawing.Size(342, 73)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.inputTextBox, Me.cancel_button, Me.ok_button})
        Me.MinimumSize = New System.Drawing.Size(350, 100)
        Me.Name = "StringInputDialog"
        Me.Text = "String Input Dialog"
        Me.ResumeLayout(False)
    End Sub

End Class

' Provides an example control that displays instructions in design mode,
' with which the example UITypeEditor is associated.
Public Class WinFormsEdServiceDialogExampleControl
    Inherits UserControl

    <EditorAttribute(GetType(TestDialogEditor), GetType(UITypeEditor))> _
    Public Property TestDialogString() As String
        Get
            Return localDialogTestString
        End Get
        Set(ByVal Value As String)
            localDialogTestString = Value
        End Set
    End Property
    Private localDialogTestString As String

    Public Sub New()
        localDialogTestString = "Test String"
        Me.Size = New Size(210, 74)
        Me.BackColor = Color.Beige
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        If Me.DesignMode Then
            e.Graphics.DrawString("Use the Properties window to show", New Font("Arial", 8), New SolidBrush(Color.Black), 5, 5)
            e.Graphics.DrawString("a Form dialog box, using the", New Font("Arial", 8), New SolidBrush(Color.Black), 5, 17)
            e.Graphics.DrawString("IWindowsFormsEditorService, for", New Font("Arial", 8), New SolidBrush(Color.Black), 5, 29)
            e.Graphics.DrawString("configuring this control's", New Font("Arial", 8), New SolidBrush(Color.Black), 5, 41)
            e.Graphics.DrawString("TestDialogString property.", New Font("Arial", 8), New SolidBrush(Color.Black), 5, 53)
        Else
            e.Graphics.DrawString("This example requires design mode.", New Font("Arial", 8), New SolidBrush(Color.Black), 5, 5)
        End If
    End Sub

End Class
'</Snippet1>