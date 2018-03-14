'<SNIPPET1>
Imports System
Imports System.IO
Imports System.Security.AccessControl



Module FileExample

    Sub Main()
        Try
            Dim FileName As String = "c:\test.xml"

            Console.WriteLine("Adding access control entry for " & FileName)

            ' Add the access control entry to the file.
            ' Before compiling this snippet, change MyDomain to your 
            ' domain name and MyAccessAccount to the name 
            ' you use to access your domain.
            AddFileSecurity(FileName, "MyDomain\\MyAccessAccount", FileSystemRights.ReadData, AccessControlType.Allow)

            Console.WriteLine("Removing access control entry from " & FileName)

            ' Remove the access control entry from the file.
            ' Before compiling this snippet, change MyDomain to your 
            ' domain name and MyAccessAccount to the name 
            ' you use to access your domain.
            RemoveFileSecurity(FileName, "MyDomain\\MyAccessAccount", FileSystemRights.ReadData, AccessControlType.Allow)

            Console.WriteLine("Done.")
        Catch e As Exception
            Console.WriteLine(e)
        End Try

    End Sub


    ' Adds an ACL entry on the specified file for the specified account.
    Sub AddFileSecurity(ByVal FileName As String, ByVal Account As String, ByVal Rights As FileSystemRights, ByVal ControlType As AccessControlType)
        ' Create a new FileInfo object.
        Dim fInfo As New FileInfo(FileName)

        ' Get a FileSecurity object that represents the 
        ' current security settings.
        Dim fSecurity As FileSecurity = fInfo.GetAccessControl()

        ' Add the FileSystemAccessRule to the security settings. 
        fSecurity.AddAccessRule(New FileSystemAccessRule(Account, Rights, ControlType))

        ' Set the new access settings.
        fInfo.SetAccessControl(fSecurity)

    End Sub


    ' Removes an ACL entry on the specified file for the specified account.
    Sub RemoveFileSecurity(ByVal FileName As String, ByVal Account As String, ByVal Rights As FileSystemRights, ByVal ControlType As AccessControlType)
        ' Create a new FileInfo object.
        Dim fInfo As New FileInfo(FileName)

        ' Get a FileSecurity object that represents the 
        ' current security settings.
        Dim fSecurity As FileSecurity = fInfo.GetAccessControl()

        ' Add the FileSystemAccessRule to the security settings. 
        fSecurity.RemoveAccessRule(New FileSystemAccessRule(Account, Rights, ControlType))

        ' Set the new access settings.
        fInfo.SetAccessControl(fSecurity)

    End Sub
End Module
'This code produces output similar to the following; 
'results may vary based on the computer/file structure/etc.:
'
'Adding access control entry for c:\test.xml
'Removing access control entry from c:\test.xml
'Done.
'
'</SNIPPET1>