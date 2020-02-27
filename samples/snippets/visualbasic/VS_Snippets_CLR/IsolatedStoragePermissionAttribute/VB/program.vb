'Types:System.Security.Permissions.IsolatedStorageContainment (enum) 
'Types:System.Security.Permissions.IsolatedStoragePermissionAttribute 
'Types:System.Security.Permissions.SecurityAction 
'<snippet1>
Option Strict On
Imports System.Security.Permissions
Imports System.IO.IsolatedStorage
Imports System.IO


' Notify the CLR to only grant IsolatedStorageFilePermission to called methods. 
' This restricts the called methods to working only with storage files that are isolated 
' by user and assembly.
<IsolatedStorageFilePermission(SecurityAction.PermitOnly, UsageAllowed:=IsolatedStorageContainment.AssemblyIsolationByUser)> _
Public NotInheritable Class App

    Shared Sub Main()
        WriteIsolatedStorage()
    End Sub
    Shared Sub WriteIsolatedStorage()
        ' Attempt to create a storage file that is isolated by user and assembly.
        ' IsolatedStorageFilePermission granted to the attribute at the top of this file 
        ' allows CLR to load this assembly and execution of this statement.
        Dim s As New IsolatedStorageFileStream("AssemblyData", FileMode.Create, IsolatedStorageFile.GetUserStoreForAssembly())
        Try

            ' Write some data out to the isolated file.
            Dim sw As New StreamWriter(s)
            Try
                sw.Write("This is some test data.")
            Finally
                sw.Dispose()
            End Try
        Finally
            s.Dispose()
        End Try

        ' Attempt to open the file that was previously created.
        Dim t As New IsolatedStorageFileStream("AssemblyData", FileMode.Open, IsolatedStorageFile.GetUserStoreForAssembly())
        Try
            ' Read the data from the file and display it.
            Dim sr As New StreamReader(t)
            Try
                Console.WriteLine(sr.ReadLine())
            Finally
                sr.Dispose()
            End Try
        Finally
            t.Dispose()
        End Try

    End Sub
End Class

' This code produces the following output.
'
'  Some test data.
'</snippet1>