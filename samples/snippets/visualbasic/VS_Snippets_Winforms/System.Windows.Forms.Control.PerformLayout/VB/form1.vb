' This example demonstrates using the Control.PerformLayout method.  
' It contains a custom LayoutControl object and three buttons.  
' The Click event handler for Button1 explicitly calls PerformLayout.  
' The Click event handler for Button2 implicitly calls PerformLayout. 
' PerformLayout is also called when the form is loaded. Button3 returns 
' the control to the state it was in when loaded.
 '<snippet1>

Imports System.Windows.Forms
Imports System.Drawing



Public Class LayoutForm
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents LayoutControl1 As LayoutControl
    Friend WithEvents Button3 As System.Windows.Forms.Button

    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.LayoutControl1 = New LayoutControl
        Me.SuspendLayout()
        Me.Button1.Location = New System.Drawing.Point(16, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(120, 32)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Center textbox on control"
        Me.Button2.Location = New System.Drawing.Point(152, 16)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(104, 32)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Shrink user control"
        Me.Button3.Location = New System.Drawing.Point(96, 232)
        Me.Button3.Name = "Button3"
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Reset"
        Me.LayoutControl1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.LayoutControl1.Location = New System.Drawing.Point(72, 64)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Size = New System.Drawing.Size(150, 160)
        Me.LayoutControl1.TabIndex = 6
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    <System.STAThread()> Shared Sub Main()
        Application.Run(New LayoutForm)
    End Sub


   
    ' This method explicitly calls raises the layout event on 
    ' LayoutControl1, changing the Bounds property.
    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click
        LayoutControl1.PerformLayout(LayoutControl1, "Bounds")
    End Sub

    ' This resize of LayoutControl1 implicitly triggers the layout event. 
    '   Changing the size of the control affects its Bounds property.
    Private Sub Button2_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button2.Click
        LayoutControl1.Size = New System.Drawing.Size(100, 100)
    End Sub

    ' This method explicitly calls PerformLayout with no parameters, 
    ' which raises the Layout event with the LayoutEventArgs properties
    ' equal to Nothing.
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        LayoutControl1.PerformLayout()
    End Sub

End Class


'This custom control has the Layout event implented so that when 
'PerformLayout(AffectedControl, AffectedProperty) is called on the control, 
'where AffectedProperty equals "Bounds" the textbox is centered on the control.
Public Class LayoutControl
    Inherits System.Windows.Forms.UserControl
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.TabIndex = 0
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "LayoutControl"
        Me.ResumeLayout(False)

    End Sub

    'This method is called when the Layout event is fired. This happens by during the initial load,
    'by calling PerformLayout or by resizing, adding or removing controls or other actions that 
    'affect how the control is laid out. This method checks the value of e.AffectedProperty
    'and changes the look of the control accordingly. 
    Private Sub LayoutControl_Layout(ByVal sender As Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles MyBase.Layout
        If e.AffectedProperty IsNot Nothing Then
            If e.AffectedProperty.Equals("Bounds") Then
                TextBox1.Left = (Me.Width - TextBox1.Width) / 2
                TextBox1.Top = (Me.Height - TextBox1.Height) / 2
            End If
        Else
            Me.Size = New System.Drawing.Size(150, 160)
            TextBox1.Location = New System.Drawing.Point(16, 24)
        End If
        TextBox1.Text = "Left = " & TextBox1.Left & " Top = " & TextBox1.Top
    End Sub

End Class

    '</snippet1>




