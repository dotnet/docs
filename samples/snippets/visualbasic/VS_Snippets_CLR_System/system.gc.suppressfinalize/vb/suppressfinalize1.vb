' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.ComponentModel
Imports System.Runtime.InteropServices

Public Class ConsoleMonitor
   Private Const STD_INPUT_HANDLE As Integer = -10
   Private Const STD_OUTPUT_HANDLE As Integer = -11
   Private Const STD_ERROR_HANDLE As Integer = -12

   Private Declare Function GetStdHandle Lib "kernel32" _
                            (nStdHandle As Integer) As IntPtr

   Private Declare Function WriteConsole Lib "kernel32" _
                            Alias "WriteConsoleA" _
                            (hConsoleOutput As IntPtr, lpBuffer As String,
                            nNumberOfCharsToWrite As UInteger, 
                            ByRef lpNumberOfCharsWritten As UInteger,
                            lpReserved As IntPtr) As Boolean 

   Private Declare Function CloseHandle Lib "kernel32" _ 
                           (handle As IntPtr) As Boolean
                    
   Private disposed As Boolean = False
   Private handle As IntPtr
   Private component As Component
   
   Public Sub New()
      handle = GetStdHandle(STD_OUTPUT_HANDLE)
      If handle = IntPtr.Zero Then
         Throw New InvalidOperationException("A console handle is not available.")
      End If
      
      component = new Component()
      
      Dim output As String = "The ConsoleMonitor class constructor." + vbCrLf
      Dim written As UInteger = 0
      WriteConsole(handle, output, CUInt(output.Length), written, IntPtr.Zero)
   End Sub

   Protected Overrides Sub Finalize()
      If handle <> IntPtr.Zero Then
         Dim output As String = "The ConsoleMonitor finalizer." + vbCrLf
         Dim written As UInteger = 0
         WriteConsole(handle, output, CUInt(output.Length), written, IntPtr.Zero)
      Else     
         Console.Error.WriteLine("Object finalization.")
      End If
      ' Call Dispose with disposing = false.
      Dispose(false)
   End Sub

   Public Sub Write()
      Dim output As String = "The Write method." + vbCrLf
      Dim written As UInteger = 0
      WriteConsole(handle, output, CUInt(output.Length), written, IntPtr.Zero)
   End Sub

   Public Sub Dispose()
      Dim output As String =  "The Dispose method." + vbCrLf
      Dim written As UInteger = 0
      WriteConsole(handle, output, CUInt(output.Length), written, IntPtr.Zero)

      Dispose(True)
      GC.SuppressFinalize(Me) 
   End Sub

   Private Sub Dispose(disposing As Boolean)
      Dim output As String =  String.Format("The Dispose({0}) method.{1}", 
                                            disposing, vbCrLf)
      Dim written As UInteger = 0
      WriteConsole(handle, output, CUInt(output.Length), written, IntPtr.Zero)

      ' Execute if resources have not already been disposed.
      If Not disposed Then
         ' If the call is from Dispose, free managed resources.
         If disposing Then
            Console.Error.WriteLine("Disposing of managed resources.")
            If component IsNot Nothing Then component.Dispose()
         End If
         ' Free unmanaged resources.
         output = "Disposing of unmanaged resources."
         WriteConsole(handle, output, CUInt(output.Length), written, IntPtr.Zero)
         
         If handle <> IntPtr.Zero Then
            If Not CloseHandle(handle) Then
               Console.Error.WriteLine("Handle cannot be closed.")
            End If    
         End If   
      End If
      disposed = True
   End Sub
End Class

Module Example
   Public Sub Main()
      Console.WriteLine("ConsoleMonitor instance....")
      Dim monitor As New ConsoleMonitor
      monitor.Write()
      monitor.Dispose()
   End Sub
End Module
' If the monitor.Dispose method is not called, the example displays the following output:
'       ConsoleMonitor instance....
'       The ConsoleMonitor class constructor.
'       The Write method.
'       The ConsoleMonitor finalizer.
'       The Dispose(False) method.
'       Disposing of unmanaged resources.
'       
' If the monitor.Dispose method is called, the example displays the following output:
'       ConsoleMonitor instance....
'       The ConsoleMonitor class constructor.
'       The Write method.
'       The Dispose method.
'       The Dispose(True) method.
'       Disposing of managed resources.
'       Disposing of unmanaged resources.
' </Snippet1>
