' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Reflection

Module Example
   Public Sub Main()
      Dim t As Type = GetType(Nullable(Of )) 
      Console.WriteLine(t.FullName)
      If t.IsGenericType Then
         Console.Write("   Generic Type Parameters: ")
         Dim gtArgs As Type() = t.GetGenericArguments
         For ctr As Integer = 0 To gtArgs.Length - 1
            Console.WriteLine(If(gtArgs(ctr).FullName, 
                              "(unassigned) " + gtArgs(ctr).ToString()))
            If ctr < gtArgs.Length - 1 Then Console.Write(", ")   
         Next
         Console.WriteLine()
      End If
   End Sub
End Module
' The example displays the following output:
'       System.Nullable`1
'          Generic Type Parameters: (unassigned) T
' </Snippet3>
