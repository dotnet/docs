Public Class Class1

    '--------------------------------------------------------------------------
    Sub OtherSnips1()

        '--------------------------------------------------
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter()
        Dim Dataset1 As New Data.DataSet()
        Dataset1.Tables.Add(New System.Data.DataTable("Table1"))

        '<Snippet26>
        Try
            SqlDataAdapter1.Update(Dataset1.Tables("Table1"))

        Catch x As Exception
            ' Error during Update, add code to locate error, reconcile 
            ' and try to update again.
        End Try
        '</Snippet26>


        '--------------------------------------------------
        Dim NorthwindDataSet As New NorthwindDataSet()

        '<Snippet12>
        Dim xmlData As String = NorthwindDataSet.GetXml()
        '</Snippet12>

        '<Snippet13>
        Dim filePath As String = "ENTER A VALID FILEPATH"
        NorthwindDataSet.WriteXml(filePath)
        '</Snippet13>


        '--------------------------------------------------
        '<Snippet15>
        Dim regionTableAdapter As New NorthwindDataSetTableAdapters.RegionTableAdapter

        regionTableAdapter.Insert(5, "NorthWestern")
        '</Snippet15>


        '--------------------------------------------------
        '<Snippet16>
        Dim sqlConnection1 As New System.Data.SqlClient.SqlConnection("YOUR CONNECTION STRING")

        Dim cmd As New System.Data.SqlClient.SqlCommand
        cmd.CommandType = System.Data.CommandType.Text
        cmd.CommandText = "INSERT Region (RegionID, RegionDescription) VALUES (5, 'NorthWestern')"
        cmd.Connection = sqlConnection1

        sqlConnection1.Open()
        cmd.ExecuteNonQuery()
        sqlConnection1.Close()
        '</Snippet16>
    End Sub


    '--------------------------------------------------------------------------
    Sub OtherSnips2()

        '--------------------------------------------------
        '<Snippet18>
        Dim regionTableAdapter As New NorthwindDataSetTableAdapters.RegionTableAdapter

        regionTableAdapter.Update(1, "East", 1, "Eastern")
        '</Snippet18>


        '--------------------------------------------------
        '<Snippet19>
        Dim sqlConnection1 As New System.Data.SqlClient.SqlConnection("YOUR CONNECTION STRING")

        Dim cmd As New System.Data.SqlClient.SqlCommand
        cmd.CommandType = System.Data.CommandType.Text
        cmd.CommandText = "UPDATE Region SET [RegionDescription] = @RegionDescription WHERE [RegionID] = @RegionID"
        cmd.Parameters.AddWithValue("@RegionDescription", "East")
        cmd.Parameters.AddWithValue("@RegionID", "1")
        cmd.Connection = sqlConnection1

        sqlConnection1.Open()
        cmd.ExecuteNonQuery()
        sqlConnection1.Close()
        '</Snippet19>
    End Sub


    '--------------------------------------------------------------------------
    Sub OtherSnips3()

        '--------------------------------------------------
        '<Snippet21>
        Dim regionTableAdapter As New NorthwindDataSetTableAdapters.RegionTableAdapter

        regionTableAdapter.Delete(5, "NorthWestern")
        '</Snippet21>


        '--------------------------------------------------
        '<Snippet22>
        Dim sqlConnection1 As New System.Data.SqlClient.SqlConnection("YOUR CONNECTION STRING")

        Dim cmd As New System.Data.SqlClient.SqlCommand
        cmd.CommandType = System.Data.CommandType.Text
        cmd.CommandText = "DELETE Region WHERE RegionID = 5 AND RegionDescription = 'NorthWestern'"
        cmd.Connection = sqlConnection1

        sqlConnection1.Open()
        cmd.ExecuteNonQuery()
        sqlConnection1.Close()
        '</Snippet22>
    End Sub


    '--------------------------------------------------------------------------
    Dim dsNorthwind1 As New NorthwindDataSet()
    Dim daOrders As New Data.SqlClient.SqlDataAdapter()
    Dim daCustomers As New Data.SqlClient.SqlDataAdapter()

    '<Snippet28>
    Private Sub UpdateDB()
        Dim DeletedChildRecords As DataTable =
            dsNorthwind1.Orders.GetChanges(DataRowState.Deleted)

        Dim NewChildRecords As DataTable =
            dsNorthwind1.Orders.GetChanges(DataRowState.Added)

        Dim ModifiedChildRecords As DataTable =
            dsNorthwind1.Orders.GetChanges(DataRowState.Modified)

        Try
            If Not DeletedChildRecords Is Nothing Then
                daOrders.Update(DeletedChildRecords)
            End If

            daCustomers.Update(dsNorthwind1, "Customers")

            If Not NewChildRecords Is Nothing Then
                daOrders.Update(NewChildRecords)
            End If

            If Not ModifiedChildRecords Is Nothing Then
                daOrders.Update(ModifiedChildRecords)
            End If

            dsNorthwind1.AcceptChanges()

        Catch ex As Exception
            ' Update error, resolve and try again

        Finally
            If Not DeletedChildRecords Is Nothing Then
                DeletedChildRecords.Dispose()
            End If

            If Not NewChildRecords Is Nothing Then
                NewChildRecords.Dispose()
            End If

            If Not ModifiedChildRecords Is Nothing Then
                ModifiedChildRecords.Dispose()
            End If
        End Try
    End Sub
    '</Snippet28>
End Class
