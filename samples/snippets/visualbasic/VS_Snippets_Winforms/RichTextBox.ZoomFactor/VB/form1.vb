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
    Friend WithEvents richTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.richTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'richTextBox1
        '
        Me.richTextBox1.Location = New System.Drawing.Point(79, 72)
        Me.richTextBox1.Name = "richTextBox1"
        Me.richTextBox1.Size = New System.Drawing.Size(192, 208)
        Me.richTextBox1.TabIndex = 3
        Me.richTextBox1.Text = "richTextBox1"
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(287, 264)
        Me.button1.Name = "button1"
        Me.button1.TabIndex = 2
        Me.button1.Text = "button1"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(440, 358)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.richTextBox1, Me.button1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button1.Click
        ZoomMyRichTextBox()
    End Sub 'button1_Click


    '<Snippet1>
    Private Sub ZoomMyRichTextBox()
        ' Enable users to select entire word when double clicked.
        richTextBox1.AutoWordSelection = True
        ' Clear contents of control.
        richTextBox1.Clear()
        ' Set the right margin to restrict horizontal text.
        richTextBox1.RightMargin = 2
        ' Set the text for the control.
        richTextBox1.SelectedText = "Alpha Bravo Charlie Delta Echo Foxtrot"
        ' Zoom by 2 points.
        richTextBox1.ZoomFactor = 2.0F
    End Sub
    '</Snippet1>

End Class
