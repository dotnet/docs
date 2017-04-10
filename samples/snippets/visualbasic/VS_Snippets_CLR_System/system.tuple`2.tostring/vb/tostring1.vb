' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet1>
Module modMain
   Public Sub Main()
      Dim scores() As Tuple(Of String, Nullable(Of Integer)) = 
                      { New Tuple(Of String, Nullable(Of Integer))("Abbey", 92), 
                        New Tuple(Of String, Nullable(Of Integer))("Dave", 88),
                        New Tuple(Of String, Nullable(Of Integer))("Ed", Nothing),                        New Tuple(Of String, Nullable(Of Integer))("Jack", 78),
                        New Tuple(Of String, Nullable(Of Integer))("Linda", 99),
                        New Tuple(Of String, Nullable(Of Integer))("Judith", 84), 
                        New Tuple(Of String, Nullable(Of Integer))("Penelope", 82),
                        New Tuple(Of String, Nullable(Of Integer))("Sam", 91) } 
      For Each score In scores
         Console.WriteLine(score.ToString())
      Next                        
   End Sub
End Module
' The example displays the following output:
'       (Abbey, 92)
'       (Dave, 88)
'       (Ed, )
'       (Jack, 78)
'       (Linda, 99)
'       (Judith, 84)
'       (Penelope, 82)
'       (Sam, 91)
' </Snippet1>
