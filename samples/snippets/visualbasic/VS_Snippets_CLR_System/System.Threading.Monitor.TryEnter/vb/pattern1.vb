Option Strict On

Imports System.Threading

Public Class MonitorExamples
   ' TryEnter(Object)
   Public Sub Overload1()
      ' <Snippet1>
      Dim lockObj As New Object()
      
      If Monitor.TryEnter(lockObj) Then
         Try
            ' The critical section.
         Finally
            ' Ensure that the lock is released.
            Monitor.Exit(lockObj)
         End Try
      Else
         ' The lock was not acquired.
      End If
      ' </Snippet1>   
   End Sub
   
   ' TryEnter(Object, Boolean)
   Public Sub Overload2()
      ' <Snippet2>
      Dim lockObj As New Object()
      Dim lockTaken As Boolean = False
      
      Try 
         Monitor.TryEnter(lockObj, lockTaken) 
         If lockTaken Then
            ' The critical section.
         Else 
            ' The lock was not acquired.
         End If
      Finally 
         ' Ensure that the lock is released.
         If lockTaken Then Monitor.Exit(lockObj)
      End Try
      ' </Snippet2>   
   End Sub   

   ' TryEnter(Object, Int32)
   Public Sub Overload3()
      ' <Snippet3>
      Dim lockObj As New Object()
      Dim timeout As Integer = 500
      
      If Monitor.TryEnter(lockObj, timeout) Then
         Try
            ' The critical section.
         Finally
            ' Ensure that the lock is released.
            Monitor.Exit(lockObj)
         End Try
      Else
         ' The lock was not acquired.
      End If
      ' </Snippet3>   
   End Sub
   
   ' TryEnter(Object, Int32, Boolean)
   Public Sub Overload4()
      ' <Snippet4>
      Dim lockObj As New Object()
      Dim timeout As Integer = 500
      Dim lockTaken As Boolean = False
      
      Try
         Monitor.TryEnter(lockObj, timeout, lockTaken)
         If lockTaken Then
            ' The critical section.
         Else
            ' The lock was not acquired.
         End If
      Finally
         ' Ensure that the lock is released.
         If lockTaken Then Monitor.Exit(lockObj)
      End Try
      ' </Snippet4>   
   End Sub
   
   ' TryEnter(Object, TimeSpan)
   Public Sub Overload5()
      ' <Snippet5>
      Dim lockObj As New Object()
      Dim timeout = TimeSpan.FromMilliseconds(500)
      
      If Monitor.TryEnter(lockObj, timeout) Then
         Try
            ' The critical section.
         Finally
            ' Ensure that the lock is released.
            Monitor.Exit(lockObj)
         End Try
      Else
         ' The lock was not acquired.
      End If
      ' </Snippet5>   
   End Sub
   
   ' TryEnter(Object, TimeSpan, Boolean)
   Public Sub Overload6()
      ' <Snippet6>
      Dim lockObj As New Object()
      Dim timeout = TimeSpan.FromMilliseconds(500)
      Dim lockTaken As Boolean = False
      
      Try
         Monitor.TryEnter(lockObj, timeout, lockTaken)
         If lockTaken Then
            ' The critical section.
         Else
            ' The lock was not acquired.
         End If
      Finally
         ' Ensure that the lock is released.
         If lockTaken Then Monitor.Exit(lockObj)
      End Try
      ' </Snippet6>   
   End Sub
End Class
