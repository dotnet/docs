' <Snippet1>
Option Explicit
Option Strict

Imports Microsoft.VisualBasic
Imports System
Imports System.Security
Imports System.Security.Permissions
Imports System.Security.Principal
Imports System.Threading

Public Class Principal

    <MTAThread> _
    Shared Sub Main()
    
        Dim rolesArray As String() = {"managers", "executives"}
        Try
            ' Set the principal to a new generic principal.
            Thread.CurrentPrincipal = _
                New GenericPrincipal(New GenericIdentity( _
                "Bob", "Passport"), rolesArray)

        Catch secureException As SecurityException
            Console.WriteLine("{0}: Permission to set Principal " & _
                "is denied.", secureException.GetType().Name)
        End Try

        Dim threadPrincipal As IPrincipal = Thread.CurrentPrincipal
        Console.WriteLine( _
            "Name: {0}" & vbCrLf & "IsAuthenticated:" & _
            " {1}" & vbCrLf & "AuthenticationType: {2}", _
            threadPrincipal.Identity.Name, _
            threadPrincipal.Identity.IsAuthenticated, _
            threadPrincipal.Identity.AuthenticationType)
    
    End Sub
End Class
' </Snippet1>