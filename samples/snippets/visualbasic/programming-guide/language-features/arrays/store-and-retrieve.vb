
Module Example
   Public Sub Main()
      ' Create a 10-element integer array.
      Dim numbers(9) As Integer
      Dim value As Integer = 2
        
      ' Write values to it.
      For ctr As Integer = 0 To 9
         numbers(ctr) = value
         value *= 2
      Next
        
      ' Read and sum the array values.  
      Dim sum As Integer
      For ctr As Integer = 0 To 9
         sum += numbers(ctr)
      Next
      Console.WriteLine($"The sum of the values is {sum:N0}")
    End Sub
End Module
' The example displays the following output:
'     The sum of the values is 2,046
