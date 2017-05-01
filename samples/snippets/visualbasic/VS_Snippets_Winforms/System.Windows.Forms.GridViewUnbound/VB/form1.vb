Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

    Private buttonPanel As New FlowLayoutPanel
    Private WithEvents dataGridView1 As New DataGridView
    Private WithEvents addNewRowButton As New Button
    Private WithEvents deleteRowButton As New Button
    Private WithEvents ledgerStyleButton As New Button

    Private Sub Form1_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        SetUpLayout()

        SetUpDataGridView()
        StyleCells()

        PopulateDataGridView()
    End Sub

    ' Set up the button and button panel.
    Private Sub SetUpLayout()

        Me.Size = New Size(600, 600)
        Me.addNewRowButton.Text = "Add Row"
        Me.deleteRowButton.Text = "Delete Row"
        Me.ledgerStyleButton.Text = "Ledger Style"
        Me.buttonPanel.Controls.AddRange(New Control() _
            {addNewRowButton, deleteRowButton, ledgerStyleButton})
        Me.buttonPanel.Dock = DockStyle.Bottom
        Me.Controls.Add(Me.buttonPanel)

    End Sub

    '<snippet1>
    Private Sub dataGridView1_CellFormatting(ByVal sender As Object, _
        ByVal e As DataGridViewCellFormattingEventArgs) _
        Handles dataGridView1.CellFormatting
        ' If the column is the Artist column, check the
        ' value.
        If Me.dataGridView1.Columns(e.ColumnIndex).Name _
            = "Artist" Then
            If e.Value IsNot Nothing Then

                ' Check for the string "pink" in the cell.
                Dim stringValue As String = _
                CType(e.Value, String)
                stringValue = stringValue.ToLower()
                If ((stringValue.IndexOf("pink") > -1)) Then
                    e.CellStyle.BackColor = Color.Pink
                End If

            End If
        ElseIf Me.dataGridView1.Columns(e.ColumnIndex).Name _
            = "Release Date" Then
            ShortFormDateFormat(e)
        End If
    End Sub

    'Even though the date internaly stores the year as YYYY, using formatting, the
    'UI can have the format in YY.  
    Private Shared Sub ShortFormDateFormat(ByVal formatting As DataGridViewCellFormattingEventArgs)
        If formatting.Value IsNot Nothing Then
            Try
                Dim dateString As System.Text.StringBuilder = New System.Text.StringBuilder()
                Dim theDate As Date = DateTime.Parse(formatting.Value.ToString())

                dateString.Append(theDate.Month)
                dateString.Append("/")
                dateString.Append(theDate.Day)
                dateString.Append("/")
                dateString.Append(theDate.Year.ToString().Substring(2))
                formatting.Value = dateString.ToString()
                formatting.FormattingApplied = True
            Catch notInDateFormat As FormatException
                ' Set to false in case there are other handlers interested trying to
                ' format this DataGridViewCellFormattingEventArgs instance.
                formatting.FormattingApplied = False
            End Try
        End If
    End Sub
    '</snippet1>

    '<snippet2>
    ' Handling CellParsing allows one to accept user input, then map it to a different
    ' internal representation.
    Private Sub dataGridView1_CellParsing(ByVal sender As Object, _
        ByVal e As DataGridViewCellParsingEventArgs) _
        Handles dataGridView1.CellParsing

        If Me.dataGridView1.Columns(e.ColumnIndex).Name = _
            "Release Date" Then
            If e IsNot Nothing Then
                If e.Value IsNot Nothing Then
                    Try
                        ' Map what the user typed into UTC.
                        e.Value = _
                        DateTime.Parse(e.Value.ToString()).ToUniversalTime()
                        ' Set the ParsingApplied property to 
                        ' Show the event is handled.
                        e.ParsingApplied = True

                    Catch ex As FormatException
                        ' Set to false in case another CellParsing handler
                        ' wants to try to parse this DataGridViewCellParsingEventArgs instance.
                        e.ParsingApplied = False
                    End Try
                End If
            End If
        End If
    End Sub
    '</snippet2>

    '<snippet3>
    Private Sub addNewRowButton_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles addNewRowButton.Click

        Me.dataGridView1.Rows.Add()
    End Sub
    '</snippet3>

    '<snippet4>
    Private Sub deleteRowButton_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles deleteRowButton.Click

        If Me.dataGridView1.SelectedRows.Count > 0 AndAlso _
           Not Me.dataGridView1.SelectedRows(0).Index = _
           Me.dataGridView1.Rows.Count - 1 Then

            Me.dataGridView1.Rows.RemoveAt( _
                Me.dataGridView1.SelectedRows(0).Index)
        End If
    End Sub
    '</snippet4>

    '<snippet8>
    '<snippet7>
    Private Sub ledgerStyleButton_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles ledgerStyleButton.Click

        ' Create a new cell style.
        Dim style As New DataGridViewCellStyle
        With style
            .BackColor = Color.Beige
            .ForeColor = Color.Brown
            .Font = New Font("Verdana", 8)
        End With

        ' Apply the style as the default cell style.
        dataGridView1.AlternatingRowsDefaultCellStyle = style
        ledgerStyleButton.Enabled = False
    End Sub
    '</snippet7>

    '<snippet5>
    Private Sub SetUpDataGridView()

        Me.Controls.Add(dataGridView1)
        dataGridView1.ColumnCount = 5

        With dataGridView1.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Navy
            .ForeColor = Color.White
            .Font = New Font(dataGridView1.Font, FontStyle.Bold)
        End With

        With dataGridView1
            .EditMode = DataGridViewEditMode.EditOnEnter
            .Name = "dataGridView1"
            .Location = New Point(8, 8)
            .Size = New Size(500, 300)
            .AutoSizeRowsMode = _
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            .ColumnHeadersBorderStyle = _
                DataGridViewHeaderBorderStyle.Raised
            .CellBorderStyle = _
                DataGridViewCellBorderStyle.Single
            .GridColor = SystemColors.ActiveBorder
            .RowHeadersVisible = False

            .Columns(0).Name = "Release Date"
            .Columns(1).Name = "Track"
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(2).Name = "Title"
            .Columns(3).Name = "Artist"
            .Columns(4).Name = "Album"

            ' Make the font italic for row four.
            .Columns(4).DefaultCellStyle.Font = _
                New Font(Control.DefaultFont, _
                    FontStyle.Italic)

            .SelectionMode = _
                DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False

            .BackgroundColor = Color.Honeydew

            .Dock = DockStyle.Fill
        End With

    End Sub
    '</snippet5>

    '<snippet6>
    Private Sub PopulateDataGridView()

        ' Create the string array for each row of data.
        Dim row0 As String() = {"11/22/1968", "29", "Revolution 9", "Beatles", "The Beatles [White Album]"}
        Dim row1 As String() = {"4/4/1960", "6", "Fools Rush In", _
            "Frank Sinatra", "Nice 'N' Easy"}
        Dim row2 As String() = {"11/11/1971", "1", _
            "One of These Days", "Pink Floyd", "Meddle"}
        Dim row3 As String() = {"4/4/1988", "7", "Where Is My Mind?", _
            "Pixies", "Surfer Rosa"}
        Dim row4 As String() = {"5/1981", "9", "Can't Find My Mind", _
            "Cramps", "Psychedelic Jungle"}
        Dim row5 As String() = {"6/10/2003", "13", _
            "Scatterbrain. (As Dead As Leaves.)", "Radiohead", _
            "Hail to the Thief"}
        Dim row6 As String() = {"6/30/1992", "3", "Dress", _
            "P J Harvey", "Dry"}

        ' Add a row for each string array.
        With Me.dataGridView1.Rows
            .Add(row0)
            .Add(row1)
            .Add(row2)
            .Add(row3)
            .Add(row4)
            .Add(row5)
            .Add(row6)
        End With

        ' Change the order the columns are displayed.
        With Me.dataGridView1
            .Columns(0).DisplayIndex = 3
            .Columns(1).DisplayIndex = 4
            .Columns(2).DisplayIndex = 0
            .Columns(3).DisplayIndex = 1
            .Columns(4).DisplayIndex = 2
        End With

    End Sub
    '</snippet6>
    '</snippet8>

    <STAThreadAttribute()> _
    Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

