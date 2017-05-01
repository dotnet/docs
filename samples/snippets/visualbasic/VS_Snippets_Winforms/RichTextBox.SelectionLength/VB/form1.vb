Imports System.Drawing

Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.richTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(93, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'richTextBox1
        '
        Me.richTextBox1.Location = New System.Drawing.Point(0, 49)
        Me.richTextBox1.Name = "richTextBox1"
        Me.richTextBox1.Size = New System.Drawing.Size(282, 212)
        Me.richTextBox1.TabIndex = 1
        Me.richTextBox1.Text = ""
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.richTextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "VB"
        Me.ResumeLayout(False)

    End Sub

    Public Shared Sub Main()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents richTextBox1 As System.Windows.Forms.RichTextBox


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ModifySelectedText()
    End Sub

    '<Snippet1>
    Private Sub ModifySelectedText()
        ' Determine if text is selected in the control.
        If (richTextBox1.SelectionLength > 0) Then
            ' Set the color of the selected text in the control.
            richTextBox1.SelectionColor = Color.Red
            ' Set the font of the selected text to bold and underlined.
            richTextBox1.SelectionFont = New Font("Arial", 10, FontStyle.Bold Or FontStyle.Underline)
            ' Protect the selected text from modification.
            richTextBox1.SelectionProtected = True
        End If
    End Sub
    '</Snippet1>
End Class


