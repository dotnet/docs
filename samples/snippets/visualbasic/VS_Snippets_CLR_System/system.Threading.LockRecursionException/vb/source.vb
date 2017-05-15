'<Snippet1>
Imports System
Imports System.Threading

Class Example
    ' By default, the lock recursion policy for a new 
    ' ReaderWriterLockSlim does not allow recursion.
    Private Shared rwls As New ReaderWriterLockSlim()
    
    Shared Sub ThreadProc() 
        Console.WriteLine("Acquire the reader lock.")
        rwls.EnterReadLock()
        
        Try
            Console.WriteLine(vbCrLf & _
                "Attempt to acquire the reader lock recursively:")
            rwls.EnterReadLock()
        Catch lre As LockRecursionException
            Console.WriteLine("{0}: {1}", _
                lre.GetType().Name, lre.Message)
        End Try
        
        Try
            Console.WriteLine(vbCrLf & _
                "Attempt to acquire the writer lock recursively:")
            rwls.EnterWriteLock()
        Catch lre As LockRecursionException
            Console.WriteLine("{0}: {1}", _
                lre.GetType().Name, lre.Message)
        End Try
    
    End Sub 
    
    Shared Sub Main() 

        Dim t As New Thread(AddressOf ThreadProc)
        t.Start()
        t.Join()
    
    End Sub 
End Class 

' This code example produces output similar to the following:
'
'Acquire the reader lock.
'
'Attempt to acquire the reader lock recursively:
'LockRecursionException: Recursive read lock acquisitions not allowed in this mode.
'
'Attempt to acquire the writer lock recursively:
'LockRecursionException: Write lock may not be acquired with read lock held. This pattern is prone to deadlocks. Consider using the upgrade lock.
' 
'</Snippet1>
