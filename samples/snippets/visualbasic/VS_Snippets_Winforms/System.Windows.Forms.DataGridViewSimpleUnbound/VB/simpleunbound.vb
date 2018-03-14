'<Snippet00>
'<Snippet01>
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

    Private buttonPanel As New Panel
    Private WithEvents songsDataGridView As New DataGridView
    Private WithEvents addNewRowButton As New Button
    Private WithEvents deleteRowButton As New Button
    '</Snippet01>

    '<Snippet10>
    Private Sub Form1_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        SetupLayout()
        SetupDataGridView()
        PopulateDataGridView()

    End Sub

    Private Sub songsDataGridView_CellFormatting(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) _
        Handles songsDataGridView.CellFormatting

        If e IsNot Nothing Then

            If Me.songsDataGridView.Columns(e.ColumnIndex).Name = _
            "Release Date" Then
                If e.Value IsNot Nothing Then
                    Try
                        e.Value = DateTime.Parse(e.Value.ToString()) _
                            .ToLongDateString()
                        e.FormattingApplied = True
                    Catch ex As FormatException
                        Console.WriteLine("{0} is not a valid date.", e.Value.ToString())
                    End Try
                End If
            End If

        End If

    End Sub

    Private Sub addNewRowButton_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles addNewRowButton.Click

        Me.songsDataGridView.Rows.Add()

    End Sub

    Private Sub deleteRowButton_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles deleteRowButton.Click

        If Me.songsDataGridView.SelectedRows.Count > 0 AndAlso _
            Not Me.songsDataGridView.SelectedRows(0).Index = _
            Me.songsDataGridView.Rows.Count - 1 Then

            Me.songsDataGridView.Rows.RemoveAt( _
                Me.songsDataGridView.SelectedRows(0).Index)

        End If

    End Sub
    '</Snippet10>

    '<Snippet20>
    Private Sub SetupLayout()

        Me.Size = New Size(600, 500)

        With addNewRowButton
            .Text = "Add Row"
            .Location = New Point(10, 10)
        End With

        With deleteRowButton
            .Text = "Delete Row"
            .Location = New Point(100, 10)
        End With

        With buttonPanel
            .Controls.Add(addNewRowButton)
            .Controls.Add(deleteRowButton)
            .Height = 50
            .Dock = DockStyle.Bottom
        End With

        Me.Controls.Add(Me.buttonPanel)

    End Sub
    '</Snippet20>

    '<Snippet30>
    Private Sub SetupDataGridView()

        Me.Controls.Add(songsDataGridView)

        songsDataGridView.ColumnCount = 5
        With songsDataGridView.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Navy
            .ForeColor = Color.White
            .Font = New Font(songsDataGridView.Font, FontStyle.Bold)
        End With

        With songsDataGridView
            .Name = "songsDataGridView"
            .Location = New Point(8, 8)
            .Size = New Size(500, 250)
            .AutoSizeRowsMode = _
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            .CellBorderStyle = DataGridViewCellBorderStyle.Single
            .GridColor = Color.Black
            .RowHeadersVisible = False

            .Columns(0).Name = "Release Date"
            .Columns(1).Name = "Track"
            .Columns(2).Name = "Title"
            .Columns(3).Name = "Artist"
            .Columns(4).Name = "Album"
            .Columns(4).DefaultCellStyle.Font = _
                New Font(Me.songsDataGridView.DefaultCellStyle.Font, FontStyle.Italic)

            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .Dock = DockStyle.Fill
        End With

    End Sub
    '</Snippet30>

    '<Snippet40>
    Private Sub PopulateDataGridView()

        Dim row0 As String() = {"11/22/1968", "29", "Revolution 9", _
            "Beatles", "The Beatles [White Album]"}
        Dim row1 As String() = {"1960", "6", "Fools Rush In", _
            "Frank Sinatra", "Nice 'N' Easy"}
        Dim row2 As String() = {"11/11/1971", "1", "One of These Days", _
            "Pink Floyd", "Meddle"}
        Dim row3 As String() = {"1988", "7", "Where Is My Mind?", _
            "Pixies", "Surfer Rosa"}
        Dim row4 As String() = {"5/1981", "9", "Can't Find My Mind", _
            "Cramps", "Psychedelic Jungle"}
        Dim row5 As String() = {"6/10/2003", "13", _
            "Scatterbrain. (As Dead As Leaves.)", _
            "Radiohead", "Hail to the Thief"}
        Dim row6 As String() = {"6/30/1992", "3", "Dress", "P J Harvey", "Dry"}

        With Me.songsDataGridView.Rows
            .Add(row0)
            .Add(row1)
            .Add(row2)
            .Add(row3)
            .Add(row4)
            .Add(row5)
            .Add(row6)
        End With

        With Me.songsDataGridView
            .Columns(0).DisplayIndex = 3
            .Columns(1).DisplayIndex = 4
            .Columns(2).DisplayIndex = 0
            .Columns(3).DisplayIndex = 1
            .Columns(4).DisplayIndex = 2
        End With

    End Sub
    '</Snippet40>

    '<Snippet02>

    <STAThreadAttribute()> _
    Public Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    End Sub

End Class
'</Snippet02>
'</Snippet00>