
Imports System
Imports System.Security
Imports System.Security.Permissions

Public Class FileIOPermissionDemo
    Public Shared Sub Main()
        Try
            Dim fileIOPerm1 as New FileIOPermission(PermissionState.Unrestricted)

            ' Tests for: SetPathList(FileIOPermissionAccess,String)

            ' Test the Read list
            fileIOPerm1.SetPathList(FileIOPermissionAccess.Read, "C:\\documents")

            Console.WriteLine("Read access before SetPathList = ")
            For Each path In fileIOPerm1.GetPathList(FileIOPermissionAccess.Read)
                Console.WriteLine("    " + path)
            Next path

            '<Snippet12>
            fileIOPerm1.SetPathList(FileIOPermissionAccess.Read, "C:\\temp")
            '</Snippet12>

            Console.WriteLine("Read access after SetPathList = ")
            For Each path In fileIOPerm1.GetPathList(FileIOPermissionAccess.Read)
                Console.WriteLine("    " + path)
            Next path


            ' Test the Write list
            fileIOPerm1.SetPathList(FileIOPermissionAccess.Write, "C:\\temp")

            Console.WriteLine("Write access before SetPathList = ")
            For Each path In fileIOPerm1.GetPathList(FileIOPermissionAccess.Write)
                Console.WriteLine("    " + path)
            Next path

            '<Snippet13>
            fileIOPerm1.SetPathList(FileIOPermissionAccess.Write, "C:\\documents")
            '</Snippet13>

            Console.WriteLine("Write access after SetPathList = ")
            For Each path In fileIOPerm1.GetPathList(FileIOPermissionAccess.Write)
                Console.WriteLine("    " + path)
            Next path

            ' Tests for: SetPathList(FileIOPermissionAccess,String[])

            ' Test the Read list
            fileIOPerm1.SetPathList(FileIOPermissionAccess.Read, New String() {"C:\\pictures", "C:\\music"})

            Console.WriteLine("Read access before SetPathList = ")
            For Each path In fileIOPerm1.GetPathList(FileIOPermissionAccess.Read)
                Console.WriteLine("    " + path)
            Next path

            '<Snippet14>
            fileIOPerm1.SetPathList(FileIOPermissionAccess.Read, New String() {"C:\\temp", "C:\\Documents"})
            '</Snippet14>

            Console.WriteLine("Read access after SetPathList = ")
            For Each path In fileIOPerm1.GetPathList(FileIOPermissionAccess.Read)
                Console.WriteLine("    " + path)
            Next path


            ' Test the Write list
            fileIOPerm1.SetPathList(FileIOPermissionAccess.Write, New String() {"C:\\temp", "C:\\Documents"})

            Console.WriteLine("Write access before SetPathList = ")
            For Each path In fileIOPerm1.GetPathList(FileIOPermissionAccess.Write)
                Console.WriteLine("    " + path)
            Next path
            '<Snippet15>
            fileIOPerm1.SetPathList(FileIOPermissionAccess.Write, New String() {"C:\\pictures", "C:\\music"})
            '</Snippet15>

            Console.WriteLine("Write access after SetPathList = ")
            For Each path In fileIOPerm1.GetPathList(FileIOPermissionAccess.Write)
                Console.WriteLine("    " + path)
            Next path

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub
End Class
