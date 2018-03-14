' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim t As Task = Task.Run( Sub()
                                   Dim rnd As New Random()
                                   Dim sum As Long
                                   Dim n As Integer = 5000000
                                   For ctr As Integer = 1 To n
                                      Dim number As Integer = rnd.Next(0, 101)
                                      sum += number
                                   Next
                                   Console.WriteLine("Total:   {0:N0}", sum)
                                   Console.WriteLine("Mean:    {0:N2}", sum/n)
                                   Console.WriteLine("N:       {0:N0}", n)   
                                End Sub)
     If Not t.Wait(150) Then
        Console.WriteLine("The timeout interval elapsed.")
     End If
   End Sub
End Module
' The example displays output similar to the following:
'       Total:   50,015,714
'       Mean:    50.02
'       N:       1,000,000
' Or it displays the following output:
'       The timeout interval elapsed.
' </Snippet5>
