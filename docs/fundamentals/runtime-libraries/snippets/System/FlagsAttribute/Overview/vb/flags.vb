' <Snippet1>
Module Example
   ' Define an Enum without FlagsAttribute.
   Enum SingleHue As Short
      None = 0
      Black = 1
      Red = 2
      Green = 4
      Blue = 8
   End Enum

   ' Define an Enum with FlagsAttribute.
   <Flags()> 
   Enum MultiHue As Short
      None = 0
      Black = 1
      Red = 2
      Green = 4
      Blue = 8
   End Enum

   Sub Main()
      ' Display all possible combinations of values.
      Console.WriteLine(
           "All possible combinations of values without FlagsAttribute:")
      For val As Integer = 0 To 16
         Console.WriteLine("{0,3} - {1:G}", val, CType(val, SingleHue))
     Next 
     Console.WriteLine()
     
     ' Display all combinations of values, and invalid values.
     Console.WriteLine( 
          "All possible combinations of values with FlagsAttribute:")
     For val As Integer = 0 To 16
        Console.WriteLine( "{0,3} - {1:G}", val, CType(val, MultiHue))
     Next 
   End Sub 
End Module 
' The example displays the following output:
'       All possible combinations of values without FlagsAttribute:
'         0 - None
'         1 - Black
'         2 - Red
'         3 - 3
'         4 - Green
'         5 - 5
'         6 - 6
'         7 - 7
'         8 - Blue
'         9 - 9
'        10 - 10
'        11 - 11
'        12 - 12
'        13 - 13
'        14 - 14
'        15 - 15
'        16 - 16
'       
'       All possible combinations of values with FlagsAttribute:
'         0 - None
'         1 - Black
'         2 - Red
'         3 - Black, Red
'         4 - Green
'         5 - Black, Green
'         6 - Red, Green
'         7 - Black, Red, Green
'         8 - Blue
'         9 - Black, Blue
'        10 - Red, Blue
'        11 - Black, Red, Blue
'        12 - Green, Blue
'        13 - Black, Green, Blue
'        14 - Red, Green, Blue
'        15 - Black, Red, Green, Blue
'        16 - 16
'</Snippet1>