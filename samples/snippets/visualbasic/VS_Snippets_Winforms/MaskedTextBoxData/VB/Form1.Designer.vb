Partial Public Class Form1
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.firstName = New System.Windows.Forms.TextBox
        Me.lastName = New System.Windows.Forms.TextBox
        Me.PhoneMask = New System.Windows.Forms.MaskedTextBox
        Me.NextButton = New System.Windows.Forms.Button
        Me.PreviousButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'firstName
        '
        Me.firstName.Location = New System.Drawing.Point(26, 13)
        Me.firstName.Name = "firstName"
        Me.firstName.Size = New System.Drawing.Size(189, 20)
        Me.firstName.TabIndex = 0
        '
        'lastName
        '
        Me.lastName.Location = New System.Drawing.Point(222, 13)
        Me.lastName.Name = "lastName"
        Me.lastName.Size = New System.Drawing.Size(207, 20)
        Me.lastName.TabIndex = 1
        '
        'PhoneMask
        '
        Me.PhoneMask.Location = New System.Drawing.Point(436, 13)
        Me.PhoneMask.Mask = "(009)-000-0000 x9999"
        Me.PhoneMask.Name = "PhoneMask"
        Me.PhoneMask.Size = New System.Drawing.Size(133, 20)
        Me.PhoneMask.TabIndex = 2
        '
        'NextButton
        '
        Me.NextButton.Location = New System.Drawing.Point(685, 10)
        Me.NextButton.Name = "NextButton"
        Me.NextButton.Size = New System.Drawing.Size(104, 23)
        Me.NextButton.TabIndex = 3
        Me.NextButton.Text = "Next"
        '
        'PreviousButton
        '
        Me.PreviousButton.Location = New System.Drawing.Point(576, 10)
        Me.PreviousButton.Name = "PreviousButton"
        Me.PreviousButton.Size = New System.Drawing.Size(102, 23)
        Me.PreviousButton.TabIndex = 4
        Me.PreviousButton.Text = "Previous"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(840, 57)
        Me.Controls.Add(Me.PreviousButton)
        Me.Controls.Add(Me.NextButton)
        Me.Controls.Add(Me.PhoneMask)
        Me.Controls.Add(Me.lastName)
        Me.Controls.Add(Me.firstName)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents firstName As System.Windows.Forms.TextBox
    Friend WithEvents lastName As System.Windows.Forms.TextBox
    Friend WithEvents PhoneMask As System.Windows.Forms.MaskedTextBox
    Friend WithEvents NextButton As System.Windows.Forms.Button
    Friend WithEvents PreviousButton As System.Windows.Forms.Button

End Class
