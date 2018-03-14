' Visual Basic .NET Document
Option Strict On

Imports System.Runtime

Module Example
   Public Sub Main()

      ' <Snippet1>
      GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce
      GC.Collect(2, GCCollectionMode.Forced, True, True)
      ' </Snippet1>
   End Sub
   
   Private Sub CreateObjects()
   End Sub
End Module

