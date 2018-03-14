'<snippet1>
Imports System
Imports System.Runtime

Class Sample
   Public Shared Sub Main()
      Dim result As String
      
      If GCSettings.IsServerGC = True Then
         result = "server"
      Else
         result = "workstation"
      End If
      Console.WriteLine("The {0} garbage collector is running.", result)
   End Sub
End Class 
' The example displays output like the following:
'      The workstation garbage collector is running.
'</snippet1>