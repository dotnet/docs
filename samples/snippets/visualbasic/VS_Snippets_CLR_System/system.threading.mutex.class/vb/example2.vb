' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Threading

Class Example
   ' Create a new Mutex. The creating thread does not own the mutex.
   Private mut As New Mutex()
   Private Const numIterations As Integer = 1
   Private Const numThreads As Integer = 3

   Public Shared Sub Main()
      Dim ex As New Example()
      ex.StartThreads()
   End Sub
   
   Private Sub StartThreads()
        ' Create the threads that will use the protected resource.
        For i As Integer = 0 To numThreads - 1
            Dim newThread As New Thread(AddressOf ThreadProc)
            newThread.Name = String.Format("Thread{0}", i + 1)
            newThread.Start()
        Next

        ' The main thread returns to Main and exits, but the application continues to
        ' run until all foreground threads have exited.
   End Sub

   Private Sub ThreadProc()
        For i As Integer = 0 To numIterations - 1
            UseResource()
        Next
   End Sub

   ' This method represents a resource that must be synchronized
   ' so that only one thread at a time can enter.
   Private Sub UseResource()
        ' Wait until it is safe to enter.
        Console.WriteLine("{0} is requesting the mutex", 
                          Thread.CurrentThread.Name)
        If mut.WaitOne(1000) Then
           Console.WriteLine("{0} has entered the protected area", 
               Thread.CurrentThread.Name)
   
           ' Place code to access non-reentrant resources here.
   
           ' Simulate some work.
           Thread.Sleep(5000)
   
           Console.WriteLine("{0} is leaving the protected area", 
               Thread.CurrentThread.Name)
   
           ' Release the Mutex.
           mut.ReleaseMutex()
           Console.WriteLine("{0} has released the mutex", 
                             Thread.CurrentThread.Name)
        Else
           Console.WriteLine("{0} will not acquire the mutex", 
                             Thread.CurrentThread.Name)
        End If
   End Sub
   
   Protected Overrides Sub Finalize()
      mut.Dispose()
   End Sub
End Class
' The example displays output like the following:
'       Thread1 is requesting the mutex
'       Thread1 has entered the protected area
'       Thread2 is requesting the mutex
'       Thread3 is requesting the mutex
'       Thread2 will not acquire the mutex
'       Thread3 will not acquire the mutex
'       Thread1 is leaving the protected area
'       Thread1 has released the mutex
' </Snippet2>

