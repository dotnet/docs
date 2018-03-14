' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Threading

Module Example
   Public Sub Main()
      Dim t As New Timer(AddressOf TimerNotification, Nothing, 
                         100, Timeout.Infinite)
      Thread.Sleep(2000)
      t.Dispose()
      
      t.Change(200, 1000)                   
      Thread.Sleep(3000)
   End Sub

   Private Sub TimerNotification(obj As Object)
      Console.WriteLine("Timer event fired at {0:F}", Date.Now)
   End Sub
End Module
' The example displays output like the following:
'    Timer event fired at Monday, July 14, 2014 11:54:08 AM
'    
'    Unhandled Exception: System.ObjectDisposedException: Cannot access a disposed object.
'       at System.Threading.TimerQueueTimer.Change(UInt32 dueTime, UInt32 period)
'       at Example.Main()
' </Snippet1>

