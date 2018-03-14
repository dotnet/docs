' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim temperatures() = 
             { Tuple.Create("New York, NY", 4, 61, 43), _
               Tuple.Create("Chicago, IL", 2, 34, 18), _ 
               Tuple.Create("Newark, NJ", 4, 61, 43), _
               Tuple.Create("Boston, MA", 6, 77, 59), _
               Tuple.Create("Detroit, MI", 9, 74, 53), _
               Tuple.Create("Minneapolis, MN", 8, 81, 61) } 
      ' Display the array of 4-tuple objects.
      For Each temperature In temperatures
         Console.WriteLine(temperature.ToString())
      Next
   End Sub
End Module
' The example displays the following output:
'       (New York, NY, 4, 61, 43)
'       (Chicago, IL, 2, 34, 18)
'       (Newark, NJ, 4, 61, 43)
'       (Boston, MA, 6, 77, 59)
'       (Detroit, MI, 9, 74, 53)
'       (Minneapolis, MN, 8, 81, 61)
' </Snippet1>
