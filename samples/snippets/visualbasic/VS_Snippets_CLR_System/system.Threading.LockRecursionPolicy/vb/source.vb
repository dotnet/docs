'<Snippet1>
Imports System
Imports System.Threading

Class Example
    ' By default, the lock recursion policy for a new 
    ' ReaderWriterLockSlim does not allow recursion.
    Private Shared rwls As New ReaderWriterLockSlim()
    Private Shared rwlsWithRecursion _
        As New ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion)
    
    Shared Sub ThreadProc() 
        
        Console.WriteLine("1. Enter the read lock recursively.")
        ReadRecursive(rwls)
        ReadRecursive(rwlsWithRecursion)
    
        Console.WriteLine(vbCrLf & _
            "2. Enter the write lock recursively from the read lock.")
        ReadWriteRecursive(rwls)
        ReadWriteRecursive(rwlsWithRecursion)

    End Sub 

    Shared Sub ReadRecursive(ByVal rwls As ReaderWriterLockSlim)

        Console.WriteLine("LockRecursionPolicy.{0}:", rwls.RecursionPolicy)
        rwls.EnterReadLock()
        
        Try
            rwls.EnterReadLock()
            Console.WriteLine(vbTab & _
                "The read lock was entered recursively.")
            rwls.ExitReadLock()
        Catch lre As LockRecursionException
            Console.WriteLine(vbTab & "{0}: {1}", _
                lre.GetType().Name, lre.Message)
        End Try

        rwls.ExitReadLock()
    End Sub

    Shared Sub ReadWriteRecursive(ByVal rwls As ReaderWriterLockSlim)

        Console.WriteLine("LockRecursionPolicy.{0}:", rwls.RecursionPolicy)
        rwls.EnterReadLock()

        Try
            rwls.EnterWriteLock()
            Console.WriteLine(vbTab & _
                "The write lock was entered recursively.")
        Catch lre As LockRecursionException
            Console.WriteLine(vbTab & "{0}: {1}", _
                lre.GetType().Name, lre.Message)
        End Try

        rwls.ExitReadLock()
    End Sub
    
    Shared Sub Main() 

        Dim t As New Thread(AddressOf ThreadProc)
        t.Start()
        t.Join()

        ' Dispose of ReaderWriterLockSlim objects' unmanaged resources.
        If rwls IsNot Nothing Then rwls.Dispose()
        If rwlsWithRecursion IsNot Nothing Then _
           rwlsWithRecursion.Dispose()
    End Sub 
End Class 

' This code example produces output similar to the following:
'
'1. Enter the read lock recursively.
'LockRecursionPolicy.NoRecursion:
'        LockRecursionException: Recursive read lock acquisitions not allowed in this mode.
'LockRecursionPolicy.SupportsRecursion:
'        The read lock was entered recursively.
'
'2. Enter the write lock recursively from the read lock.
'LockRecursionPolicy.NoRecursion:
'        LockRecursionException: Write lock may not be acquired with read lock held. This pattern is prone to deadlocks. Consider using the upgrade lock.
'LockRecursionPolicy.SupportsRecursion:
'        LockRecursionException: Write lock may not be acquired with read lock held. This pattern is prone to deadlocks. Consider using the upgrade lock.
' 
'</Snippet1>
