' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet1>
Module Example
   Public Sub Main()
      ' Get population data for New York City, 1960-2000.
      Dim population = Tuple.Create("New York", 7781984, 7894862, 
                                    7071639, 7322564, 8008278)
      Console.WriteLine(population.ToString())                                 
   End Sub
End Module
' The example displays the following output:
'       (New York, 7781984, 7894862, 7071639, 7322564, 8008278)
' </Snippet1>
