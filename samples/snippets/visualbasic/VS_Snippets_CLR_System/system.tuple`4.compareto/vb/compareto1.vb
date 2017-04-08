' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet1>
Imports System.Collections.Generic

Module Example
   Public Sub Main()
      Dim pitchers() =  
                { Tuple.Create("McHale, Joe", 240.1d, 221, 96),
                  Tuple.Create("Paul, Dave", 233.1d, 231, 84), 
                  Tuple.Create("Williams, Mike", 193.2d, 183, 86),
                  Tuple.Create("Blair, Jack", 168.1d, 146, 65), 
                  Tuple.Create("Henry, Walt", 140.1d, 96, 30),
                  Tuple.Create("Lee, Adam", 137.2d, 109, 45),
                  Tuple.Create("Rohr, Don", 101.0d, 110, 42) }

      ' Display the array in unsorted order.
      Console.WriteLine("The values in unsorted order:")
      For Each pitcher In pitchers
         Console.WriteLine(pitcher.ToString())
      Next
      Console.WriteLine()
      
      ' Sort the array
      Array.Sort(pitchers)
      
      ' Display the array in sorted order.
      Console.WriteLine("The values in sorted order:")
      For Each pitcher In pitchers
         Console.WriteLine(pitcher.ToString())
      Next
   End Sub
End Module
' The example displays the following output:
'       The values in unsorted order:
'       (McHale, Joe, 240.1, 221, 96)
'       (Paul, Dave, 233.1, 231, 84)
'       (Williams, Mike, 193.2, 183, 86)
'       (Blair, Jack, 168.1, 146, 65)
'       (Henry, Walt, 140.1, 96, 30)
'       (Lee, Adam, 137.2, 109, 45)
'       (Rohr, Don, 101, 110, 42)
'       
'       The values in sorted order:
'       (Blair, Jack, 168.1, 146, 65)
'       (Henry, Walt, 140.1, 96, 30)
'       (Lee, Adam, 137.2, 109, 45)
'       (McHale, Joe, 240.1, 221, 96)
'       (Paul, Dave, 233.1, 231, 84)
'       (Rohr, Don, 101, 110, 42)
'       (Williams, Mike, 193.2, 183, 86)
' </Snippet1>
