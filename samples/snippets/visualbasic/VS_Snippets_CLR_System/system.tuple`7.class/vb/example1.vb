' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet1>
Module Example
   Public Sub Main()
      ' Get population data for New York City, 1950-2000.
      Dim population = Tuple.Create("New York", 7891957, 7781984, 
                                    7894862, 7071639, 7322564, 8008278)
      Dim rate = ComputePopulationChange(population)      
      ' Display results.
      Console.WriteLine("Population Change, {0}, 1950-2000", population.Item1)
      Console.WriteLine()
      Console.WriteLine("Year      {0,10} {1,9}", "Population", "Annual Rate")
      Console.WriteLine("1950      {0,10:N0} {1,11}", population.Item2, "NA")
      Console.WriteLine("1960      {0,10:N0} {1,11:P2}", population.Item3, rate.Item2/10)
      Console.WriteLine("1970      {0,10:N0} {1,11:P2}", population.Item4, rate.Item3/10)
      Console.WriteLine("1980      {0,10:N0} {1,11:P2}", population.Item5, rate.Item4/10)
      Console.WriteLine("1990      {0,10:N0} {1,11:P2}", population.Item6, rate.Item5/10)
      Console.WriteLine("2000      {0,10:N0} {1,11:P2}", population.Item7, rate.Item6/10)
      Console.WriteLine("1950-2000 {0,10:N0} {1,11:P2}", "", rate.Item7/50)
   End Sub
   
      ' Compute rate of population change by decade and overall.
   Private Function ComputePopulationChange(data As Tuple(Of String, Integer, Integer, Integer, Integer, Integer, Integer)) _ 
           As Tuple(Of String, Double, Double, Double, Double, Double, Double)
      Dim rate = Tuple.Create( data.Item1, 
                       (data.Item3 - data.Item2)/data.Item2, 
                       (data.Item4 - data.Item3)/data.Item3, 
                       (data.Item5 - data.Item4)/data.Item4, 
                       (data.Item6 - data.Item5)/data.Item5,
                       (data.Item7 - data.Item6)/data.Item6,
                       (data.Item7 - data.Item2)/data.Item2 )
      Return rate
   End Function           
End Module
' The example displays the following output:
'       Population Change, New York, 1950-2000
'       
'       Year      Population Annual Rate
'       1950       7,891,957          NA
'       1960       7,781,984     -0.14 %
'       1970       7,894,862      0.15 %
'       1980       7,071,639     -1.04 %
'       1990       7,322,564      0.35 %
'       2000       8,008,278      0.94 %
'       1950-2000                 0.03 %
' </Snippet1>
