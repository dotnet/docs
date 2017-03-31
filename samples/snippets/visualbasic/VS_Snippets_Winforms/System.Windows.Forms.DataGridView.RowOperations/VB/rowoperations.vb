Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Text

Public Class RowOperations
    Inherits System.Windows.Forms.Form

    Private buttonPanel As New Panel
    Private WithEvents songsDataGridView As New DataGridView
    Private WithEvents addNewRowButton As New Button
    Private WithEvents deleteRowButton As New Button
    Private WithEvents ledgerStyleButton As New Button

    Private Sub RowOperations_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        SetupLayout()

        SetupDataGridView()

        PopulateDataGridView()
    End Sub

    Private Sub SetupLayout()

        Me.Size = New Size(600, 600)

        With addNewRowButton
            .Text = "Add Row"
            .Location = New Point(10, 10)
        End With

        With deleteRowButton
            .Text = "Delete Row"
            .Location = New Point(100, 10)
        End With

        With ledgerStyleButton
            .Text = "Ledger Style"
            .Size = New Size(80, 30)
            .Location = New Point(200, 10)
        End With

        With buttonPanel
            .Controls.Add(addNewRowButton)
            .Controls.Add(deleteRowButton)
            .Controls.Add(ledgerStyleButton)
            .Height = 50
            .Dock = DockStyle.Bottom
        End With

        Me.Controls.Add(Me.buttonPanel)
        Me.Text = "DataGridView row operations"

    End Sub

    Private Sub songsDataGridView_CellFormatting(ByVal sender As Object, _
        ByVal e As DataGridViewCellFormattingEventArgs) _
        Handles songsDataGridView.CellFormatting

        If Me.songsDataGridView.Columns(e.ColumnIndex).Name _
            = "Artist" Then
            If e.Value IsNot Nothing Then

                ' Check for the string "pink" in the cell.
                Dim stringValue As String = _
                    CType(e.Value, String)
                stringValue = stringValue.ToLower()
                If ((stringValue.IndexOf("pink") > -1)) Then
                    e.CellStyle.BackColor = Color.Pink
                    e.CellStyle.ForeColor = Color.Black
                    e.CellStyle.Font = _
                        New Font("Times New Roman", 8, _
                        FontStyle.Bold)
                End If

                ' Set the FormattingApplied property to true 
                ' to show the event is handled.
                e.FormattingApplied = True
            End If
        ElseIf Me.songsDataGridView.Columns(e.ColumnIndex).Name _
            = "Release Date" Then
            ShortFormDateFormat(e)
        End If
    End Sub

    ' Even though the date internaly stores the year as YYYY, 
    ' using formatting, the
    ' UI can have the format in YY.  
    Private Shared Sub ShortFormDateFormat _
        (ByVal formatting As DataGridViewCellFormattingEventArgs)

        If formatting.Value IsNot Nothing Then
            Try
                Dim dateString As StringBuilder = _
                    New StringBuilder()
                Dim theDate As Date = _
                    DateTime.Parse(formatting.Value.ToString())

                dateString.Append(theDate.Month)
                dateString.Append("/")
                dateString.Append(theDate.Day)
                dateString.Append("/")
                dateString.Append(theDate.Year.ToString().Substring(2))
                formatting.Value = dateString.ToString()
                formatting.FormattingApplied = True
            Catch notInDateFormat As FormatException
                ' Set to false in case there are other handlers 
                ' interested trying to
                ' format this DataGridViewCellFormattingEventArgs 
                ' instance.
                formatting.FormattingApplied = False
            End Try
        End If
    End Sub

    Private Sub songsDataGridView_CellParsing(ByVal sender As Object, _
        ByVal e As DataGridViewCellParsingEventArgs) _
        Handles songsDataGridView.CellParsing

        If Me.songsDataGridView.Columns(e.ColumnIndex).Name = _
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
                        ' Set to false in case another 
                        ' CellParsing(handler)
                        ' wants to try to parse this 
                        ' DataGridViewCellParsingEventArgs instance.
                        e.ParsingApplied = False
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
        songsDataGridView.AlternatingRowsDefaultCellStyle = style
        ledgerStyleButton.Enabled = False
    End Sub


    Private Sub SetupDataGridView()

        Me.Controls.Add(songsDataGridView)
        songsDataGridView.ColumnCount = 5

        With songsDataGridView.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Navy
            .ForeColor = Color.White
            .Font = New Font(songsDataGridView.Font, FontStyle.Bold)
        End With

        With songsDataGridView
            .EditMode = DataGridViewEditMode.EditOnEnter
            .Name = "songsDataGridView"
            .Location = New Point(8, 8)
            .Size = New Size(500, 300)
            .AutoSizeRowsMode = _
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            .ColumnHeadersBorderStyle = _
                DataGridViewHeaderBorderStyle.Raised
            .CellBorderStyle = _
                DataGridViewCellBorderStyle.Single
            .GridColor = SystemColors.ActiveBorder
            .Columns(0).Name = "Release Date"
            .Columns(1).Name = "Track"
            .Columns(1).DefaultCellStyle.Alignment = _
                DataGridViewContentAlignment.MiddleCenter
            .Columns(2).Name = "Title"
            .Columns(3).Name = "Artist"
            .Columns(4).Name = "Album"
            .Columns(4).DefaultCellStyle.Font = _
                New Font(Control.DefaultFont, _
                    FontStyle.Italic)
            .SelectionMode = _
                DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False

            ' Set the non-cell background color.
            .BackgroundColor = Color.Honeydew

            .Dock = DockStyle.Fill
        End With

    End Sub

    Private Sub PopulateDataGridView()

        ' Create the string array for each row of data.
        Dim row0 As String() = {"11/22/1968", "29", "Revolution 9", _
            "Beatles", "The Beatles [White Album]"}
        Dim row1 As String() = {"4/4/1960", "6", "Fools Rush In", _
            "Frank Sinatra", "Nice 'N' Easy"}
        Dim row2 As String() = {"11/11/1971", "1", _
            "One of These Days", "Pink Floyd", "Meddle"}
        Dim row3 As String() = {"4/4/1988", "7", _
            "Where Is My Mind?", _
            "Pixies", "Surfer Rosa"}
        Dim row4 As String() = {"5/1981", "9", _
            "Can't Find My Mind", _
            "Cramps", "Psychedelic Jungle"}
        Dim row5 As String() = {"6/10/2003", "13", _
            "Scatterbrain. (As Dead As Leaves.)", "Radiohead", _
            "Hail to the Thief"}
        Dim row6 As String() = {"6/30/1992", "3", "Dress", _
            "P J Harvey", "Dry"}

        ' Add a row for each string array.
        With Me.songsDataGridView.Rows
            .Add(row0)
            .Add(row1)
            .Add(row2)
            .Add(row3)
            .Add(row4)
            .Add(row5)
            .Add(row6)
        End With

        ' Change the order the columns are displayed.
        With Me.songsDataGridView
            .Columns(0).DisplayIndex = 3
            .Columns(1).DisplayIndex = 4
            .Columns(2).DisplayIndex = 0
            .Columns(3).DisplayIndex = 1
            .Columns(4).DisplayIndex = 2
        End With

    End Sub

    Public Shared Sub Main()
        Application.Run(New RowOperations)
    End Sub

