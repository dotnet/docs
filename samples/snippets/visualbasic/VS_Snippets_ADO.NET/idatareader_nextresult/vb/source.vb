' <Snippet1>
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc

Module Module1
   Dim connectionTypeName As String = "SqlClient"
   Dim connectionString As String = "Data Source=(local);Initial Catalog=AdventureWorks2012;Integrated Security=SSPI"

   ' Dim connectionTypeName As String = "Odbc"
   ' Dim connectionString As String = "Driver={SQL Server Native Client 11.0};Server=(local);Database=AdventureWorks2012;Trusted_Connection=Yes"

   ' Dim connectionTypeName As String = "OleDb"
   ' Dim connectionString As String = "Provider=SQLNCLI11;Data Source=(local);Initial Catalog=AdventureWorks2012;Integrated Security=SSPI"

   Sub Main()
      Using connection As IDbConnection = DatabaseConnectionFactory.GetConnection(connectionTypeName, connectionString)
         Dim command As IDbCommand = connection.CreateCommand()
         command.Connection = connection

         'these 2 queries are executed as a single batch and return 2 separate results
         command.CommandText =
             "SELECT CountryRegionCode, Name FROM Person.CountryRegion;" +
             "SELECT CountryRegionCode, StateProvinceCode, Name, StateProvinceID FROM Person.StateProvince;"

         connection.Open()

         Using reader As IDataReader = command.ExecuteReader()
            'process the first result
            displayCountryRegions(reader)

            'use NextResult to move to the second result and verify it is returned
            If Not reader.NextResult() Then
               Throw New InvalidOperationException("Expected second result (StateProvinces) but only one was returned")
            End If

            'process the second result
            displayStateProvinces(reader)

            reader.Close()
         End Using

         connection.Close()
      End Using
   End Sub

   Sub displayCountryRegions(reader As IDataReader)
      If Not reader.FieldCount = 2 Then
         Throw New InvalidOperationException("First resultset (CountryRegions) must contain exactly 2 columns")
      End If

      While reader.Read()
         Console.WriteLine("CountryRegionCode={0}, Name={1}" _
             , reader.GetString(reader.GetOrdinal("CountryRegionCode")) _
             , reader.GetString(reader.GetOrdinal("Name")))
      End While
   End Sub

   Sub displayStateProvinces(reader As IDataReader)

      If Not reader.FieldCount = 4 Then
         Throw New InvalidOperationException("Second resultset (StateProvinces) must contain exactly 4 columns")
      End If

      While reader.Read()
         Console.WriteLine("CountryRegionCode={0}, StateProvinceCode={1}, Name={2}, StateProvinceID={3}" _
             , reader.GetString(reader.GetOrdinal("CountryRegionCode")) _
             , reader.GetString(reader.GetOrdinal("StateProvinceCode")) _
             , reader.GetString(reader.GetOrdinal("Name")) _
             , reader.GetInt32(reader.GetOrdinal("StateProvinceID")))
      End While
   End Sub

   Class DatabaseConnectionFactory
      Shared Function GetSqlConnection(connectionString As String) As SqlConnection
         Return New SqlConnection(connectionString)
      End Function

      Shared Function GetOdbcConnection(connectionString As String) As OdbcConnection
         Return New OdbcConnection(connectionString)
      End Function

      Shared Function GetOleDbConnection(connectionString As String) As OleDbConnection
         Return New OleDbConnection(connectionString)
      End Function

      Public Shared Function GetConnection(connectionTypeName As String, connectionString As String) As IDbConnection

         Select Case connectionTypeName
            Case "SqlClient"
               Return GetSqlConnection(connectionString)
            Case "Odbc"
               Return GetOdbcConnection(connectionString)
            Case "OleDb"
               Return GetOleDbConnection(connectionString)
            Case Else
               Throw New ArgumentException("Value must be SqlClient, Odbc or OleDb", "connectionTypeName")
         End Select

      End Function
   End Class
End Module
' </Snippet1>