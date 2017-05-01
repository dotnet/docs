' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Diagnostics

Public Class ExampleClass
   Dim sw As StopWatch
   
   Public Sub New()
      sw = Stopwatch.StartNew()
      Console.WriteLine("Instantiated object")
   End Sub 

   Public Sub ShowDuration()
      Console.WriteLine("This instance of {0} has been in existence for {1}",
                        Me, sw.Elapsed)
   End Sub
   
   Protected Overrides Sub Finalize()
      Console.WriteLine("Finalizing object")
      sw.Stop()
      Console.WriteLine("This instance of {0} has been in existence for {1}",
                        Me, sw.Elapsed)
   End Sub
End Class

Module Demo
   Public Sub Main()
      Dim ex As New ExampleClass()
      ex.ShowDuration()
   End Sub
End Module
' The example displays output like the following:
'    Instantiated object
'    This instance of ExampleClass has been in existence for 00:00:00.0011060
'    Finalizing object
'    This instance of ExampleClass has been in existence for 00:00:00.0036294
' </Snippet1>
