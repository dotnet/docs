    Public Sub CreateMyProc(ByVal connection As OdbcConnection)

      Dim command As OdbcCommand = connection.CreateCommand()
      Command.CommandText = "{ call MyProc(?,?,?) }"

      Dim param As New OdbcParameter()
      param.DbType = DbType.Int32
      param.Value = 1
      command.Parameters.Add(param)

      param = New OdbcParameter()
      param.DbType = DbType.Decimal
      param.Value = 1
      command.Parameters.Add(param)

      param = New OdbcParameter()
      param.DbType = DbType.Decimal
      param.Value = 1
      command.Parameters.Add(param)

      command.ExecuteNonQuery()

    End Sub