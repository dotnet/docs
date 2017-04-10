'<snippet1>
Imports System
Imports System.Threading
Imports System.Runtime.InteropServices

' A simple class that exposes two static Win32 functions.
' One is a delegate type and the other is an enumerated type.

Public Class MyWin32

   ' Declare the SetConsoleCtrlHandler function as external 
   ' and receiving a delegate.   
   <DllImport("Kernel32")> _
   Public Shared Function SetConsoleCtrlHandler(ByVal Handler As HandlerRoutine, _
         ByVal Add As Boolean) As Boolean
   End Function


   ' A delegate type to be used as the handler routine 
   ' for SetConsoleCtrlHandler.
   Delegate Function HandlerRoutine(ByVal CtrlType As CtrlTypes) As [Boolean]

   ' An enumerated type for the control messages 
   ' sent to the handler routine.

   Public Enum CtrlTypes
      CTRL_C_EVENT = 0
      CTRL_BREAK_EVENT
      CTRL_CLOSE_EVENT
      CTRL_LOGOFF_EVENT = 5
      CTRL_SHUTDOWN_EVENT
   End Enum
End Class

Public Class MyApp

   ' A private static handler function in the MyApp class.
   Shared Function Handler(ByVal CtrlType As MyWin32.CtrlTypes) As [Boolean]
      Dim message As [String] = "This message should never be seen!"

      ' A select case to handle the event type.
      Select Case CtrlType
         Case MyWin32.CtrlTypes.CTRL_C_EVENT
            message = "A CTRL_C_EVENT was raised by the user."
         Case MyWin32.CtrlTypes.CTRL_BREAK_EVENT
            message = "A CTRL_BREAK_EVENT was raised by the user."
         Case MyWin32.CtrlTypes.CTRL_CLOSE_EVENT
            message = "A CTRL_CLOSE_EVENT was raised by the user."
         Case MyWin32.CtrlTypes.CTRL_LOGOFF_EVENT
            message = "A CTRL_LOGOFF_EVENT was raised by the user."
         Case MyWin32.CtrlTypes.CTRL_SHUTDOWN_EVENT
            message = "A CTRL_SHUTDOWN_EVENT was raised by the user."
      End Select

      ' Use interop to display a message for the type of event.
      Console.WriteLine(message)

      Return True
   End Function


   Public Shared Sub Main()
      ' Use interop to set a console control handler.
      Dim hr As New MyWin32.HandlerRoutine(AddressOf Handler)
      MyWin32.SetConsoleCtrlHandler(hr, True)

      ' Give the user some time to raise a few events.
      Console.WriteLine("Waiting 30 seconds for console ctrl events...")

      ' The object hr is not referred to again.
      ' The garbage collector can detect that the object has no
      ' more managed references and might clean it up here while
      ' the unmanaged SetConsoleCtrlHandler method is still using it.      
      ' Force a garbage collection to demonstrate how the hr
      ' object will be handled.
      GC.Collect()
      GC.WaitForPendingFinalizers()
      GC.Collect()

      Thread.Sleep(30000)

      ' Display a message to the console when the unmanaged method
      ' has finished its work.
      Console.WriteLine("Finished!")

      ' Call GC.KeepAlive(hr) at this point to maintain a reference to hr. 
      ' This will prevent the garbage collector from collecting the 
      ' object during the execution of the SetConsoleCtrlHandler method.
      GC.KeepAlive(hr)
      Console.Read()
   End Sub
End Class

'</snippet1>