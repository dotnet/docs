Imports System.Collections.Generic
Imports System.Diagnostics
'<snippet01>
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks
Module Module1

    Public Class SpinTest

        ' True means "enable thread tracking." This will cause an
        ' exception to be thrown when the first thread attempts to reenter the lock.
        ' Specify False to cause deadlock due to coding error below.
        Private Shared _spinLock = New SpinLock(True)

        Public Shared Sub Main()

            Parallel.Invoke(
                Sub() DoWork(),
                Sub() DoWork(),
                Sub() DoWork(),
                Sub() DoWork()
                )

            Console.WriteLine("Press any key.")
            Console.ReadKey()
        End Sub

        Public Shared Sub DoWork()

            Dim sb = New StringBuilder()

            For i As Integer = 1 To 9999

                Dim lockTaken As Boolean = False

                Try
                    _spinLock.Enter(lockTaken)

                    ' do work here protected by the lock
                    Thread.SpinWait(50000)
                    sb.Append(Thread.CurrentThread.ManagedThreadId)
                    sb.Append(" Entered-")

                Catch ex As LockRecursionException
                    Console.WriteLine("Thread {0} attempted to reenter the lock",
                                       Thread.CurrentThread.ManagedThreadId)
                    Throw

                Finally

                    ' INTENTIONAL CODING ERROR TO DEMONSTRATE THREAD TRACKING! 
                    ' UNCOMMENT THE LINES FOR CORRECT SPINLOCK BEHAVIOR
                    ' Commenting out these lines causes the same thread
                    ' to attempt to reenter the lock. If the SpinLock was
                    ' created with thread tracking enabled, the exception
                    ' is thrown. Otherwise, if the SpinLock was created with a 
                    ' parameter of false, and these lines are left commented, the spinlock deadlocks.
                    If (lockTaken) Then

                        '  _spinLock.Exit()
                        '  sb.Append("Exited ")
                    End If
                End Try

                ' Output for diagnostic display.
                If (i Mod 4 <> 0) Then
                    Console.Write(sb.ToString())
                Else
                    Console.WriteLine(sb.ToString())
                End If
                sb.Clear()
            Next
        End Sub
    End Class
End Module
'</snippet01>
