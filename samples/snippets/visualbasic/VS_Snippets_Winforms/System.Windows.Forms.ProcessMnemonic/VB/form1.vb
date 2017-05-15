'<snippet2>
Imports System.Windows.Forms
Imports System.Security.Permissions

Public Class Form1
    Inherits System.Windows.Forms.Form

    ' Declare the controls contained on the form.
    Private WithEvents button1 As MyMnemonicButton
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox

    Public Sub New()
        MyBase.New()

        ' Set KeyPreview object to true to allow the form to process 
        ' the key before the control with focus processes it.
        Me.KeyPreview = True

        ' Add a MyMnemonicButton.  
        button1 = New MyMnemonicButton
        button1.Text = "&Click"
        button1.Location = New System.Drawing.Point(100, 120)
        Me.Controls.Add(button1)

        ' Initialize a ListBox control and the form itself.
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        Me.ListBox1.Location = New System.Drawing.Point(8, 8)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(120, 95)
        Me.ListBox1.TabIndex = 0
        Me.ListBox1.Text = "Press a key"
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.ListBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    ' The form will handle all key events before the control with  
    ' focus handles them.  Show the keys pressed by adding the
    ' KeyCode object to ListBox1. Ensure the processing is passed
    ' to the control with focus by setting the KeyEventArg.Handled
    ' property to false.
    Private Sub Form1_KeyDown(ByVal sender As Object, _
        ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        ListBox1.Items.Add(e.KeyCode)
        e.Handled = False
    End Sub

    <System.STAThreadAttribute()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

End Class


'<snippet1>
' This button is a simple extension of the button class that overrides
' the ProcessMnemonic method.  If the mnemonic is correctly entered,  
' the message box will appear and the click event will be raised.  
Public Class MyMnemonicButton
    Inherits Button

    ' This method makes sure the control is selectable and the 
    ' mneumonic is correct before displaying the message box
    ' and triggering the click event.
    <System.Security.Permissions.UIPermission( _
    System.Security.Permissions.SecurityAction.Demand, Window:=UIPermissionWindow.AllWindows)> _
    Protected Overrides Function ProcessMnemonic( _
        ByVal inputChar As Char) As Boolean

        If (CanSelect And IsMnemonic(inputChar, Me.Text)) Then
            MessageBox.Show("You've raised the click event " _
                & "using the mnemonic.")
            Me.PerformClick()
            Return True
        End If
        Return False
    End Function

End Class
'</snippet1>
'</snippet2>


