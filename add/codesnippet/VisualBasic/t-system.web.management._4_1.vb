Imports System
Imports System.Web.Management

Module UsingSqlServices
    Sub Main()
        Try
' Values to use.
Dim server As String = "ASPFeatureServer"
Dim database As String = "ASPFeatureDB"
Dim connectionString As String = _
    "server=ASPFeatureServer, pooling=False, user=<user name>, password=<secure password>"
Dim user As String = "AspAdmin"
Dim password As String = "Secure Password"

' Install membership and personalization.
SqlServices.Install(database, _
    SqlFeatures.Membership And _
    SqlFeatures.Personalization, _
    connectionString)

' Remove membership and personalization.
SqlServices.Uninstall(database, _
    SqlFeatures.Membership And _
    SqlFeatures.Personalization, _
    connectionString)

' Install all features.
SqlServices.Install(server, database, _
    SqlFeatures.All)

' Remove all features.
SqlServices.Uninstall(server, database, _
    SqlFeatures.All)

' Install a custom session state database.
SqlServices.InstallSessionState(database, _
    SessionStateType.Custom, _
    connectionString)

' Remove a custom session state database.
SqlServices.UninstallSessionState(database, _
    SessionStateType.Custom, _
    connectionString)

' Install temporary session state.
SqlServices.InstallSessionState(server, Nothing, _
    SessionStateType.Temporary)

' Remove temporary session state.
SqlServices.UninstallSessionState(server, Nothing, _
    SessionStateType.Temporary)

' Install persisted session state.
SqlServices.InstallSessionState(server, user, password, _
    Nothing, SessionStateType.Persisted)

' Remove persisted session state.
SqlServices.UninstallSessionState(server, user, password, _
    Nothing, SessionStateType.Persisted)
        Catch sqlExecutionException As SqlExecutionException
Console.WriteLine( _
    "An SQL execution exception occurred.")
Console.WriteLine()
Console.WriteLine("  Message: {0}", _
    sqlExecutionException.Message)
Console.WriteLine("  Server: {0}", _
    sqlExecutionException.Server)
Console.WriteLine("  Database: {0}", _
    sqlExecutionException.Database)
Console.WriteLine("  Commands: {0}", _
    sqlExecutionException.Commands)
Console.WriteLine("  SqlFile: {0}", _
    sqlExecutionException.SqlFile)
Console.WriteLine("  Inner Exception: {0}", _
    sqlExecutionException.Exception)
        Catch ex As Exception
Console.WriteLine("An unknown exception occurred.")
Console.WriteLine()
Console.WriteLine("  Message: {0}", ex.Message)
        End Try
    End Sub
End Module