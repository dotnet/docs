Option Explicit On
Option Strict On
Imports System.Data
Imports System.Security.Permissions
Imports System.Data.SqlClient

Class Program
    Shared Sub Main()
    End Sub

    ' <Snippet1>
    ' Code requires directives to
    ' System.Security.Permissions and
    ' System.Data.SqlClient

    Private Function CanRequestNotifications() As Boolean

        Dim permission As New SqlClientPermission( _
          PermissionState.Unrestricted)

        Try
            permission.Demand()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    ' </Snippet1>

End Class
