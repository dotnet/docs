Imports System.Data.SqlClient

Public Class Form2

    '--------------------------------------------------------------------------
    Private Sub TestTyped()

        '<Snippet4>
        Me.CustomersTableAdapter.Fill(Me.NorthwindDataSet.Customers)
        '</Snippet4>


        '<Snippet5>
        CustomersTableAdapter.FillByCity(NorthwindDataSet.Customers, "Seattle")
        CustomersTableAdapter.FillByCityAndState(NorthwindDataSet.Customers, "Seattle", "WA")
        '</Snippet5>
    End Sub


    '--------------------------------------------------------------------------
    Private Sub TestUnTyped()
        Dim sqlDataAdapter1 As New SqlClient.SqlDataAdapter()
        Dim dataset1 As New Data.DataSet()
        dataset1.Tables.Add(New System.Data.DataTable("Customers"))

        '<Snippet6>
        sqlDataAdapter1.Fill(dataset1.Tables("Customers"))
        '</Snippet6>
    End Sub


    '--------------------------------------------------------------------------
    Private Sub Parameters()
        Dim oleDbCommand1 As New OleDb.OleDbCommand
        Dim oleDbConnection1 As New OleDb.OleDbConnection

        '<Snippet16>
        With oleDbCommand1
            .CommandText = "UpdateAuthor"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters("au_id").Value = "172-32-1176"
            .Parameters("au_lname").Value = "White"
            .Parameters("au_fname").Value = "Johnson"
        End With

        OleDbConnection1.Open()
        oleDbCommand1.ExecuteNonQuery()
        OleDbConnection1.Close()
        '</Snippet16>


        '<Snippet17>
        Dim returnValue As Integer

        oleDbCommand1.CommandText = "CountAuthors"
        oleDbCommand1.CommandType = CommandType.StoredProcedure

        oleDbConnection1.Open()
        oleDbCommand1.ExecuteNonQuery()
        oleDbConnection1.Close()

        returnValue = CType(oleDbCommand1.Parameters("retvalue").Value, Integer)
        MessageBox.Show("Return Value = " & returnValue.ToString())
        '</Snippet17>
    End Sub


   '--------------------------------------------------------------------------
    Private Sub TestTableAdapter1()

        '<Snippet7>
        Dim tableAdapter As New NorthwindDataSetTableAdapters.CustomersTableAdapter()
        tableAdapter.FillByCity(NorthwindDataSet.Customers, "Seattle")
        '</Snippet7>


        '<Snippet8>
        Dim sqlConnection1 As New SqlConnection("Your Connection String")
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader

        cmd.CommandText = "SELECT * FROM Customers"
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlConnection1

        sqlConnection1.Open()

        reader = cmd.ExecuteReader()
        ' Data is accessible through the DataReader object here.

        sqlConnection1.Close()
        '</Snippet8>
    End Sub


    '--------------------------------------------------------------------------
    Private Sub TestTableAdapter1C()

        '<Snippet13>
        Dim sqlConnection1 As New SqlConnection("Your Connection String")
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader

        cmd.CommandText = "StoredProcedureName"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Connection = sqlConnection1

        sqlConnection1.Open()

        reader = cmd.ExecuteReader()
        ' Data is accessible through the DataReader object here.

        sqlConnection1.Close()
        '</Snippet13>
    End Sub


    '--------------------------------------------------------------------------
    Private Sub TestTableAdapter2()

        '<Snippet9>
        Dim tableAdapter As New NorthwindDataSetTableAdapters.CustomersTableAdapter()

        Dim returnValue As Integer
        returnValue = CType(tableAdapter.GetCustomerCount(), Integer)
        '</Snippet9>
    End Sub


    '--------------------------------------------------------------------------
    Private Sub TestTableAdapter2B()

        '<Snippet10>
        Dim sqlConnection1 As New SqlConnection("Your Connection String")
        Dim cmd As New SqlCommand
        Dim returnValue As Object

        cmd.CommandText = "SELECT COUNT(*) FROM Customers"
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlConnection1

        sqlConnection1.Open()

        returnValue = cmd.ExecuteScalar()

        sqlConnection1.Close()
        '</Snippet10>
    End Sub


    '--------------------------------------------------------------------------
    Private Sub TestTableAdapter2C()

        '<Snippet14>
        Dim sqlConnection1 As New SqlConnection("Your Connection String")
        Dim cmd As New SqlCommand
        Dim returnValue As Object

        cmd.CommandText = "StoredProcedureName"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Connection = sqlConnection1

        sqlConnection1.Open()

        returnValue = cmd.ExecuteScalar()

        sqlConnection1.Close()
        '</Snippet14>
    End Sub


    '--------------------------------------------------------------------------
    Private Sub TestTableAdapter3()

        '<Snippet11>
        Dim tableAdapter As New NorthwindDataSetTableAdapters.CustomersTableAdapter()

        Dim rowsAffected As Integer
        rowsAffected = CType(tableAdapter.UpdateContactTitle("Sales Manager", "ALFKI"), Integer)
        '</Snippet11>
    End Sub


    '--------------------------------------------------------------------------
    Private Sub TestTableAdapter3B()

        '<Snippet12>
        Dim sqlConnection1 As New SqlConnection("Your Connection String")
        Dim cmd As New SqlCommand
        Dim rowsAffected As Integer

        cmd.CommandText = "UPDATE Customers SET ContactTitle = 'Sales Manager' WHERE CustomerID = 'ALFKI'"
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlConnection1

        sqlConnection1.Open()

        rowsAffected = cmd.ExecuteNonQuery()

        sqlConnection1.Close()
        '</Snippet12>
    End Sub


    '--------------------------------------------------------------------------
    Private Sub TestTableAdapter3C()

        '<Snippet15>
        Dim sqlConnection1 As New SqlConnection("Your Connection String")
        Dim cmd As New SqlCommand
        Dim rowsAffected As Integer

        cmd.CommandText = "StoredProcedureName"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Connection = sqlConnection1

        sqlConnection1.Open()

        rowsAffected = cmd.ExecuteNonQuery()

        sqlConnection1.Close()
        '</Snippet15>

    End Sub


    '--------------------------------------------------------------------------
    Private Sub CustomersBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomersBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.CustomersBindingSource.EndEdit()
        Me.CustomersTableAdapter.Update(Me.NorthwindDataSet.Customers)
    End Sub
End Class