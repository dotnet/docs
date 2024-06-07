'<Snippet1>
Imports System.IO
Imports System.Security.AccessControl

Module FileExample

    Sub Main()
        Try
            Dim fileName As String = "test.xml"

            Console.WriteLine("Adding access control entry for " & fileName)

            ' Add the access control entry to the file.
            AddFileSecurity(fileName, "DomainName\AccountName",
                FileSystemRights.ReadData, AccessControlType.Allow)

            Console.WriteLine("Removing access control entry from " & fileName)

            ' Remove the access control entry from the file.
            RemoveFileSecurity(fileName, "DomainName\AccountName",
                FileSystemRights.ReadData, AccessControlType.Allow)

            Console.WriteLine("Done.")
        Catch e As Exception
            Console.WriteLine(e)
        End Try

    End Sub

    ' Adds an ACL entry on the specified file for the specified account.
    Sub AddFileSecurity(ByVal fileName As String, ByVal account As String,
        ByVal rights As FileSystemRights, ByVal controlType As AccessControlType)

        Dim fileInfo As New FileInfo(fileName)
        Dim fSecurity As FileSecurity = fileInfo.GetAccessControl()

        ' Add the FileSystemAccessRule to the security settings. 
        Dim accessRule As New FileSystemAccessRule(account, rights, controlType)

        fSecurity.AddAccessRule(accessRule)

        ' Set the new access settings.
        fileInfo.SetAccessControl(fSecurity)

    End Sub

    ' Removes an ACL entry on the specified file for the specified account.
    Sub RemoveFileSecurity(ByVal fileName As String, ByVal account As String,
        ByVal rights As FileSystemRights, ByVal controlType As AccessControlType)

        Dim fileInfo As New FileInfo(fileName)
        Dim fSecurity As FileSecurity = fileInfo.GetAccessControl()

        ' Remove the FileSystemAccessRule from the security settings. 
        fSecurity.RemoveAccessRule(New FileSystemAccessRule(account,
            rights, controlType))

        ' Set the new access settings.
        fileInfo.SetAccessControl(fSecurity)

    End Sub
End Module
'</Snippet1>
