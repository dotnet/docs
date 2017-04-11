'------------------------------------------------------------------------------
'<Snippet1>
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports Microsoft.SqlServer.Server

Partial Public Class StoredProcedures

    <SqlProcedure()>
    Public Shared Sub InsertCurrency(
        ByVal currencyCode As SqlString, ByVal name As SqlString)

        Using conn As New SqlConnection("context connection=true")

            Dim InsertCurrencyCommand As New SqlCommand()
            Dim currencyCodeParam As New SqlParameter("@CurrencyCode", SqlDbType.NVarChar)
            Dim nameParam As New SqlParameter("@Name", SqlDbType.NVarChar)

            currencyCodeParam.Value = currencyCode
            nameParam.Value = name


            InsertCurrencyCommand.Parameters.Add(currencyCodeParam)
            InsertCurrencyCommand.Parameters.Add(nameParam)

            InsertCurrencyCommand.CommandText =
                "INSERT Sales.Currency (CurrencyCode, Name, ModifiedDate)" &
                " VALUES(@CurrencyCode, @Name, GetDate())"

            InsertCurrencyCommand.Connection = conn

            conn.Open()
            InsertCurrencyCommand.ExecuteNonQuery()
            conn.Close()
        End Using
    End Sub
End Class
'</Snippet1>


'------------------------------------------------------------------------------
'<Snippet7>
Partial Public Class StoredProcedures

    <SqlProcedure(Name:="sp_sqlName")>
    Public Shared Sub SampleProcedure(ByVal s As SqlString)
        '...
    End Sub
End Class
'</Snippet7>
