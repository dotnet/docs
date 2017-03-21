    Public Sub AddSqlParameters()
        ' ...
        ' create categoriesDataSet and categoriesAdapter
        ' ...
        categoriesAdapter.SelectCommand.Parameters.Add( _
            "@CategoryName", SqlDbType.VarChar, 80).Value = "toasters"
        categoriesAdapter.SelectCommand.Parameters.Add( _
            "@SerialNum", SqlDbType.Int).Value = 239
        
        categoriesAdapter.Fill(categoriesDataSet)
    End Sub  