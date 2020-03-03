
Module Example
   Public Sub Main()
      Dim jagged = { ({1, 2}), ({2, 3, 4}), ({5, 6}), ({7, 8, 9, 10}) }
      Console.WriteLine($"The value of jagged.Length: {jagged.Length}.")
      Dim total = jagged.Length
      For ctr As Integer = 0 To jagged.GetUpperBound(0)
         Console.WriteLine($"Element {ctr + 1} has {jagged(ctr).Length} elements.") 
         total += jagged(ctr).Length 
      Next
      Console.WriteLine($"The total number of elements in the jagged array: {total}")
   End Sub
End Module
' The example displays the following output:
'     The value of jagged.Length: 4.
'     Element 1 has 2 elements.
'     Element 2 has 3 elements.
'     Element 3 has 2 elements.
'     Element 4 has 4 elements.
'     The total number of elements in the jagged array: 15

