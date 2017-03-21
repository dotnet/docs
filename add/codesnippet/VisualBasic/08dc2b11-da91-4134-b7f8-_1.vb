  Public Sub AddSqlParameter(command As SqlCommand) 
    command.Parameters.Add(New SqlParameter("Description", "Beverages"))
  End Sub