' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      Ctor1()
      Factory()
   End Sub
   
   Private Sub Ctor1()
      ' <Snippet1>
      ' Create a 7-tuple.
      Dim population As New Tuple(Of String, Integer, Integer, Integer, Integer, Integer, Integer) _
                                 ("New York", 7891957, 7781984, 7894862, 7071639, 7322564, 8008278)
      ' Display the first and last elements.
      Console.WriteLine("Population of {0} in 2000: {1:N0}",
                        population.Item1, population.Item7)
      ' The example displays the following output:
      '        Population of New York in 2000: 8,008,278
      ' </Snippet1>
   End Sub
   
   Private Sub Factory()
      ' <Snippet2>
      ' Create a 7-tuple.
      Dim population = Tuple.Create("New York", 7891957, 7781984, 7894862, 7071639, 7322564, 8008278)
      ' Display the first and last elements.
      Console.WriteLine("Population of {0} in 2000: {1:N0}",
                        population.Item1, population.Item7)
      ' The example displays the following output:
      '        Population of New York in 2000: 8,008,278
      ' </Snippet2>
   End Sub
End Module

