' Visual Basic .NET Document
Option Strict On

Imports System.Runtime

Module Example
   Public Sub Main()
      ' <Snippet1>
      GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce
      GC.Collect()      
      ' </Snippet1>
   End Sub
End Module
