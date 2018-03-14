'<Snippet1>
Imports System
Imports System.Threading
Imports System.Security.AccessControl

Friend Class Example

    <MTAThread> _
    Friend Shared Sub Main()
        '<Snippet2>
        Const semaphoreName As String = "SemaphoreExample5"

        Dim sem As Semaphore = Nothing
        Dim doesNotExist as Boolean = False
        Dim unauthorized As Boolean = False

        ' Attempt to open the named semaphore.
        Try
            ' Open the semaphore with (SemaphoreRights.Synchronize
            ' Or SemaphoreRights.Modify), to enter and release the
            ' named semaphore.
            '
            sem = Semaphore.OpenExisting(semaphoreName)
        Catch ex As WaitHandleCannotBeOpenedException
            Console.WriteLine("Semaphore does not exist.")
            doesNotExist = True
        Catch ex As UnauthorizedAccessException
            Console.WriteLine("Unauthorized access: {0}", ex.Message)
            unauthorized = True
        End Try
        '</Snippet2>

        ' There are three cases: (1) The semaphore does not exist.
        ' (2) The semaphore exists, but the current user doesn't 
        ' have access. (3) The semaphore exists and the user has
        ' access.
        '
        If doesNotExist Then
            '<Snippet4>
            ' The semaphore does not exist, so create it.
            '
            ' The value of this variable is set by the semaphore
            ' constructor. It is True if the named system semaphore was
            ' created, and False if the named semaphore already existed.
            '
            Dim semaphoreWasCreated As Boolean

            ' Create an access control list (ACL) that denies the
            ' current user the right to enter or release the 
            ' semaphore, but allows the right to read and change
            ' security information for the semaphore.
            '
            Dim user As String = Environment.UserDomainName _ 
                & "\" & Environment.UserName
            Dim semSec As New SemaphoreSecurity()

            Dim rule As New SemaphoreAccessRule(user, _
                SemaphoreRights.Synchronize Or SemaphoreRights.Modify, _
                AccessControlType.Deny)
            semSec.AddAccessRule(rule)

            rule = New SemaphoreAccessRule(user, _
                SemaphoreRights.ReadPermissions Or _
                SemaphoreRights.ChangePermissions, _
                AccessControlType.Allow)
            semSec.AddAccessRule(rule)

            ' Create a Semaphore object that represents the system
            ' semaphore named by the constant 'semaphoreName', with
            ' maximum count three, initial count three, and the
            ' specified security access. The Boolean value that 
            ' indicates creation of the underlying system object is
            ' placed in semaphoreWasCreated.
            '
            sem = New Semaphore(3, 3, semaphoreName, _
                semaphoreWasCreated, semSec)

            ' If the named system semaphore was created, it can be
            ' used by the current instance of this program, even 
            ' though the current user is denied access. The current
            ' program enters the semaphore. Otherwise, exit the
            ' program.
            ' 
            If semaphoreWasCreated Then
                Console.WriteLine("Created the semaphore.")
            Else
                Console.WriteLine("Unable to create the semaphore.")
                Return
            End If
            '</Snippet4>

        ElseIf unauthorized Then

            '<Snippet3>
            ' Open the semaphore to read and change the access
            ' control security. The access control security defined
            ' above allows the current user to do this.
            '
            Try
                sem = Semaphore.OpenExisting(semaphoreName, _
                    SemaphoreRights.ReadPermissions Or _
                    SemaphoreRights.ChangePermissions)

                ' Get the current ACL. This requires 
                ' SemaphoreRights.ReadPermissions.
                Dim semSec As SemaphoreSecurity = sem.GetAccessControl()
                
                Dim user As String = Environment.UserDomainName _ 
                    & "\" & Environment.UserName

                ' First, the rule that denied the current user 
                ' the right to enter and release the semaphore must
                ' be removed.
                Dim rule As New SemaphoreAccessRule(user, _
                    SemaphoreRights.Synchronize Or SemaphoreRights.Modify, _
                    AccessControlType.Deny)
                semSec.RemoveAccessRule(rule)

                ' Now grant the user the correct rights.
                ' 
                rule = New SemaphoreAccessRule(user, _
                    SemaphoreRights.Synchronize Or SemaphoreRights.Modify, _
                    AccessControlType.Allow)
                semSec.AddAccessRule(rule)

                ' Update the ACL. This requires
                ' SemaphoreRights.ChangePermissions.
                sem.SetAccessControl(semSec)

                Console.WriteLine("Updated semaphore security.")

                ' Open the semaphore with (SemaphoreRights.Synchronize 
                ' Or SemaphoreRights.Modify), the rights required to
                ' enter and release the semaphore.
                '
                sem = Semaphore.OpenExisting(semaphoreName)
                '</Snippet3>

            Catch ex As UnauthorizedAccessException
                Console.WriteLine("Unable to change permissions: {0}", _
                    ex.Message)
                Return
            End Try

        End If

        ' Enter the semaphore, and hold it until the program
        ' exits.
        '
        Try
            sem.WaitOne()
            Console.WriteLine("Entered the semaphore.")
            Console.WriteLine("Press the Enter key to exit.")
            Console.ReadLine()
            sem.Release()
        Catch ex As UnauthorizedAccessException
            Console.WriteLine("Unauthorized access: {0}", _
                ex.Message)
        End Try
    End Sub 
End Class 
'</Snippet1>