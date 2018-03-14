' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Collections.Generic

Module Example
   Public Sub Main()
      ' Organization of runningBacks 5-tuple:
      '    Component 1: Player name
      '    Component 2: Number of games played
      '    Component 3: Number of attempts (carries)
      '    Component 4: Number of yards gained 
      '    Component 5: Number of touchdowns   
      Dim runningBacks() =
          { Tuple.Create("Payton, Walter", 190, 3838, 16726, 110),  
            Tuple.Create("Sanders, Barry", 153, 3062, 15269, 99),            
            Tuple.Create("Brown, Jim", 118, 2359, 12312, 106),            
            Tuple.Create("Dickerson, Eric", 144, 2996, 13259, 90),            
            Tuple.Create("Faulk, Marshall", 176, 2836, 12279, 100) } 

      ' Display the array in unsorted order.
      Console.WriteLine("The values in unsorted order:")
      For Each runningBack In runningBacks
         Console.WriteLine(runningBack.ToString())
      Next
      Console.WriteLine()
      
      ' Sort the array
      Array.Sort(runningBacks)
      
      ' Display the array in sorted order.
      Console.WriteLine("The values in sorted order:")
      For Each runningBack In runningBacks
         Console.WriteLine(runningBack.ToString())
      Next
   End Sub
End Module
' The example displays the following output:
'       The values in unsorted order:
'       (Payton, Walter, 190, 3838, 16726, 110)
'       (Sanders, Barry, 153, 3062, 15269, 99)
'       (Brown, Jim, 118, 2359, 12312, 106)
'       (Dickerson, Eric, 144, 2996, 13259, 90)
'       (Faulk, Marshall, 176, 2836, 12279, 100)
'       
'       The values in sorted order:
'       (Brown, Jim, 118, 2359, 12312, 106)
'       (Dickerson, Eric, 144, 2996, 13259, 90)
'       (Faulk, Marshall, 176, 2836, 12279, 100)
'       (Payton, Walter, 190, 3838, 16726, 110)
'       (Sanders, Barry, 153, 3062, 15269, 99)
' </Snippet1>
