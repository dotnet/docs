Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

'<Snippet1>
Public Class Form1
    Inherits System.Windows.Forms.Form
    Private WithEvents textBox1 As System.Windows.Forms.TextBox
    Private label1 As System.Windows.Forms.Label
    Private layoutButton As System.Windows.Forms.Button
    Private components As System.ComponentModel.Container = Nothing


    Public Sub New()
        InitializeComponent()
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private Sub InitializeComponent()
        Me.layoutButton = New System.Windows.Forms.Button()
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        ' 
        ' layoutButton
        ' 
        Me.layoutButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.layoutButton.Location = New System.Drawing.Point(72, 88)
        Me.layoutButton.Name = "layoutButton"
        Me.layoutButton.Size = New System.Drawing.Size(150, 23)
        Me.layoutButton.TabIndex = 0
        Me.layoutButton.Text = "Hello"
        ' 
        ' textBox1
        ' 
        Me.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.textBox1.Location = New System.Drawing.Point(24, 40)
        Me.textBox1.Name = "textBox1"
        Me.textBox1.Size = New System.Drawing.Size(248, 20)
        Me.textBox1.TabIndex = 1
        Me.textBox1.Text = "Hello"
        ' 
        ' label1
        ' 
        Me.label1.Location = New System.Drawing.Point(24, 16)
        Me.label1.Name = "label1"
        Me.label1.TabIndex = 2
        Me.label1.Text = "Button's Text:"
        ' 
        ' Form1
        ' 
        Me.ClientSize = New System.Drawing.Size(292, 129)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.label1, Me.textBox1, Me.layoutButton})
        Me.Name = "Form1"
        Me.Text = "Layout Sample"
        Me.ResumeLayout(False)
    End Sub

   ' This method ensures that the form's width is the preferred size of 300 pixels
   ' or the size of the button plus 50 pixels, whichever amount is less.
    Private Sub Form1_Layout(ByVal sender As Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles MyBase.Layout
      ' This event is raised once at startup with the AffectedControl
      ' and AffectedProperty properties on the LayoutEventArgs as null. 
      ' The event provides size preferences for that case.
        If (e.AffectedControl IsNot Nothing) And (e.AffectedProperty IsNot Nothing) Then
            ' Ensure that the affected property is the Bounds property
            ' of the form.
            If e.AffectedProperty.ToString() = "Bounds" Then
             ' If layoutButton's width plus a padding of 50 pixels is greater than the preferred 
             ' size of 300 pixels, increase the form's width.
                If Me.layoutButton.Width + 50 > 300 Then
                    Me.Width = Me.layoutButton.Width + 50
                    ' If not, keep the form's width at 300 pixels.
                Else
                    Me.Width = 300
                End If

                ' Center layoutButton on the form.
                Me.layoutButton.Left = (Me.ClientSize.Width - Me.layoutButton.Width) / 2
            End If
        End If
    End Sub

    ' This method sets the Text property of layoutButton to the Text property
    ' of textBox1.  If the new text plus a padding of 20 pixels is larger than 
    ' the preferred size of 150 pixels, increase layoutButton's Width property.
    Private Sub textBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles textBox1.TextChanged
        ' Set the Text property of layoutButton.
        Me.layoutButton.Text = Me.textBox1.Text
        ' Get the width of the text using the proper font.
        Dim textWidth As Integer = CInt(Me.CreateGraphics().MeasureString(layoutButton.Text, layoutButton.Font).Width)

        ' If the width of the text plus a padding of 20 pixels is greater than the preferred size of
        ' 150 pixels, increase layoutButton's width.
        If textWidth + 20 > 150 Then
            ' Setting the size property on any control raises 
            ' the Layout event for its container.
            Me.layoutButton.Width = textWidth + 20
            ' If not, keep layoutButton's width at 150 pixels.
        Else
            Me.layoutButton.Width = 150
        End If
    End Sub
End Class
'</Snippet1>