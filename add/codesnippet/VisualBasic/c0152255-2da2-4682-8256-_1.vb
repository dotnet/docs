  Public Sub AddSqlParameter(command As SqlCommand) 
    Dim param As SqlParameter = New SqlParameter( _
        "@Description", SqlDbType.NVarChar, 16)
    param.Value = "Beverages"
    command.Parameters.Add(param)
  End Sub