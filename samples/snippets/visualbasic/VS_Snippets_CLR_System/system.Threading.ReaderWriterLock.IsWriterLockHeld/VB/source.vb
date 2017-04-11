' <Snippet1>
Imports System
Imports System.Threading

Public Class LockHeld

    <MTAThread> _
    Shared Sub Main()
    
        Dim rwLock As New ReaderWriterLock()

        rwLock.AcquireWriterLock(Timeout.Infinite)
        rwLock.AcquireReaderLock(Timeout.Infinite)

        If rwLock.IsReaderLockHeld Then
            Console.WriteLine("Reader lock held.")
            rwLock.ReleaseReaderLock()
        Else If rwLock.IsWriterLockHeld Then
            Console.WriteLine("Writer lock held.")
            rwLock.ReleaseWriterLock()
        Else
            Console.WriteLine("No locks held.")
        End If

        If rwLock.IsReaderLockHeld Then
            Console.WriteLine("Reader lock held.")
            rwLock.ReleaseReaderLock()
        Else If rwLock.IsWriterLockHeld Then
            Console.WriteLine("Writer lock held.")
            rwLock.ReleaseWriterLock()
        Else
            Console.WriteLine("No locks held.")
        End If
    
    End Sub
End Class
' </Snippet1>