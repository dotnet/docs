' <Snippet1>
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

' <Snippet2>
' Install membership and personalization.
SqlServices.Install(database, _
    SqlFeatures.Membership And _
    SqlFeatures.Personalization, _
    connectionString)
' </Snippet2>

' <Snippet3>
' Remove membership and personalization.
SqlServices.Uninstall(database, _
    SqlFeatures.Membership And _
    SqlFeatures.Personalization, _
    connectionString)
' </Snippet3>

' <Snippet4>
' Install all features.
SqlServices.Install(server, database, _
    SqlFeatures.All)
' </Snippet4>

' <Snippet5>
' Remove all features.
SqlServices.Uninstall(server, database, _
    SqlFeatures.All)
' </Snippet5>

' <Snippet8>
' Install a custom session state database.
SqlServices.InstallSessionState(database, _
    SessionStateType.Custom, _
    connectionString)
' </Snippet8>

' <Snippet9>
' Remove a custom session state database.
SqlServices.UninstallSessionState(database, _
    SessionStateType.Custom, _
    connectionString)
' </Snippet9>

' <Snippet10>
' Install temporary session state.
SqlServices.InstallSessionState(server, Nothing, _
    SessionStateType.Temporary)
' </Snippet10>

' <Snippet11>
' Remove temporary session state.
SqlServices.UninstallSessionState(server, Nothing, _
    SessionStateType.Temporary)
' </Snippet11>

' <Snippet12>
' Install persisted session state.
SqlServices.InstallSessionState(server, user, password, _
    Nothing, SessionStateType.Persisted)
' </Snippet12>

' <Snippet13>
' Remove persisted session state.
SqlServices.UninstallSessionState(server, user, password, _
    Nothing, SessionStateType.Persisted)
' </Snippet13>
        Catch sqlExecutionException As SqlExecutionException
' <Snippet14>
Console.WriteLine( _
    "An SQL execution exception occurred.")
Console.WriteLine()
' <Snippet15>
Console.WriteLine("  Message: {0}", _
    sqlExecutionException.Message)
' </Snippet15>
' <Snippet16>
Console.WriteLine("  Server: {0}", _
    sqlExecutionException.Server)
' </Snippet16>
' <Snippet17>
Console.WriteLine("  Database: {0}", _
    sqlExecutionException.Database)
' </Snippet17>
' <Snippet18>
Console.WriteLine("  Commands: {0}", _
    sqlExecutionException.Commands)
' </Snippet18>
' <Snippet19>
Console.WriteLine("  SqlFile: {0}", _
    sqlExecutionException.SqlFile)
' </Snippet19>
' <Snippet20>
Console.WriteLine("  Inner Exception: {0}", _
    sqlExecutionException.Exception)
' </Snippet20>
' </Snippet14>
        Catch ex As Exception
Console.WriteLine("An unknown exception occurred.")
Console.WriteLine()
Console.WriteLine("  Message: {0}", ex.Message)
        End Try
    End Sub
End Module
' </Snippet1>
