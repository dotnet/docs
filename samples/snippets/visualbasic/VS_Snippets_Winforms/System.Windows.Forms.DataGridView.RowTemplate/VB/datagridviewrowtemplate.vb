Imports System
Imports System.Drawing
Imports System.Windows.Forms

Class Form1
    Inherits Form

    Private dataGridView1 As New DataGridView()

    <STAThreadAttribute()> _
    Public Shared Sub Main()

        Application.Run(New Form1())

    End Sub


    Sub New()

        Me.dataGridView1.Dock = DockStyle.Fill
        Me.Controls.Add(Me.dataGridView1)
        Me.Text = "DataGridView.RowTemplate demo"

    End Sub


    Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        '<Snippet1>
        With Me.dataGridView1.RowTemplate
            .DefaultCellStyle.BackColor = Color.Bisque
            .Height = 35
            .MinimumHeight = 20
        End With
        '</Snippet1>

        Me.dataGridView1.ColumnCount = 5
        Me.dataGridView1.RowCount = 10

    End Sub

End Class
