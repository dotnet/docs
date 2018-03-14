' Visual Basic .NET Document
Option Strict On

' <Snippet5>
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
      ' Get the index of a particular number, in this case 7.
      Console.WriteLine("Displaying values greater than or equal to {0}:",
                        startValue)
      Dim startIndex As Integer = numbers.IndexOf(startValue)
      ' Display all numbers from startIndex on.
      For ctr As Integer = startIndex To numbers.Count - 1
         Console.Write("    {0}", numbers(ctr))
      Next
   End Sub
End Module
' The example displays the following output if the user supplies
' 7 as a command-line parameter:
'    Displaying values greater than or equal to 7:
'    
'    Unhandled Exception: System.ArgumentOutOfRangeException: 
'    Index was out of range. Must be non-negative and less than the size of the collection.
'    Parameter name: index
'       at System.Collections.Generic.List`1.get_Item(Int32 index)
'       at Example.ShowValues(Int32 startValue)
'       at Example.Main()
' </Snippet5>
