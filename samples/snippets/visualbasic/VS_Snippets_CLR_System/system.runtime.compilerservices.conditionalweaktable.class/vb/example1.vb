' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Runtime.CompilerServices

Module Example
   Public Sub Main()
      Dim mc1 As New ManagedClass()
      Dim mc2 As New ManagedClass()
      Dim mc3 As New ManagedClass()
                    
      Dim cwt As New ConditionalWeakTable(Of ManagedClass, ClassData)()
      cwt.Add(mc1, New ClassData())          
      cwt.Add(mc2, New ClassData())
      cwt.Add(mc3, New ClassData())
      
      Dim wr2 As New WeakReference(mc2)
      mc2 = Nothing

      GC.Collect()

      Dim data As ClassData = Nothing

      If wr2.Target Is Nothing Then
          Console.WriteLine("No strong reference to mc2 exists.")   
      Else If cwt.TryGetValue(mc2, data) Then
          Console.WriteLine("Data created at {0}", data.CreationTime)      
      Else
          Console.WriteLine("mc2 not found in the table.")
      End If
   End Sub
End Module

Public Class ManagedClass
End Class

Public Class ClassData
   Public CreationTime As DateTime
   Public Data As Object   
   
   Public Sub New()
      Me.CreationTime = DateTime.Now
      Me.Data  = New Object()     
   End Sub
End Class
' The example displays the following output:
'       No strong reference to mc2 exists.
' </Snippet1>