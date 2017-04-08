' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet1>
Module Example
   Public Sub Main()
      ' Get population data for New York City and Los Angeles, 1960-2000.
      Dim urbanPopulations() =
           { Tuple.Create("New York", 7891957, 7781984, 7894862, 
                          7071639, 7322564, 8008278),
             Tuple.Create("Los Angeles", 1970358, 2479015, 2816061, 
                          2966850, 3485398, 3694820),
             Tuple.Create("New York City", 7891957, 7781984, 7894862, 
                          7071639, 7322564, 8008278),
             Tuple.Create("New York", 7891957, 7781984, 7894862, 
                          7071639, 7322564, 8008278) }
      ' Compare each tuple with every other tuple for equality.
      For ctr As Integer = 0 To urbanPopulations.Length - 2                      
         Dim urbanPopulation = urbanPopulations(ctr)
         Console.WriteLine(urbanPopulation.ToString() + " = ")
         For innerCtr As Integer = ctr + 1 To urbanPopulations.Length - 1
            Console.WriteLine("   {0}: {1}", urbanPopulations(innerCtr), _
                              urbanPopulation.Equals(urbanPopulations(innerCtr)))
         Next
         Console.WriteLine()
      Next
   End Sub
End Module
' The example displays the following output:
'    (New York, 7891957, 7781984, 7894862, 7071639, 7322564, 8008278) =
'       (Los Angeles, 1970358, 2479015, 2816061, 2966850, 3485398, 3694820): False
'       (New York City, 7891957, 7781984, 7894862, 7071639, 7322564, 8008278): False
'       (New York, 7891957, 7781984, 7894862, 7071639, 7322564, 8008278): True
'    
'    (Los Angeles, 1970358, 2479015, 2816061, 2966850, 3485398, 3694820) =
'       (New York City, 7891957, 7781984, 7894862, 7071639, 7322564, 8008278): False
'       (New York, 7891957, 7781984, 7894862, 7071639, 7322564, 8008278): False
'    
'    (New York City, 7891957, 7781984, 7894862, 7071639, 7322564, 8008278) =
'       (New York, 7891957, 7781984, 7894862, 7071639, 7322564, 8008278): False
' </Snippet1>
