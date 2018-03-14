'<snippet1>
Imports System
Imports System.IO
Imports System.Security.AccessControl



Module FileExample

    Sub Main()
        Try
            Dim FileName As String = "test.xml"

            Console.WriteLine("Adding access control entry for " + FileName)

            ' Add the access control entry to the file.
            AddFileAuditRule(FileName, "MYDOMAIN\MyAccount", FileSystemRights.ReadData, AuditFlags.Failure)

            Console.WriteLine("Removing access control entry from " + FileName)

            ' Remove the access control entry from the file.
            RemoveFileAuditRule(FileName, "MYDOMAIN\MyAccount", FileSystemRights.ReadData, AuditFlags.Failure)

            Console.WriteLine("Done.")
        Catch e As Exception
            Console.WriteLine(e)
        End Try

        Console.ReadLine()

    End Sub


    ' Adds an ACL entry on the specified file for the specified account.
    Sub AddFileAuditRule(ByVal FileName As String, ByVal Account As String, ByVal Rights As FileSystemRights, ByVal AuditRule As AuditFlags)


        ' Get a FileSecurity object that represents the 
        ' current security settings.
        Dim fSecurity As FileSecurity = File.GetAccessControl(FileName)

        ' Add the FileSystemAuditRule to the security settings. 
        fSecurity.AddAuditRule(New FileSystemAuditRule(Account, Rights, AuditRule))

        ' Set the new access settings.
        File.SetAccessControl(FileName, fSecurity)

    End Sub


    ' Removes an ACL entry on the specified file for the specified account.
    Sub RemoveFileAuditRule(ByVal FileName As String, ByVal Account As String, ByVal Rights As FileSystemRights, ByVal AuditRule As AuditFlags)

        ' Get a FileSecurity object that represents the 
        ' current security settings.
        Dim fSecurity As FileSecurity = File.GetAccessControl(FileName)

        ' Add the FileSystemAuditRule to the security settings. 
        fSecurity.RemoveAuditRule(New FileSystemAuditRule(Account, Rights, AuditRule))

        ' Set the new access settings.
        File.SetAccessControl(FileName, fSecurity)

    End Sub
End Module
'</snippet1>