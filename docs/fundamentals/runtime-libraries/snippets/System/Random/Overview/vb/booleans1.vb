' Visual Basic .NET Document
Option Strict On

' <Snippet8>
Module Example2
    Public Sub Main()
        ' Instantiate the Boolean generator.
        Dim boolGen As New BooleanGenerator()
        Dim totalTrue, totalFalse As Integer

        ' Generate 1,0000 random Booleans, and keep a running total.
        For ctr As Integer = 0 To 9999999
            Dim value As Boolean = boolGen.NextBoolean()
            If value Then
                totalTrue += 1
            Else
                totalFalse += 1
            End If
        Next
        Console.WriteLine("Number of true values:  {0,7:N0} ({1:P3})",
                        totalTrue,
                        totalTrue / (totalTrue + totalFalse))
        Console.WriteLine("Number of false values: {0,7:N0} ({1:P3})",
                        totalFalse,
                        totalFalse / (totalTrue + totalFalse))
    End Sub
End Module

Public Class BooleanGenerator
   Dim rnd As Random
   
   Public Sub New()
      rnd = New Random()
   End Sub

   Public Function NextBoolean() As Boolean
      Return Convert.ToBoolean(rnd.Next(0, 2))
   End Function
End Class
' The example displays the following output:
'       Number of true values:  500,004 (50.000 %)
'       Number of false values: 499,996 (50.000 %)
' </Snippet8>
