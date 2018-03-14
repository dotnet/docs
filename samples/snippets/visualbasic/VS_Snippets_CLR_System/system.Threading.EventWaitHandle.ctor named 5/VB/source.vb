'<Snippet1>
Imports System
Imports System.Threading
Imports System.Security.AccessControl

Friend Class Example

    <MTAThread> _
    Friend Shared Sub Main()
        '<Snippet2>
        Const ewhName As String = "EventWaitHandleExample5"

        Dim ewh As EventWaitHandle = Nothing
        Dim doesNotExist as Boolean = False
        Dim unauthorized As Boolean = False

        ' The value of this variable is set by the event
        ' constructor. It is True if the named system event was
        ' created, and False if the named event already existed.
        '
        Dim wasCreated As Boolean

        ' Attempt to open the named event.
        Try
            ' Open the event with (EventWaitHandleRights.Synchronize
            ' Or EventWaitHandleRights.Modify), to wait on and 
            ' signal the named event.
            '
            ewh = EventWaitHandle.OpenExisting(ewhName)
        Catch ex As WaitHandleCannotBeOpenedException
            Console.WriteLine("Named event does not exist.")
            doesNotExist = True
        Catch ex As UnauthorizedAccessException
            Console.WriteLine("Unauthorized access: {0}", ex.Message)
            unauthorized = True
        End Try
        '</Snippet2>

        ' There are three cases: (1) The event does not exist.
        ' (2) The event exists, but the current user doesn't 
        ' have access. (3) The event exists and the user has
        ' access.
        '
        If doesNotExist Then
            '<Snippet4>
            ' The event does not exist, so create it.

            ' Create an access control list (ACL) that denies the
            ' current user the right to wait on or signal the 
            ' event, but allows the right to read and change
            ' security information for the event.
            '
            Dim user As String = Environment.UserDomainName _ 
                & "\" & Environment.UserName
            Dim ewhSec As New EventWaitHandleSecurity()

            Dim rule As New EventWaitHandleAccessRule(user, _
                EventWaitHandleRights.Synchronize Or _
                EventWaitHandleRights.Modify, _
                AccessControlType.Deny)
            ewhSec.AddAccessRule(rule)

            rule = New EventWaitHandleAccessRule(user, _
                EventWaitHandleRights.ReadPermissions Or _
                EventWaitHandleRights.ChangePermissions, _
                AccessControlType.Allow)
            ewhSec.AddAccessRule(rule)

            ' Create an EventWaitHandle object that represents
            ' the system event named by the constant 'ewhName', 
            ' initially signaled, with automatic reset, and with
            ' the specified security access. The Boolean value that 
            ' indicates creation of the underlying system object
            ' is placed in wasCreated.
            '
            ewh = New EventWaitHandle(True, _
                EventResetMode.AutoReset, ewhName, _
                wasCreated, ewhSec)

            ' If the named system event was created, it can be
            ' used by the current instance of this program, even 
            ' though the current user is denied access. The current
            ' program owns the event. Otherwise, exit the program.
            ' 
            If wasCreated Then
                Console.WriteLine("Created the named event.")
            Else
                Console.WriteLine("Unable to create the event.")
                Return
            End If
            '</Snippet4>

        ElseIf unauthorized Then

            '<Snippet3>
            ' Open the event to read and change the access control
            ' security. The access control security defined above
            ' allows the current user to do this.
            '
            Try
                ewh = EventWaitHandle.OpenExisting(ewhName, _
                    EventWaitHandleRights.ReadPermissions Or _
                    EventWaitHandleRights.ChangePermissions)

                ' Get the current ACL. This requires 
                ' EventWaitHandleRights.ReadPermissions.
                Dim ewhSec As EventWaitHandleSecurity = _
                    ewh.GetAccessControl()
                
                Dim user As String = Environment.UserDomainName _ 
                    & "\" & Environment.UserName

                ' First, the rule that denied the current user 
                ' the right to enter and release the event must
                ' be removed.
                Dim rule As New EventWaitHandleAccessRule(user, _
                    EventWaitHandleRights.Synchronize Or _
                    EventWaitHandleRights.Modify, _
                    AccessControlType.Deny)
                ewhSec.RemoveAccessRule(rule)

                ' Now grant the user the correct rights.
                ' 
                rule = New EventWaitHandleAccessRule(user, _
                    EventWaitHandleRights.Synchronize Or _
                    EventWaitHandleRights.Modify, _
                    AccessControlType.Allow)
                ewhSec.AddAccessRule(rule)

                ' Update the ACL. This requires
                ' EventWaitHandleRights.ChangePermissions.
                ewh.SetAccessControl(ewhSec)

                Console.WriteLine("Updated event security.")

                ' Open the event with (EventWaitHandleRights.Synchronize 
                ' Or EventWaitHandleRights.Modify), the rights required
                ' to wait on and signal the event.
                '
                ewh = EventWaitHandle.OpenExisting(ewhName)
                '</Snippet3>

            Catch ex As UnauthorizedAccessException
                Console.WriteLine("Unable to change permissions: {0}", _
                    ex.Message)
                Return
            End Try

        End If

        ' Wait on the event, and hold it until the program
        ' exits.
        '
        Try
            Console.WriteLine("Wait on the event.")
            ewh.WaitOne()
            Console.WriteLine("Event was signaled.")
            Console.WriteLine("Press the Enter key to signal the event and exit.")
            Console.ReadLine()
        Catch ex As UnauthorizedAccessException
            Console.WriteLine("Unauthorized access: {0}", _
                ex.Message)
        Finally
            ewh.Set()
        End Try
    End Sub 
End Class 
'</Snippet1>