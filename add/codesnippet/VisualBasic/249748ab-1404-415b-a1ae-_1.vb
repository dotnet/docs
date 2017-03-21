  Public Sub AddSqlParameter(command As SqlCommand) 
    Dim param As SqlParameter = command.Parameters.Add( _
        "@Description", SqlDbType.NVarChar)
    param.Size = 16
    param.Value = "Beverages"
  End Sub