#Region "Row validation"
    '<snippet5>
    Private Sub ValidateByRow(ByVal sender As Object, _
        ByVal data As DataGridViewCellCancelEventArgs) _
        Handles songsDataGridView.RowValidating

        Dim row As DataGridViewRow = _
            songsDataGridView.Rows(data.RowIndex)
        Dim trackCell As DataGridViewCell = _
            row.Cells(songsDataGridView.Columns("Track").Index)
        Dim dateCell As DataGridViewCell = _
            row.Cells(songsDataGridView.Columns("Release Date").Index)
        data.Cancel = Not (IsTrackGood(trackCell) _
            AndAlso IsDateGood(dateCell))
    End Sub

    Private Function IsTrackGood(ByRef cell As DataGridViewCell) As Boolean

        If cell.Value.ToString().Length = 0 Then
            cell.ErrorText = "Please enter a track"
            songsDataGridView.Rows(cell.RowIndex).ErrorText = _
                "Please enter a track"
            Return False
        ElseIf cell.Value.ToString().Equals("0") Then
            cell.ErrorText = "Zero is not a valid track"
            songsDataGridView.Rows(cell.RowIndex).ErrorText = _
                "Zero is not a valid track"
            Return False
        ElseIf Not Integer.TryParse( _
            cell.Value.ToString(), New Integer()) Then
            cell.ErrorText = "A Track must be a number"
            songsDataGridView.Rows(cell.RowIndex).ErrorText = _
                "A Track must be a number"
            Return False
        End If
        Return True
    End Function

    Private Function IsDateGood(ByRef cell As DataGridViewCell) As Boolean

        If cell.Value Is Nothing Then
            cell.ErrorText = "Missing date"
            songsDataGridView.Rows(cell.RowIndex).ErrorText = _
                "Missing date"
            Return False
        Else
            Try
                DateTime.Parse(cell.Value.ToString())
            Catch ex As FormatException

                cell.ErrorText = "Invalid format"
                songsDataGridView.Rows(cell.RowIndex).ErrorText = _
                    "Invalid format"

                Return False
            End Try
        End If
        Return True
    End Function
    '</snippet5>

    '<snippet10>
    Private Sub RemoveAnnotations(ByVal sender As Object, _
        ByVal args As DataGridViewCellEventArgs) _
        Handles songsDataGridView.RowValidated

        For Each cell As DataGridViewCell In _
            songsDataGridView.Rows(args.RowIndex).Cells
            cell.ErrorText = String.Empty
        Next

        For Each row As DataGridViewRow In songsDataGridView.Rows
            row.ErrorText = String.Empty
        Next

    End Sub
    '</snippet10>
#End Region

End Class