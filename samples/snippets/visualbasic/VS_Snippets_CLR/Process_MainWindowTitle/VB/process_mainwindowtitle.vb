' System.Diagnostics.Process.MainWindowTitle

' The following program demonstrates the property 'MainWindowTitle' of class
' 'Process'. It creates a new process notepad on local computer and displays
' its caption to console.
' <Snippet1>
Imports System
Imports System.Diagnostics

Class MainWindowTitleClass
   Public Shared Sub Main()
      Try

         ' Create an instance of process component.
         Dim myProcess As New Process()
         ' Create an instance of 'myProcessStartInfo'.
         Dim myProcessStartInfo As New ProcessStartInfo()
         myProcessStartInfo.FileName = "notepad"
         myProcess.StartInfo = myProcessStartInfo
         ' Start process.
         myProcess.Start()
         ' Allow the process to finish starting.
         myProcess.WaitForInputIdle()
         Console.Write("Main window Title : " + myProcess.MainWindowTitle)

         myProcess.CloseMainWindow()
         myProcess.Close()
      Catch e As Exception
         Console.Write(" Message : " + e.Message)
      End Try
   End Sub 'Main
End Class 'MainWindowTitleClass
' </Snippet1>