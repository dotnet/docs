' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Imports System.Collections.Generic

Module Example
   Dim numbers As New List(Of Integer)

   Public Sub Main()
      Dim startValue As Integer 
      Dim args() As String = Environment.GetCommandLineArgs()
      If args.Length < 2 Then
         startValue = 2
      Else
         If Not Int32.TryParse(args(1), startValue) Then
            startValue = 2
         End If   
      End If
      ShowValues(startValue)
   End Sub
   
   Private Sub ShowValues(startValue As Integer)   
      ' Create a collection with numeric values.
      If numbers.Count = 0 Then 
         numbers.AddRange( { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22} )
      End If   
      ' Get the index of startValue.
      Dim startIndex As Integer = numbers.IndexOf(startValue)
      If startIndex < 0 Then
         Console.WriteLine("Unable to find {0} in the collection.", startValue)
      Else
         ' Display all numbers from startIndex on.
         Console.WriteLine("Displaying values greater than or equal to {0}:",
                        startValue)
         For ctr As Integer = startIndex To numbers.Count - 1
            Console.Write("    {0}", numbers(ctr))
         Next
      End If
   End Sub
End Module
' The example displays the following output if the user supplies
'       Unable to find 7 in the collection.
' </Snippet6>
