' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Threading
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Thread.CurrentThread.Name = "Main"
      
      ' Better: Create and start the task in one operation. 
      Dim taskA = Task.Factory.StartNew(Sub() Console.WriteLine("Hello from taskA."))
      
      ' Output a message from the calling thread.
      Console.WriteLine("Hello from thread '{0}'.", 
                        Thread.CurrentThread.Name)

      taskA.Wait()                  
   End Sub
End Module
' The example displays output like the following:
'       Hello from thread 'Main'.
'       Hello from taskA.
' </Snippet3>
