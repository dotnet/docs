' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Threading

 Module Example
   Public Sub Main()
      Dim worker As Integer = 0
      Dim io As Integer = 0
      ThreadPool.GetAvailableThreads(worker, io)
      
      Console.WriteLine("Thread pool threads available at startup: ")
      Console.WriteLine("   Worker threads: {0:N0}", worker)
      Console.WriteLine("   Asynchronous I/O threads: {0:N0}", io)
   End Sub
End Module
' The example displays output like the following:
'    Thread pool threads available at startup:
'       Worker threads: 32,767
'       Asynchronous I/O threads: 1,000
' </Snippet2>
