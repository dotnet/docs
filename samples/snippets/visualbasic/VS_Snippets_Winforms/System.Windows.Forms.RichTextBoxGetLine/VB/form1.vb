' The following example demonstrates using the RichTextBox.GetLineFromCharIndex
' method.
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(40, 32)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 40)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Find line numbers."
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(40, 88)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.TabIndex = 2
        Me.RichTextBox1.Text = "This text will contain name several times." _
            & "Here is name again, and again: name"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(168, 104)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(88, 64)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.Text = ""
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(152, 48)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.TabIndex = 4
        Me.TextBox2.Text = "name"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

    '<snippet1>
    ' This method demonstrates retrieving line numbers that 
    ' indicate the location of a particular word
    ' contained in a RichTextBox. The line numbers are zero-based.

    Private Sub Button1_Click(ByVal sender As System.Object, _ 
        ByVal e As System.EventArgs) Handles Button1.Click

        ' Reset the results box.
        TextBox1.Text = ""

        ' Get the word to search from from TextBox2.
        Dim searchWord As String = TextBox2.Text

        Dim index As Integer = 0

        'Declare an ArrayList to store line numbers.
        Dim lineList As New System.Collections.ArrayList
        Do
            ' Find occurrences of the search word, incrementing  
            ' the start index. 
            index = RichTextBox1.Find(searchWord, index + 1, _
                RichTextBoxFinds.MatchCase)
            If (index <> -1) Then

                ' Find the word's line number and add the line 
                'number to the arrayList. 
                lineList.Add(RichTextBox1.GetLineFromCharIndex(index))
            End If
        Loop While (index <> -1)

        ' Iterate through the list and display the line numbers in TextBox1.
        Dim myEnumerator As System.Collections.IEnumerator = _
            lineList.GetEnumerator()
        If lineList.Count <= 0 Then
            TextBox1.Text = searchWord & " was not found"
        Else
            TextBox1.SelectedText = searchWord & " was found on line(s):"
            While (myEnumerator.MoveNext)
                TextBox1.SelectedText = myEnumerator.Current & " "
            End While
        End If

    End Sub
    '</snippet1>

End Class
