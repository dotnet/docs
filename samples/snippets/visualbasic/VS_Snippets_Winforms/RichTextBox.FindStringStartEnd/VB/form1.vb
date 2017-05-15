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
    Friend WithEvents button1 As System.Windows.Forms.Button
    Friend WithEvents richTextBox1 As System.Windows.Forms.RichTextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.button1 = New System.Windows.Forms.Button()
        Me.richTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(201, 206)
        Me.button1.Name = "button1"
        Me.button1.TabIndex = 3
        Me.button1.Text = "button1"
        '
        'richTextBox1
        '
        Me.richTextBox1.Location = New System.Drawing.Point(17, 38)
        Me.richTextBox1.Name = "richTextBox1"
        Me.richTextBox1.Size = New System.Drawing.Size(256, 160)
        Me.richTextBox1.TabIndex = 2
        Me.richTextBox1.Text = "Alpha Bravo Charlie Delta Echo Foxtrot Golf"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button1, Me.richTextBox1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button1.Click
      MessageBox.Show(FindMyText("Golf", 44, -1).ToString())
    End Sub 'button1_Click


    '<Snippet1>
    Public Function FindMyText(ByVal searchText As String, ByVal searchStart As Integer, ByVal searchEnd As Integer) As Integer
        ' Initialize the return value to false by default.
        Dim returnValue As Integer = -1

        ' Ensure that a search string and a valid starting point are specified.
        If searchText.Length > 0 And searchStart >= 0 Then
            ' Ensure that a valid ending value is provided.
            If searchEnd > searchStart Or searchEnd = -1 Then
                ' Obtain the location of the search string in richTextBox1.
            Dim indexToText As Integer = richTextBox1.Find(searchText, searchStart, searchEnd, RichTextBoxFinds.MatchCase)
                ' Determine whether the text was found in richTextBox1.
                If indexToText >= 0 Then
                    ' Return the index to the specified search text.
                    returnValue = indexToText
                End If
            End If
        End If

        Return returnValue
    End Function
    '</Snippet1>
End Class
