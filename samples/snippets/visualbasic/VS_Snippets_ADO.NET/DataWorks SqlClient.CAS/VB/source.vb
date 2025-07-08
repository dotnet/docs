' <Snippet1>
Imports System.Data.SqlClient
Imports System.Security
Imports System.Security.Permissions

Namespace PartialTrustTopic
    Public Class PartialTrustHelper
        Inherits MarshalByRefObject
        Public Sub TestConnectionOpen(ByVal connectionString As String)
            ' Try to open a connection.
            Using connection As New SqlConnection(connectionString)
                connection.Open()
            End Using
        End Sub
    End Class

    Class Program
        Public Shared Sub Main(ByVal args As String())
            TestCAS("Data Source=(local);Integrated Security=true", "Data Source=(local);Integrated Security=true;Initial Catalog=Test")
        End Sub

        Public Shared Sub TestCAS(ByVal connectString1 As String, ByVal connectString2 As String)
            ' Create permission set for sandbox AppDomain.
            ' This example only allows execution.
            Dim permissions As New PermissionSet(PermissionState.None)
            permissions.AddPermission(New SecurityPermission(SecurityPermissionFlag.Execution))

            ' Create sandbox AppDomain with permission set that only allows execution,
            ' and has no SqlClientPermissions.
            Dim appDomainSetup As New AppDomainSetup()
            appDomainSetup.ApplicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase
            Dim firstDomain As AppDomain = AppDomain.CreateDomain("NoSqlPermissions", Nothing, appDomainSetup, permissions)

            ' Create helper object in sandbox AppDomain so that code can be executed in that AppDomain.
            Dim helperType As Type = GetType(PartialTrustHelper)
            Dim firstHelper As PartialTrustHelper = DirectCast(firstDomain.CreateInstanceAndUnwrap(helperType.Assembly.FullName, helperType.FullName), PartialTrustHelper)

            Try
                ' Attempt to open a connection in the sandbox AppDomain.
                ' This is expected to fail.
                firstHelper.TestConnectionOpen(connectString1)
                Console.WriteLine("Connection opened, unexpected.")
            Catch ex As System.Security.SecurityException

                ' Uncomment the following line to see Exception details.
                ' Console.WriteLine("BaseException: " + ex.GetBaseException());
                Console.WriteLine("Failed, as expected: {0}", ex.FirstPermissionThatFailed)
            End Try

            ' Add permission for a specific connection string.
            Dim sqlPermission As New SqlClientPermission(PermissionState.None)
            sqlPermission.Add(connectString1, "", KeyRestrictionBehavior.AllowOnly)

            permissions.AddPermission(sqlPermission)

            Dim secondDomain As AppDomain = AppDomain.CreateDomain("OneSqlPermission", Nothing, appDomainSetup, permissions)
            Dim secondHelper As PartialTrustHelper = DirectCast(secondDomain.CreateInstanceAndUnwrap(helperType.Assembly.FullName, helperType.FullName), PartialTrustHelper)

            ' Try connection open again, it should succeed now.
            Try
                secondHelper.TestConnectionOpen(connectString1)
                Console.WriteLine("Connection opened, as expected.")
            Catch ex As System.Security.SecurityException
                Console.WriteLine("Unexpected failure: {0}", ex.Message)
            End Try

            ' Try a different connection string. This should fail.
            Try
                secondHelper.TestConnectionOpen(connectString2)
                Console.WriteLine("Connection opened, unexpected.")
            Catch ex As System.Security.SecurityException
                Console.WriteLine("Failed, as expected: {0}", ex.Message)
            End Try
        End Sub
    End Class
End Namespace
' </Snippet1>
