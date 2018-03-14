'<Snippet00>
Imports System
Imports System.Windows.Forms

Public Class Form1
    Inherits Form

    Private WithEvents DataGridView1 As New DataGridView()
    Private WithEvents CopyPasteButton As New Button()
    Private TextBox1 As New TextBox()

    <STAThreadAttribute()> _
    Public Shared Sub Main()
        Application.Run(New Form1())
    End Sub

    Public Sub New()

        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.Dock = DockStyle.Fill
        Me.Controls.Add(Me.DataGridView1)

        Me.CopyPasteButton.Text = "copy/paste selected cells"
        Me.CopyPasteButton.Dock = DockStyle.Top
        Me.Controls.Add(Me.CopyPasteButton)

        Me.TextBox1.Multiline = True
        Me.TextBox1.Height = 100
        Me.TextBox1.Dock = DockStyle.Bottom
        Me.Controls.Add(Me.TextBox1)

        Me.Text = "DataGridView Clipboard demo"

    End Sub

    '<Snippet10>
    Private Sub Form1_Load(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Load

        ' Initialize the DataGridView control.
        Me.DataGridView1.ColumnCount = 5
        Me.DataGridView1.Rows.Add(New String() {"A", "B", "C", "D", "E"})
        Me.DataGridView1.Rows.Add(New String() {"F", "G", "H", "I", "J"})
        Me.DataGridView1.Rows.Add(New String() {"K", "L", "M", "N", "O"})
        Me.DataGridView1.Rows.Add(New String() {"P", "Q", "R", "S", "T"})
        Me.DataGridView1.Rows.Add(New String() {"U", "V", "W", "X", "Y"})
        Me.DataGridView1.AutoResizeColumns()
        '<Snippet15>
        Me.DataGridView1.ClipboardCopyMode = _
            DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        '</Snippet15>

    End Sub

    '<Snippet16>
    Private Sub CopyPasteButton_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles CopyPasteButton.Click

        If Me.DataGridView1.GetCellCount( _
            DataGridViewElementStates.Selected) > 0 Then

            Try

                ' Add the selection to the clipboard.
                Clipboard.SetDataObject( _
                    Me.DataGridView1.GetClipboardContent())

                ' Replace the text box contents with the clipboard text.
                Me.TextBox1.Text = Clipboard.GetText()

            Catch ex As System.Runtime.InteropServices.ExternalException
                Me.TextBox1.Text = _
                    "The Clipboard could not be accessed. Please try again."
            End Try

        End If

    End Sub
    '</Snippet16>
    '</Snippet10>

End Class
'</Snippet00>