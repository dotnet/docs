Option Explicit On
Option Strict On
' <Snippet1>
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient

Module Module1
    Sub Main()
        ' List all SQL Server instances:
        ListServers(SqlClientFactory.Instance)

        Console.WriteLine()
        Console.WriteLine("Press any key to continue.")
        Console.ReadKey()
    End Sub

    Private Sub ListServers(ByVal factory As DbProviderFactory)
        ' This procedure is provider-agnostic, and can list
        ' instances of any provider's servers. Of course, 
        ' not all providers can create a data source enumerator,
        ' so it's best to check the CanCreateDataSourceEnumerator property
        ' before attempting to list the data sources.
        If factory.CanCreateDataSourceEnumerator Then
            Dim instance As DbDataSourceEnumerator = _
             factory.CreateDataSourceEnumerator
            Dim table As System.Data.DataTable = instance.GetDataSources()

            Dim row As DataRow
            For Each row In table.Rows
                Console.WriteLine("{0}\{1}", _
                 row("ServerName"), row("InstanceName"))
            Next
        End If
    End Sub
End Module
' </Snippet1>

