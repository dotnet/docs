' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet1>
Module Example
   Public Sub Main()
      ' Create tuples containing population data for New York, Chicago, 
      ' and Los Angeles, 1960-2000.
      Dim cities() =
           { Tuple.Create("New York", 7781984, 7894862, 
                          7071639, 7322564, 8008278),
             Tuple.Create("Los Angeles", 2479015, 2816061, 
                          2966850, 3485398, 3694820),
             Tuple.Create("Chicago", 3550904, 3366957, 
                          3005072, 2783726, 2896016) }

      ' Display tuple data in table.
      Dim header As String = "Population in"
      Console.WriteLine("{0,-12} {1,60}", 
                        "City", New String("-"c,(60-header.Length)\2) + header + _
                                New String("-"c, (60-header.Length)\2))
      Console.WriteLine("{0,25}{1,12}{2,12}{3,12}{4,12}", 
                        "1960", "1970", "1980", "1990", "2000")                  
      Console.WriteLine()
      For Each city In cities                      
         Console.WriteLine("{0,-12} {1,12:N0}{2,12:N0}{3,12:N0}{4,12:N0}{5,12:N0}", 
                           city.Item1, city.Item2, city.Item3, city.Item4, 
                           city.Item5, city.Item6)
      Next
   End Sub
End Module
' The example displays the following output:
'    City          -----------------------Population in-----------------------
'                         1960        1970        1980        1990        2000
'    
'    New York        7,781,984   7,894,862   7,071,639   7,322,564   8,008,278
'    Los Angeles     2,479,015   2,816,061   2,966,850   3,485,398   3,694,820
'    Chicago         3,550,904   3,366,957   3,005,072   2,783,726   2,896,016
' </Snippet1>
