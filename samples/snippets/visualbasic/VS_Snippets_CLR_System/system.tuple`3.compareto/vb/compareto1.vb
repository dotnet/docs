' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim scores() = 
                 { Tuple.Create("Jack", 78.8, 8),
                   Tuple.Create("Abbey", 92.1, 9), 
                   Tuple.Create("Dave", 88.3, 9),
                   Tuple.Create("Sam", 91.7, 8), 
                   Tuple.Create("Ed", 71.2, 5),
                   Tuple.Create("Penelope", 82.9, 8),
                   Tuple.Create("Linda", 99.0, 9),
                   Tuple.Create("Judith", 84.3, 9) }

      Console.WriteLine("The values in unsorted order:")
      For Each score In scores
         Console.WriteLine(score.ToString())
      Next
      Console.WriteLine()

      Array.Sort(scores)

      Console.WriteLine("The values in sorted order:")
      For Each score In scores
         Console.WriteLine(score.ToString())
      Next
   End Sub
End Module
' The example displays the following output;
'    The values in unsorted order:
'    (Jack, 78.8, 8)
'    (Abbey, 92.1, 9)
'    (Dave, 88.3, 9)
'    (Sam, 91.7, 8)
'    (Ed, 71.2, 5)
'    (Penelope, 82.9, 8)
'    (Linda, 99, 9)
'    (Judith, 84.3, 9)
'    
'    The values in sorted order:
'    (Abbey, 92.1, 9)
'    (Dave, 88.3, 9)
'    (Ed, 71.2, 5)
'    (Jack, 78.8, 8)
'    (Judith, 84.3, 9)
'    (Linda, 99, 9)
'    (Penelope, 82.9, 8)
'    (Sam, 91.7, 8)
' </Snippet1>
