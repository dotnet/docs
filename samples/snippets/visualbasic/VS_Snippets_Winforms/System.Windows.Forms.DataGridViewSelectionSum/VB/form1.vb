'<snippet00>
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form

    Private WithEvents DataGridView1 As New DataGridView()
    Private FlowLayoutPanel1 As New FlowLayoutPanel()
    Private Label1 As New Label()
    Private Label2 As New Label()
    Private Label3 As New Label()
    Private Label4 As New Label()

    ' Establish the main entry point for the application.
    <STAThreadAttribute()> _
    Public Shared Sub Main()
        Application.Run(New Form1())
    End Sub

    Public Sub New()

        ' Set the FlowLayoutPanel1 properties.
        With Me
            .AutoSize = True

            With .FlowLayoutPanel1
                .FlowDirection = FlowDirection.TopDown
                .Location = New System.Drawing.Point(354, 0)
                .AutoSize = True
                .Controls.Add(Label1)
                .Controls.Add(Label2)
                .Controls.Add(Label3)
                .Controls.Add(Label4)
            End With

            .Controls.Add(Me.FlowLayoutPanel1)
            .Controls.Add(DataGridView1)


            ' Set the Label properties.
            .Label1.AutoSize = True
            .Label2.AutoSize = True
            .Label3.AutoSize = True

            .PopulateDataGridView()
            .UpdateLabelText()
            .UpdateBalance()
        End With
    End Sub

    ' Replace this with your own code to populate the DataGridView.
    Private Sub PopulateDataGridView()
        With Me.DataGridView1
            .Size = New Size(350, 400)
            .AllowUserToDeleteRows = True

            ' Add columns to the DataGridView.
            .ColumnCount = 4
            .SelectionMode = DataGridViewSelectionMode.RowHeaderSelect

            ' Set the properties of the DataGridView columns.
            .Columns(0).Name = "Description"
            .Columns(1).Name = "Withdrawals"
            .Columns(2).Name = "Deposits"
            .Columns(3).Name = "Balance"
            .Columns("Description").HeaderText = "Description"
            .Columns("Withdrawals").HeaderText = "W(-)"
            .Columns("Deposits").HeaderText = "D(+)"
            .Columns("Balance").HeaderText = "Balance"
            .Columns("Balance").ReadOnly = True
            .Columns("Description").SortMode = _
                DataGridViewColumnSortMode.NotSortable
            .Columns("Withdrawals").SortMode = _
                DataGridViewColumnSortMode.NotSortable
            .Columns("Deposits").SortMode = _
                DataGridViewColumnSortMode.NotSortable
            .Columns("Balance").SortMode = _
                DataGridViewColumnSortMode.NotSortable
        End With

        ' Add rows of data to the DataGridView.
        With Me.DataGridView1.Rows
            .Add(New String() {"Starting Balance", "", "", "1000"})
            .Add(New String() {"Paycheck Deposit", "", "850", ""})
            .Add(New String() {"Rent", "-500", "", ""})
            .Add(New String() {"Groceries", "-25", "", ""})
            .Add(New String() {"Tax Return", "", "300", ""})
        End With

        ' Allow the user to edit the starting balance cell
        DataGridView1.Rows(0).ReadOnly = True
        DataGridView1.Rows(0).Cells("Balance").ReadOnly = False

        ' Autosize the columns.
        Me.DataGridView1.AutoResizeColumns()

    End Sub

    '<snippet30>
    Private Sub CellValueChanged(ByVal sender As Object, _
        ByVal e As DataGridViewCellEventArgs) _
        Handles DataGridView1.CellValueChanged

        ' Update the balance column whenever the values of any cell changes.
        UpdateBalance()
    End Sub

    Private Sub RowsRemoved(ByVal sender As Object, _
        ByVal e As DataGridViewRowsRemovedEventArgs) _
        Handles DataGridView1.RowsRemoved

        ' Update the balance column whenever rows are deleted.
        UpdateBalance()
    End Sub

    Private Sub UpdateBalance()
        Dim counter As Integer
        Dim balance As Integer
        Dim deposit As Integer
        Dim withdrawal As Integer

        ' Iterate through the rows, skipping the Starting Balance Row.
        For counter = 1 To (DataGridView1.Rows.Count - 2)
            deposit = 0
            withdrawal = 0
            balance = Integer.Parse(DataGridView1.Rows(counter - 1) _
                .Cells("Balance").Value.ToString())

            If Not DataGridView1.Rows(counter) _
                .Cells("Deposits").Value Is Nothing Then

                ' Verify that the cell value is not an empty string.
                If Not DataGridView1.Rows(counter) _
                    .Cells("Deposits").Value.ToString().Length = 0 Then
                    deposit = Integer.Parse(DataGridView1.Rows(counter) _
                        .Cells("Deposits").Value.ToString())
                End If
            End If

            If Not DataGridView1.Rows(counter) _
                .Cells("Withdrawals").Value Is Nothing Then
                If Not DataGridView1.Rows(counter) _
                    .Cells("Withdrawals").Value.ToString().Length = 0 Then
                    withdrawal = Integer.Parse(DataGridView1.Rows(counter) _
                        .Cells("Withdrawals").Value.ToString())
                End If
            End If

            DataGridView1.Rows(counter).Cells("Balance").Value = _
                (balance + deposit + withdrawal).ToString()
        Next
    End Sub
    '</snippet30>

    Private Sub SelectionChanged(ByVal sender As Object, _
        ByVal e As EventArgs) Handles DataGridView1.SelectionChanged

        ' Update the labels to reflect changes to the selection.
        UpdateLabelText()
    End Sub

    '<snippet40>
    Private Sub UserAddedRow(ByVal sender As Object, _
        ByVal e As DataGridViewRowEventArgs) _
        Handles DataGridView1.UserAddedRow

        ' Update the labels to reflect changes to the number of entries.
        UpdateLabelText()
    End Sub

    '<snippet10>
    Private Sub UpdateLabelText()
        Dim WithdrawalTotal As Integer = 0
        Dim DepositTotal As Integer = 0
        Dim SelectedCellTotal As Integer = 0
        Dim counter As Integer

        ' Iterate through all the rows and sum up the appropriate columns.
        For counter = 0 To (DataGridView1.Rows.Count - 1)
            If Not DataGridView1.Rows(counter) _
                .Cells("Withdrawals").Value Is Nothing Then

                If Not DataGridView1.Rows(counter) _
                    .Cells("Withdrawals").Value.ToString().Length = 0 Then

                    WithdrawalTotal += _
                        Integer.Parse(DataGridView1.Rows(counter) _
                        .Cells("Withdrawals").Value.ToString())
                End If
            End If

            If Not DataGridView1.Rows(counter) _
                .Cells("Deposits").Value Is Nothing Then

                If Not DataGridView1.Rows(counter) _
                    .Cells("Deposits").Value.ToString().Length = 0 Then

                    DepositTotal += _
                        Integer.Parse(DataGridView1.Rows(counter) _
                        .Cells("Deposits").Value.ToString())
                End If
            End If
        Next

        ' Iterate through the SelectedCells collection and sum up the values.
        For counter = 0 To (DataGridView1.SelectedCells.Count - 1)
            If DataGridView1.SelectedCells(counter).FormattedValueType Is _
            Type.GetType("System.String") Then

                Dim value As String = Nothing

                ' If the cell contains a value that has not been commited,
                ' use the modified value.
                If (DataGridView1.IsCurrentCellDirty = True) Then

                    value = DataGridView1.SelectedCells(counter) _
                        .EditedFormattedValue.ToString()
                Else

                    value = DataGridView1.SelectedCells(counter) _
                        .FormattedValue.ToString()
                End If

                If value IsNot Nothing Then

                    ' Ignore cells in the Description column.
                    If Not DataGridView1.SelectedCells(counter).ColumnIndex = _
                        DataGridView1.Columns("Description").Index Then

                        If Not value.Length = 0 Then
                            SelectedCellTotal += Integer.Parse(value)
                        End If
                    End If
                End If
            End If

        Next

        ' Set the labels to reflect the current state of the DataGridView.
        Label1.Text = "Withdrawals Total: " & WithdrawalTotal.ToString()
        Label2.Text = "Deposits Total: " & DepositTotal.ToString()
        Label3.Text = "Selected Cells Total: " & SelectedCellTotal.ToString()
        Label4.Text = "Total entries: " & DataGridView1.RowCount.ToString()
    End Sub
    '</snippet10>
    '</snippet40>

    Private Sub CellValidating(ByVal sender As Object, _
        ByVal e As DataGridViewCellValidatingEventArgs) _
        Handles DataGridView1.CellValidating

        Dim testInteger As Integer

        If Not e.ColumnIndex = 0 Then
            If Not e.FormattedValue.ToString().Length = 0 Then

                ' Try to convert the cell value to an Integer.
                If Not Integer.TryParse(e.FormattedValue.ToString(), _
                    testInteger) Then

                    DataGridView1.Rows(e.RowIndex).ErrorText = _
                        "Error: Invalid entry"

                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    '<snippet50>
    Private Sub CellValidated(ByVal sender As Object, _
        ByVal e As DataGridViewCellEventArgs) _
        Handles DataGridView1.CellValidated

        ' Clear any error messages that may have been set in cell validation.
        DataGridView1.Rows(e.RowIndex).ErrorText = Nothing
    End Sub
    '</snippet50>

    '<snippet20>
    Private Sub UserDeletingRow(ByVal sender As Object, _
        ByVal e As DataGridViewRowCancelEventArgs) _
        Handles DataGridView1.UserDeletingRow

        Dim startingBalanceRow As DataGridViewRow = DataGridView1.Rows(0)

        ' Check if the starting balance row is included in the selected rows
        If DataGridView1.SelectedRows.Contains(startingBalanceRow) Then
            ' Do not allow the user to delete the Starting Balance row.
            MessageBox.Show("Cannot delete Starting Balance row!")

            ' Cancel the deletion if the Starting Balance row is included.
            e.Cancel = True
        End If
    End Sub
    '</snippet20>

End Class
'</snippet00>