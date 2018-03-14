'<Snippet1>
Imports System
Imports System.Threading
Imports System.Security.AccessControl

Friend Class Example

    <MTAThread> _
    Friend Shared Sub Main()
        '<Snippet2>
        Const mutexName As String = "MutexExample4"

        Dim m As Mutex = Nothing
        Dim doesNotExist as Boolean = False
        Dim unauthorized As Boolean = False

        ' The value of this variable is set by the mutex
        ' constructor. It is True if the named system mutex was
        ' created, and False if the named mutex already existed.
        '
        Dim mutexWasCreated As Boolean

        ' Attempt to open the named mutex.
        Try
            ' Open the mutex with (MutexRights.Synchronize Or
            ' MutexRights.Modify), to enter and release the
            ' named mutex.
            '
            m = Mutex.OpenExisting(mutexName)
        Catch ex As WaitHandleCannotBeOpenedException
            Console.WriteLine("Mutex does not exist.")
            doesNotExist = True
        Catch ex As UnauthorizedAccessException
            Console.WriteLine("Unauthorized access: {0}", ex.Message)
            unauthorized = True
        End Try
        '</Snippet2>

        ' There are three cases: (1) The mutex does not exist.
        ' (2) The mutex exists, but the current user doesn't 
        ' have access. (3) The mutex exists and the user has
        ' access.
        '
        If doesNotExist Then
            '<Snippet4>
            ' The mutex does not exist, so create it.

            ' Create an access control list (ACL) that denies the
            ' current user the right to enter or release the 
            ' mutex, but allows the right to read and change
            ' security information for the mutex.
            '
            Dim user As String = Environment.UserDomainName _ 
                & "\" & Environment.UserName
            Dim mSec As New MutexSecurity()

            Dim rule As New MutexAccessRule(user, _
                MutexRights.Synchronize Or MutexRights.Modify, _
                AccessControlType.Deny)
            mSec.AddAccessRule(rule)

            rule = New MutexAccessRule(user, _
                MutexRights.ReadPermissions Or _
                MutexRights.ChangePermissions, _
                AccessControlType.Allow)
            mSec.AddAccessRule(rule)

            ' Create a Mutex object that represents the system
            ' mutex named by the constant 'mutexName', with
            ' initial ownership for this thread, and with the
            ' specified security access. The Boolean value that 
            ' indicates creation of the underlying system object
            ' is placed in mutexWasCreated.
            '
            m = New Mutex(True, mutexName, mutexWasCreated, mSec)

            ' If the named system mutex was created, it can be
            ' used by the current instance of this program, even 
            ' though the current user is denied access. The current
            ' program owns the mutex. Otherwise, exit the program.
            ' 
            If mutexWasCreated Then
                Console.WriteLine("Created the mutex.")
            Else
                Console.WriteLine("Unable to create the mutex.")
                Return
            End If
            '</Snippet4>

        ElseIf unauthorized Then

            '<Snippet3>
            ' Open the mutex to read and change the access control
            ' security. The access control security defined above
            ' allows the current user to do this.
            '
            Try
                m = Mutex.OpenExisting(mutexName, _
                    MutexRights.ReadPermissions Or _
                    MutexRights.ChangePermissions)

                ' Get the current ACL. This requires 
                ' MutexRights.ReadPermissions.
                Dim mSec As MutexSecurity = m.GetAccessControl()
                
                Dim user As String = Environment.UserDomainName _ 
                    & "\" & Environment.UserName

                ' First, the rule that denied the current user 
                ' the right to enter and release the mutex must
                ' be removed.
                Dim rule As New MutexAccessRule(user, _
                    MutexRights.Synchronize Or MutexRights.Modify, _
                    AccessControlType.Deny)
                mSec.RemoveAccessRule(rule)

                ' Now grant the user the correct rights.
                ' 
                rule = New MutexAccessRule(user, _
                    MutexRights.Synchronize Or MutexRights.Modify, _
                    AccessControlType.Allow)
                mSec.AddAccessRule(rule)

                ' Update the ACL. This requires
                ' MutexRights.ChangePermissions.
                m.SetAccessControl(mSec)

                Console.WriteLine("Updated mutex security.")

                ' Open the mutex with (MutexRights.Synchronize 
                ' Or MutexRights.Modify), the rights required to
                ' enter and release the mutex.
                '
                m = Mutex.OpenExisting(mutexName)
                '</Snippet3>

            Catch ex As UnauthorizedAccessException
                Console.WriteLine("Unable to change permissions: {0}", _
                    ex.Message)
                Return
            End Try

        End If

        ' If this program created the mutex, it already owns
        ' the mutex.
        '
        If Not mutexWasCreated Then
            ' Enter the mutex, and hold it until the program
            ' exits.
            '
            Try
                Console.WriteLine("Wait for the mutex.")
                m.WaitOne()
                Console.WriteLine("Entered the mutex.")
            Catch ex As UnauthorizedAccessException
                Console.WriteLine("Unauthorized access: {0}", _
                    ex.Message)
            End Try
        End If

        Console.WriteLine("Press the Enter key to exit.")
        Console.ReadLine()
        m.ReleaseMutex()
        m.Dispose()
    End Sub 
End Class 
'</Snippet1>