Option Strict On

Public Class Form1


    '--------------------------------------------------------------------------
    Sub Test()

        '<Snippet5>
        Try
            CustomersTableAdapter.Update(NorthwindDataSet)

        Catch ex As DBConcurrencyException

            Dim customErrorMessage As String
            customErrorMessage = "Concurrency violation" & vbCrLf
            customErrorMessage &= CType(ex.Row.Item(0), String)
            MessageBox.Show(customErrorMessage)

            ' Add business logic code to resolve the concurrency violation...

        End Try
        '</Snippet5>
    End Sub


    '--------------------------------------------------------------------------
    '<Snippet2>
    Private Sub CustomersBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomersBindingNavigatorSaveItem.Click
        UpdateDatabase()
    End Sub
    '</Snippet2>


    '--------------------------------------------------------------------------
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwindDataSet.Customers' table. You can move, or remove it, as needed.
        Me.CustomersTableAdapter.Fill(Me.NorthwindDataSet.Customers)
    End Sub


    '--------------------------------------------------------------------------
    '<Snippet1>
    Private Sub UpdateDatabase()

        Try
            Me.CustomersTableAdapter.Update(Me.NorthwindDataSet.Customers)
            MsgBox("Update successful")

        Catch dbcx As Data.DBConcurrencyException
            Dim response As Windows.Forms.DialogResult

            response = MessageBox.Show(CreateMessage(CType(dbcx.Row, NorthwindDataSet.CustomersRow)),
                "Concurrency Exception", MessageBoxButtons.YesNo)

            ProcessDialogResult(response)

        Catch ex As Exception
            MsgBox("An error was thrown while attempting to update the database.")
        End Try
    End Sub
    '</Snippet1>


    '--------------------------------------------------------------------------
    '<Snippet4>
    Private Function CreateMessage(ByVal cr As NorthwindDataSet.CustomersRow) As String
        Return "Database: " & GetRowData(GetCurrentRowInDB(cr), 
                                         Data.DataRowVersion.Default) & vbCrLf &
               "Original: " & GetRowData(cr, Data.DataRowVersion.Original) & vbCrLf &
               "Proposed: " & GetRowData(cr, Data.DataRowVersion.Current) & vbCrLf &
               "Do you still want to update the database with the proposed value?"
    End Function


    '--------------------------------------------------------------------------
    ' This method loads a temporary table with current records from the database
    ' and returns the current values from the row that caused the exception.
    '--------------------------------------------------------------------------
    Private TempCustomersDataTable As New NorthwindDataSet.CustomersDataTable

    Private Function GetCurrentRowInDB(
        ByVal RowWithError As NorthwindDataSet.CustomersRow
        ) As NorthwindDataSet.CustomersRow

        Me.CustomersTableAdapter.Fill(TempCustomersDataTable)

        Dim currentRowInDb As NorthwindDataSet.CustomersRow =
            TempCustomersDataTable.FindByCustomerID(RowWithError.CustomerID)

        Return currentRowInDb
    End Function


    '--------------------------------------------------------------------------
    ' This method takes a CustomersRow and RowVersion 
    ' and returns a string of column values to display to the user.
    '--------------------------------------------------------------------------
    Private Function GetRowData(ByVal custRow As NorthwindDataSet.CustomersRow,
        ByVal RowVersion As Data.DataRowVersion) As String

        Dim rowData As String = ""

        For i As Integer = 0 To custRow.ItemArray.Length - 1
            rowData &= custRow.Item(i, RowVersion).ToString() & " "
        Next

        Return rowData
    End Function
    '</Snippet4>


    '--------------------------------------------------------------------------
    '<Snippet3>
    ' This method takes the DialogResult selected by the user and updates the database 
    ' with the new values or cancels the update and resets the Customers table 
    ' (in the dataset) with the values currently in the database.

    Private Sub ProcessDialogResult(ByVal response As Windows.Forms.DialogResult)

        Select Case response

            Case Windows.Forms.DialogResult.Yes
                NorthwindDataSet.Customers.Merge(TempCustomersDataTable, True)
                UpdateDatabase()

            Case Windows.Forms.DialogResult.No
                NorthwindDataSet.Customers.Merge(TempCustomersDataTable)
                MsgBox("Update cancelled")
        End Select
    End Sub
    '</Snippet3>
End Class
