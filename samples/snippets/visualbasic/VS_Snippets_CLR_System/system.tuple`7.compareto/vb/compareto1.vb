' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet1>
Module Example
   Public Sub Main()
      ' Create array of sextuple with population data for three U.S. 
      ' cities, 1950-2000.
      Dim cities() = _
          { Tuple.Create("Los Angeles", 1970358, 2479015, 2816061, 2966850, 3485398, 3694820),
            Tuple.Create("New York", 7891957, 7781984, 7894862, 7071639, 7322564, 8008278),  
            Tuple.Create("Chicago", 3620962, 3550904, 3366957, 3005072, 2783726, 2896016) } 
      
      ' Display array in unsorted order.
      Console.WriteLine("In unsorted order:")
      For Each city In cities
         Console.WriteLine(city.ToString())
      Next
      Console.WriteLine()
      
      Array.Sort(cities) 
                           
      ' Display array in sorted order.
      Console.WriteLine("In sorted order:")
      For Each city In cities
         Console.WriteLine(city.ToString())
      Next
   End Sub
End Module
' The example displays the following output:
'    In unsorted order:
'    (Los Angeles, 1970358, 2479015, 2816061, 2966850, 3485398, 3694820)
'    (New York, 7891957, 7781984, 7894862, 7071639, 7322564, 8008278)
'    (Chicago, 3620962, 3550904, 3366957, 3005072, 2783726, 2896016)
'    
'    In sorted order:
'    (Chicago, 3620962, 3550904, 3366957, 3005072, 2783726, 2896016)
'    (Los Angeles, 1970358, 2479015, 2816061, 2966850, 3485398, 3694820)
'    (New York, 7891957, 7781984, 7894862, 7071639, 7322564, 8008278)
' </Snippet1>
