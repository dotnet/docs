
Imports System
Imports System.Security
Imports System.Security.Permissions



Class Program

    Shared Sub Main(ByVal args() As String)
        ' <Snippet1>
        Dim f As New FileIOPermission(PermissionState.None)
        f.AllLocalFiles = FileIOPermissionAccess.Read
        Try
            f.Demand()
        Catch s As SecurityException
            Console.WriteLine(s.Message)
        End Try

        ' </Snippet1>
        ' <Snippet2>
        Dim f2 As New FileIOPermission(FileIOPermissionAccess.Read, "C:\test_r")
        f2.AddPathList(FileIOPermissionAccess.Write Or FileIOPermissionAccess.Read, "C:\example\out.txt")
        Try
            f2.Demand()
        Catch s As SecurityException
            Console.WriteLine(s.Message)
        End Try
        ' </Snippet2>
        Console.Read()

        ' <Snippet3>
        Dim f3 As New FileIOPermission(PermissionState.None)
        f3.AllFiles = FileIOPermissionAccess.Read
        Try
            f3.Demand()
        Catch s As SecurityException
            Console.WriteLine(s.Message)
        End Try
        ' </Snippet3>

    End Sub 'Main 
End Class 'Program 