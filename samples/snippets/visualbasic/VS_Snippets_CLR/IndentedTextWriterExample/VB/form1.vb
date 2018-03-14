 '<Snippet1>
Imports System
Imports System.CodeDom
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.IO
Imports System.Windows.Forms

Public Class Form1
   Inherits System.Windows.Forms.Form
   Private textBox1 As System.Windows.Forms.TextBox 
   
   '<Snippet2>
   Private Function CreateMultilevelIndentString() As String
        '<Snippet3>
        ' Create a TextWriter to use as the base output writer.
        Dim baseTextWriter As New System.IO.StringWriter
      
        ' Create an IndentedTextWriter and set the tab string to use 
        ' as the indentation string for each indentation level.
        Dim indentWriter = New IndentedTextWriter(baseTextWriter, "    ")
        '</Snippet3>

        '<Snippet4>
        ' Set the indentation level.
        indentWriter.Indent = 0
        '</Snippet4>

        ' Output test strings at stepped indentations through a recursive loop method.
        WriteLevel(indentWriter, 0, 5)
      
        ' Return the resulting string from the base StringWriter.
        Return baseTextWriter.ToString()
    End Function

    '<Snippet5>
    Private Sub WriteLevel(ByVal indentWriter As IndentedTextWriter, ByVal level As Integer, ByVal totalLevels As Integer)
        ' Outputs a test string with a new-line character at the end.
        indentWriter.WriteLine(("This is a test phrase. Current indentation level: " + level.ToString()))

        ' If not yet at the highest recursion level, call this output method for the next level of indentation.
        If level < totalLevels Then
            ' Increase the indentation count for the next level of indented output.
            indentWriter.Indent += 1

            ' Call the WriteLevel method to write test output for the next level of indentation.
            WriteLevel(indentWriter, level + 1, totalLevels)

            ' Restores the indentation count for this level after the recursive branch method has returned.
            indentWriter.Indent -= 1

        Else
            '<Snippet6>
            ' Output a string using the WriteLineNoTabs method.
            indentWriter.WriteLineNoTabs("This is a test phrase written with the IndentTextWriter.WriteLineNoTabs method.")
            '</Snippet6>
        End If

        ' Outputs a test string with a new-line character at the end.
        indentWriter.WriteLine(("This is a test phrase. Current indentation level: " + level.ToString()))
    End Sub
    '</Snippet5>
    '</Snippet2>

    Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        textBox1.Text = CreateMultilevelIndentString()
    End Sub

    Public Sub New()
        Dim button1 As New System.Windows.Forms.Button
        Me.textBox1 = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        Me.textBox1.Anchor = CType(System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)
        Me.textBox1.Location = New System.Drawing.Point(8, 40)
        Me.textBox1.Multiline = True
        Me.textBox1.Name = "textBox1"
        Me.textBox1.Size = New System.Drawing.Size(391, 242)
        Me.textBox1.TabIndex = 0
        Me.textBox1.Text = ""
        button1.Location = New System.Drawing.Point(11, 8)
        button1.Name = "button1"
        button1.Size = New System.Drawing.Size(229, 23)
        button1.TabIndex = 1
        button1.Text = "Generate string using IndentedTextWriter"
        AddHandler button1.Click, AddressOf Me.button1_Click
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(407, 287)
        Me.Controls.Add(button1)
        Me.Controls.Add(Me.textBox1)
        Me.Name = "Form1"
        Me.Text = "IndentedTextWriter example"
        Me.ResumeLayout(False)
    End Sub

    <STAThread()> _
    Shared Sub Main()
        Application.Run(New Form1)
    End Sub
End Class
'</Snippet1>