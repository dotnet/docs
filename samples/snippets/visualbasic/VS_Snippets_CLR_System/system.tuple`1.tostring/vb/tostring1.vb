' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim tuple1Double = Tuple.Create(3.456e-18)
      DisplayTuple(tuple1Double)
      
      Dim tuple1String = Tuple.Create("Australia")
      DisplayTuple(tuple1String)
      
      Dim tuple1Bool = Tuple.Create(True)
      DisplayTuple(tuple1Bool)
      
      Dim tuple1Char = Tuple.Create("a"c)
      DisplayTuple(tuple1Char)
   End Sub
   
   Private Sub DisplayTuple(obj As Object)
      Console.WriteLine(obj.ToString())
   End Sub
End Module
' The example displays the following output:
'       (3.456E-18)
'       (Australia)
'       (True)
'       (a)
' </Snippet1>
