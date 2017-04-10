
' This example demonstrates the ComboBox.ObjectCollection.AddRange, 
' ComboBox.DropDown, and ComboBox.Text properties and the 
' MessageBox.Show(string, string, MessageBoxButton, MessageBoxIcon) 
' method.


Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form


    Public Sub New()
        MyBase.New()
        InitializeComponent()
        InitializeComboBox()
    End Sub

    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

    Private Sub InitializeComponent()
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        Me.Label1.Location = New System.Drawing.Point(24, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Installation Type:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
    End Sub

    Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub
    '<snippet1>
    '<snippet2>
    
    ' Declare ComboBox1.
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    
    ' Initialize ComboBox1.
    Private Sub InitializeComboBox()
        Me.ComboBox1 = New ComboBox
        Me.ComboBox1.Location = New System.Drawing.Point(128, 48)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(100, 21)
        Me.ComboBox1.TabIndex = 0
        Me.ComboBox1.Text = "Typical"
        Dim installs() As String = New String() _
            {"Typical", "Compact", "Custom"}
        ComboBox1.Items.AddRange(installs)
        Me.Controls.Add(Me.ComboBox1)
    End Sub
    '</snippet1>

    ' Handles the ComboBox1 DropDown event. If the user expands the  
    ' drop-down box, a message box will appear, recommending the
    ' typical installation.
    Private Sub ComboBox1_DropDown _ 
        (ByVal sender As Object, ByVal e As System.EventArgs) _ 
        Handles ComboBox1.DropDown
        MessageBox.Show("Typical installation is strongly recommended.", _
        "Install information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    '</snippet2>
End Class

