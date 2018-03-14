' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Threading

Module Example
   Dim thread1, thread2 As Thread

   Public Sub Main()
      thread1 = new Thread(AddressOf ThreadProc)
      thread1.Name = "Thread1"
      thread1.Start()
      
      thread2 = New Thread(AddressOf ThreadProc)
      thread2.Name = "Thread2"
      thread2.Start()   
   End Sub

   Private Sub ThreadProc()
      Console.WriteLine()
      Console.WriteLine("Current thread: {0}", Thread.CurrentThread.Name)
      If (Thread.CurrentThread.Name = "Thread1" And 
          thread2.ThreadState <> ThreadState.Unstarted)
         thread2.Join()
      End If
      Thread.Sleep(4000)
      Console.WriteLine()
      Console.WriteLine("Current thread: {0}", Thread.CurrentThread.Name)
      Console.WriteLine("Thread1: {0}", thread1.ThreadState)
      Console.WriteLine("Thread2: {0}", thread2.ThreadState)
      Console.WriteLine()
   End Sub
End Module
' The example displays output like the following :
'       Current thread: Thread1
'       
'       Current thread: Thread2
'       
'       Current thread: Thread2
'       Thread1: WaitSleepJoin
'       Thread2: Running
'       
'       
'       Current thread: Thread1
'       Thread1: Running
'       Thread2: Stopped
' </Snippet1>
