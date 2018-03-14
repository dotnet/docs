' Visual Basic .NET Document
Option Strict On

Imports System.Runtime

Module Example
   Public Sub Main()
     ' <Snippet1>
     If GCSettings.LatencyMode = GCLatencyMode.NoGCRegion Then
        GC.EndNoGCRegion()
     End If
     ' </Snippet1>
   End Sub
End Module


Public Class GC
   Public Shared Sub EndNoGCRegion()
   End Sub
End Class

Public Enum GCLatencyMode As Integer
     Batch = 0
     Interactive = 1
     LowLatency = 2
     SustainedLowLatency = 3
     NoGCRegion = 4
End Enum

