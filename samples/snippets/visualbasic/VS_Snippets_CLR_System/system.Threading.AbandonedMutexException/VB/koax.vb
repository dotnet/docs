'<Snippet1>
Option Explicit
Imports System
Imports System.Threading

Public Class Example
    Private Shared _dummy As New ManualResetEvent(False)

    Private Shared _orphan1 As New Mutex()
    Private Shared _orphan2 As New Mutex()
    Private Shared _orphan3 As New Mutex()
    Private Shared _orphan4 As New Mutex()
    Private Shared _orphan5 As New Mutex()

    <MTAThread> _
    Public Shared Sub Main()
        ' Start a thread that takes all five mutexes, and then
        ' ends without releasing them.
        '
        Dim t As New Thread(AddressOf AbandonMutex)
        t.Start()
        ' Make sure the thread is finished.
        t.Join()

        ' Wait on one of the abandoned mutexes. The WaitOne returns
        ' immediately, because its wait condition is satisfied by
        ' the abandoned mutex, but on return it throws
        ' AbandonedMutexException.
        Try
            _orphan1.WaitOne()
            Console.WriteLine("WaitOne succeeded.")
        Catch ex As AbandonedMutexException
            Console.WriteLine("Exception on return from WaitOne." _
                & vbCrLf & vbTab & "Message: " _
                & ex.Message) 
        Finally
            ' Whether or not the exception was thrown, the current
            ' thread owns the mutex, and must release it.
            '
            _orphan1.ReleaseMutex()
        End Try

        ' Create an array of wait handles, consisting of one
        ' ManualResetEvent and two mutexes, using two more of the
        ' abandoned mutexes.
        Dim waitFor(2) As WaitHandle
        waitFor(0) = _dummy
        waitFor(1) = _orphan2
        waitFor(2) = _orphan3

        ' WaitAny returns when any of the wait handles in the 
        ' array is signaled, so either of the two abandoned mutexes
        ' satisfy its wait condition. On returning from the wait,
        ' WaitAny throws AbandonedMutexException. The MutexIndex
        ' property returns the lower of the two index values for 
        ' the abandoned mutexes. Note that the Try block and the
        ' Catch block obtain the index in different ways.
        '  
        Try
            Dim index As Integer = WaitHandle.WaitAny(waitFor)
            Console.WriteLine("WaitAny succeeded.")

            Dim m As Mutex = TryCast(waitFor(index), Mutex)

            ' The current thread owns the mutex, and must release
            ' it.
            If m IsNot Nothing Then m.ReleaseMutex()
        Catch ex As AbandonedMutexException
            Console.WriteLine("Exception on return from WaitAny at index " _
                & ex.MutexIndex & "." _
                & vbCrLf & vbTab & "Message: " _
                & ex.Message) 

            ' Whether or not the exception was thrown, the current
            ' thread owns the mutex, and must release it.
            '
            If ex.Mutex IsNot Nothing Then ex.Mutex.ReleaseMutex()            
        End Try

        ' Use two more of the abandoned mutexes for the WaitAll call.
        ' WaitAll doesn't return until all wait handles are signaled,
        ' so the ManualResetEvent must be signaled by calling Set(). 
        _dummy.Set()
        waitFor(1) = _orphan4
        waitFor(2) = _orphan5

        ' The signaled event and the two abandoned mutexes satisfy
        ' the wait condition for WaitAll, but on return it throws
        ' AbandonedMutexException. For WaitAll, the MutexIndex
        ' property is always -1 and the Mutex property is always
        ' Nothing.
        '  
        Try
            WaitHandle.WaitAll(waitFor)
            Console.WriteLine("WaitAll succeeded.")
        Catch ex As AbandonedMutexException
            Console.WriteLine("Exception on return from WaitAll. MutexIndex = " _
                & ex.MutexIndex & "." _
                & vbCrLf & vbTab & "Message: " _
                & ex.Message) 
        Finally
            ' Whether or not the exception was thrown, the current
            ' thread owns the mutexes, and must release them.
            '
            CType(waitFor(1), Mutex).ReleaseMutex()
            CType(waitFor(2), Mutex).ReleaseMutex()
        End Try
    End Sub

    <MTAThread> _
    Public Shared Sub AbandonMutex()
        _orphan1.WaitOne()
        _orphan2.WaitOne()
        _orphan3.WaitOne()
        _orphan4.WaitOne()
        _orphan5.WaitOne()
        ' Abandon the mutexes by exiting without releasing them.
        Console.WriteLine("Thread exits without releasing the mutexes.")
    End Sub
End Class

' This code example produces the following output:
'
'Thread exits without releasing the mutexes.
'Exception on return from WaitOne.
'        Message: The wait completed due to an abandoned mutex.
'Exception on return from WaitAny at index 1.
'        Message: The wait completed due to an abandoned mutex.
'Exception on return from WaitAll. MutexIndex = -1.
'        Message: The wait completed due to an abandoned mutex.
'</Snippet1>
