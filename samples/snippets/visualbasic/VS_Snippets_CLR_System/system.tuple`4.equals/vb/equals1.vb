' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim temperatures() = 
              { Tuple.Create(#1/16/2009#, 3, 5, 4), _
                Tuple.Create(#4/22/2009#, 9, 14, 11), _ 
                Tuple.Create(#4/22/2009#, 9, 14, 10), _
                Tuple.Create(#6/01/2009#, 23, 28, 21), _
                Tuple.Create(#4/22/2009#, 9, 14, 11), _
                Tuple.Create(#9/06/2009#, 25, 30, 25) } 
      ' Compare each item with every other item for equality.
      For ctr As Integer = 0 To temperatures.Length - 1
         Dim temperatureInfo = temperatures(ctr)
         For ctr2 As Integer = ctr + 1 To temperatures.Length - 1
            Console.WriteLine("{0} = {1}: {2}", temperatureInfo, temperatures(ctr2), 
                                                temperatureInfo.Equals(temperatures(ctr2)))
         Next  
         Console.WriteLine()                                               
      Next
   End Sub
End Module
' The example displays the following output:
'    (1/16/2009 12:00:00 AM, 3, 5, 4) = (4/22/2009 12:00:00 AM, 9, 14, 11): False
'    (1/16/2009 12:00:00 AM, 3, 5, 4) = (4/22/2009 12:00:00 AM, 9, 14, 10): False
'    (1/16/2009 12:00:00 AM, 3, 5, 4) = (6/1/2009 12:00:00 AM, 23, 28, 21): False
'    (1/16/2009 12:00:00 AM, 3, 5, 4) = (4/22/2009 12:00:00 AM, 9, 14, 11): False
'    (1/16/2009 12:00:00 AM, 3, 5, 4) = (9/6/2009 12:00:00 AM, 25, 30, 25): False
'    
'    (4/22/2009 12:00:00 AM, 9, 14, 11) = (4/22/2009 12:00:00 AM, 9, 14, 10): False
'    (4/22/2009 12:00:00 AM, 9, 14, 11) = (6/1/2009 12:00:00 AM, 23, 28, 21): False
'    (4/22/2009 12:00:00 AM, 9, 14, 11) = (4/22/2009 12:00:00 AM, 9, 14, 11): True
'    (4/22/2009 12:00:00 AM, 9, 14, 11) = (9/6/2009 12:00:00 AM, 25, 30, 25): False
'    
'    (4/22/2009 12:00:00 AM, 9, 14, 10) = (6/1/2009 12:00:00 AM, 23, 28, 21): False
'    (4/22/2009 12:00:00 AM, 9, 14, 10) = (4/22/2009 12:00:00 AM, 9, 14, 11): False
'    (4/22/2009 12:00:00 AM, 9, 14, 10) = (9/6/2009 12:00:00 AM, 25, 30, 25): False
'    
'    (6/1/2009 12:00:00 AM, 23, 28, 21) = (4/22/2009 12:00:00 AM, 9, 14, 11): False
'    (6/1/2009 12:00:00 AM, 23, 28, 21) = (9/6/2009 12:00:00 AM, 25, 30, 25): False
'    
'    (4/22/2009 12:00:00 AM, 9, 14, 11) = (9/6/2009 12:00:00 AM, 25, 30, 25): False
' </Snippet1>
