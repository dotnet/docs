Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.Common
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    
    
    
    ' <Snippet1>
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
    ' </Snippet1>
End Class
