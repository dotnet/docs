' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim scores() = 
              { Tuple.Create("Ed", 78.8, 8),
                Tuple.Create("Abbey", 92.1, 9), 
                Tuple.Create("Ed", 71.2, 9),
                Tuple.Create("Sam", 91.7, 8), 
                Tuple.Create("Ed", 71.2, 5),
                Tuple.Create("Penelope", 82.9, 8),
                Tuple.Create("Ed", 71.2, 9),
                Tuple.Create("Judith", 84.3, 9) }

      ' Test each tuple object for equality with every other tuple.
      For ctr As Integer = 0 To scores.Length - 1
         Dim currentTuple = scores(ctr)
         For ctr2 As Integer = ctr + 1 To scores.Length - 1
            Console.WriteLine("{0} = {1}: {2}", currentTuple, scores(ctr2), 
                                                currentTuple.Equals(scores(ctr2)))      
         Next
         Console.WriteLine()
      Next
   End Sub
End Module
' The example displays the following output;
'    (Ed, 78.8, 8) = (Abbey, 92.1, 9): False
'    (Ed, 78.8, 8) = (Ed, 71.2, 9): False
'    (Ed, 78.8, 8) = (Sam, 91.7, 8): False
'    (Ed, 78.8, 8) = (Ed, 71.2, 5): False
'    (Ed, 78.8, 8) = (Penelope, 82.9, 8): False
'    (Ed, 78.8, 8) = (Ed, 71.2, 9): False
'    (Ed, 78.8, 8) = (Judith, 84.3, 9): False
'    
'    (Abbey, 92.1, 9) = (Ed, 71.2, 9): False
'    (Abbey, 92.1, 9) = (Sam, 91.7, 8): False
'    (Abbey, 92.1, 9) = (Ed, 71.2, 5): False
'    (Abbey, 92.1, 9) = (Penelope, 82.9, 8): False
'    (Abbey, 92.1, 9) = (Ed, 71.2, 9): False
'    (Abbey, 92.1, 9) = (Judith, 84.3, 9): False
'    
'    (Ed, 71.2, 9) = (Sam, 91.7, 8): False
'    (Ed, 71.2, 9) = (Ed, 71.2, 5): False
'    (Ed, 71.2, 9) = (Penelope, 82.9, 8): False
'    (Ed, 71.2, 9) = (Ed, 71.2, 9): True
'    (Ed, 71.2, 9) = (Judith, 84.3, 9): False
'    
'    (Sam, 91.7, 8) = (Ed, 71.2, 5): False
'    (Sam, 91.7, 8) = (Penelope, 82.9, 8): False
'    (Sam, 91.7, 8) = (Ed, 71.2, 9): False
'    (Sam, 91.7, 8) = (Judith, 84.3, 9): False
'    
'    (Ed, 71.2, 5) = (Penelope, 82.9, 8): False
'    (Ed, 71.2, 5) = (Ed, 71.2, 9): False
'    (Ed, 71.2, 5) = (Judith, 84.3, 9): False
'    
'    (Penelope, 82.9, 8) = (Ed, 71.2, 9): False
'    (Penelope, 82.9, 8) = (Judith, 84.3, 9): False
'    
'    (Ed, 71.2, 9) = (Judith, 84.3, 9): False
' </Snippet1>