#Region "snippet9 cell validating"
    '<snippet9>
    Private Sub dataGridView1_CellValidating(ByVal sender As Object, _
        ByVal e As _
        DataGridViewCellValidatingEventArgs) _
        Handles dataGridView1.CellValidating

        Dim column As DataGridViewColumn = _
            dataGridView1.Columns(e.ColumnIndex)

        If column.Name = "Track" Then
            CheckTrack(e)
        ElseIf column.Name = "Release Date" Then
            CheckDate(e)
        End If
    End Sub

    Private Shared Sub CheckTrack(ByVal newValue As DataGridViewCellValidatingEventArgs)
        If String.IsNullOrEmpty(newValue.FormattedValue.ToString()) Then
            NotifyUserAndForceRedo("Please enter a track", newValue)
        ElseIf Not Integer.TryParse( _
            newValue.FormattedValue.ToString(), New Integer()) Then
            NotifyUserAndForceRedo("A Track must be a number", newValue)
        ElseIf Integer.Parse(newValue.FormattedValue.ToString()) < 1 Then
            NotifyUserAndForceRedo("Not a valid track", newValue)
        End If
    End Sub

    Private Shared Sub NotifyUserAndForceRedo(ByVal errorMessage As String, ByVal newValue As DataGridViewCellValidatingEventArgs)
        MessageBox.Show(errorMessage)
        newValue.Cancel = True
    End Sub

    Private Sub CheckDate(ByVal newValue As DataGridViewCellValidatingEventArgs)
        Try
            DateTime.Parse(newValue.FormattedValue.ToString()).ToLongDateString()
            AnnotateCell(String.Empty, newValue)
        Catch ex As FormatException
            AnnotateCell("You did not enter a valid date.", newValue)
        End Try
    End Sub

    Private Sub AnnotateCell(ByVal errorMessage As String, _
        ByVal editEvent As DataGridViewCellValidatingEventArgs)

        Dim cell As DataGridViewCell = _
            dataGridView1.Rows(editEvent.RowIndex).Cells( _
                editEvent.ColumnIndex)
        cell.ErrorText = errorMessage
    End Sub
    '</snippet9>
#End Region

#Region "snippet10 cell border style"
    '<snippet10>
    Private Sub StyleCells()
        dataGridView1.CellBorderStyle = _
            DataGridViewCellBorderStyle.None
        dataGridView1.CellBorderStyle = _
            DataGridViewCellBorderStyle.Single
    End Sub
    '</snippet10>
#End Region
End Class