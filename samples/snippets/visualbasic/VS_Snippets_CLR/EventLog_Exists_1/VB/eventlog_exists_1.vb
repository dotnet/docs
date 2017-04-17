' System.Diagnostics.EventLog.Exists(String)

'  The following sample demonstrates the 'Exists(String)' method of 
'  'EventLog' class. It checks for the existence of a log and displays 
'  the result accordingly.

Imports System
Imports System.Diagnostics

Class EventLog_Exists_1
   Public Shared Sub Main()
      Try
' <Snippet1>
         Dim myLog As String = "myNewLog"
         If EventLog.Exists(myLog) Then
            Console.WriteLine("Log '" + myLog + "' exists.")
         Else
            Console.WriteLine("Log '" + myLog + "' does not exist.")
         End If
' </Snippet1>
      Catch e As Exception
         Console.WriteLine("Exception:" + e.Message)
      End Try
   End Sub 'Main
End Class 'EventLog_Exists_1