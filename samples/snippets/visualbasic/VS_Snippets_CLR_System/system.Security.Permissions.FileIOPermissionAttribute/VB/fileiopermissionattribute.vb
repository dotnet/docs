'<Snippet1>
' This sample demonstrates the use of the FileIOPermissionAttribute class.
' The sample follows the recommended procedure of first granting PermitOnly permissions, 
' then using a Deny on that set of granted permissions.  
Imports System
Imports System.Reflection
Imports System.Security.Permissions
Imports System.Security
Imports System.IO
Imports Microsoft.VisualBasic



Class [MyClass]


    ' This method demonstrates the use of the FileIOPermissionAttribute to create a PermitOnly permission.
    '<Snippet2>
    '<Snippet3>
    '<Snippet4>
    '<Snippet5>
    '<Snippet6>
    '<Snippet7>
    ' Set the Read, PathDiscovery, Append, Write, and All properties.
    <FileIOPermissionAttribute(SecurityAction.PermitOnly, Read:="C:\"), _
    FileIOPermissionAttribute(SecurityAction.PermitOnly, _
    PathDiscovery:="C:\Documents and Settings\All Users"), _
    FileIOPermissionAttribute(SecurityAction.PermitOnly, _
    Append:="C:\Documents and Settings\All Users\Application Data"), _
    FileIOPermissionAttribute(SecurityAction.PermitOnly, _
        Write:="C:\Documents and Settings\All Users\Application Data\Microsoft"), _
    FileIOPermissionAttribute(SecurityAction.PermitOnly, _
        All:="C:\Documents and Settings\All Users\Application Data\Microsoft\Network")> _
    Public Shared Sub PermitOnlyMethod()
        '</Snippet2>
        '</Snippet3>
        '</Snippet4>
        '</Snippet5>
        '</Snippet6>
        Console.WriteLine("Executing PermitOnlyMethod.")
        Console.WriteLine("PermitOnly the Read permission for drive C.")
        Console.WriteLine("PermitOnly the PathDiscovery permission for " & ControlChars.Lf & ControlChars.Tab & "C:\Documents and Settings\All Users.")
        Console.WriteLine("PermitOnly the Append permission for " & ControlChars.Lf & ControlChars.Tab & "C:\Documents and Settings\All Users\Application Data.")
        Console.WriteLine("PermitOnly the Write permission for  " & ControlChars.Lf & ControlChars.Tab & "C:\Documents and Settings\All Users\Application Data\Microsoft.")
        Console.WriteLine("PermitOnly the All permission for " & ControlChars.Lf & ControlChars.Tab & "C:\Documents and Settings\All Users\Application Data\Microsoft\Network.")

        PermitOnlyTestMethod()
    End Sub 'PermitOnlyMethod
    '</Snippet7>


    Public Shared Sub PermitOnlyTestMethod()
        Console.WriteLine("Executing PermitOnlyTestMethod.")
        Try
            Dim ps As New PermissionSet(PermissionState.None)
            ps.AddPermission(New FileIOPermission(FileIOPermissionAccess.Write, "C:\Documents and Settings\All Users\Application Data\Microsoft\Network\SomeFile"))
            Console.WriteLine(("Demanding permission to write " & "'C:\Documents and Settings\All Users\Application Data\Microsoft\Network\SomeFile'"))
            ps.Demand()
            Console.WriteLine("Demand succeeded.")
            ps.AddPermission(New FileIOPermission(FileIOPermissionAccess.Write, "C:\"))
            Console.WriteLine("Demanding permission to write to drive C.")

            ' This demand should cause an exception.
            ps.Demand()
            ' The TestFailed method is called if an exception is not thrown.
            TestFailed()
        Catch e As Exception
            Console.WriteLine(("An exception was thrown because of a write demand: " & e.Message))
        End Try
    End Sub 'PermitOnlyTestMethod


    Public Shared Sub TestFailed()
        Console.WriteLine("Executing TestFailed.")
        Console.WriteLine("Throwing an exception.")
        Throw New Exception()
    End Sub 'TestFailed

    Overloads Shared Sub Main(ByVal args() As String)
        Try
            PermitOnlyMethod()
        Catch e As Exception
            Console.WriteLine(e.Message.ToString())
        End Try
    End Sub 'Main
End Class '[MyClass] 

'</Snippet1>