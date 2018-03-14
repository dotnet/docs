' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim temperatureInfos() = 
             { Tuple.Create(2, 97.9, 97.8, 98.0, 98.2), 
               Tuple.Create(1, 98.6, 98.8, 98.8, 99.0),  
               Tuple.Create(2, 98.6, 98.6, 98.6, 98.4), 
               Tuple.Create(1, 98.4, 98.6, 99.0, 99.2), 
               Tuple.Create(2, 98.6, 98.6, 98.6, 98.4), 
               Tuple.Create(1, 98.6, 98.8, 98.8, 99.0) } 
      ' Compare each item with every other item for equality.
      For ctr As Integer = 0 To temperatureInfos.Length - 1
         Dim temperatureInfo = temperatureInfos(ctr)
         For ctr2 As Integer = ctr + 1 To temperatureInfos.Length - 1
            Console.WriteLine("{0} = {1}: {2}", temperatureInfo, temperatureInfos(ctr2), 
                                                temperatureInfo.Equals(temperatureInfos(ctr2)))
         Next  
         Console.WriteLine()                                               
      Next
   End Sub
End Module
' The example displays the following output:
'    (2, 97.9, 97.8, 98, 98.2) = (1, 98.6, 98.8, 98.8, 99): False
'    (2, 97.9, 97.8, 98, 98.2) = (2, 98.6, 98.6, 98.6, 98.4): False
'    (2, 97.9, 97.8, 98, 98.2) = (1, 98.4, 98.6, 99, 99.2): False
'    (2, 97.9, 97.8, 98, 98.2) = (2, 98.6, 98.6, 98.6, 98.4): False
'    (2, 97.9, 97.8, 98, 98.2) = (1, 98.6, 98.8, 98.8, 99): False
'    
'    (1, 98.6, 98.8, 98.8, 99) = (2, 98.6, 98.6, 98.6, 98.4): False
'    (1, 98.6, 98.8, 98.8, 99) = (1, 98.4, 98.6, 99, 99.2): False
'    (1, 98.6, 98.8, 98.8, 99) = (2, 98.6, 98.6, 98.6, 98.4): False
'    (1, 98.6, 98.8, 98.8, 99) = (1, 98.6, 98.8, 98.8, 99): True
'    
'    (2, 98.6, 98.6, 98.6, 98.4) = (1, 98.4, 98.6, 99, 99.2): False
'    (2, 98.6, 98.6, 98.6, 98.4) = (2, 98.6, 98.6, 98.6, 98.4): True
'    (2, 98.6, 98.6, 98.6, 98.4) = (1, 98.6, 98.8, 98.8, 99): False
'    
'    (1, 98.4, 98.6, 99, 99.2) = (2, 98.6, 98.6, 98.6, 98.4): False
'    (1, 98.4, 98.6, 99, 99.2) = (1, 98.6, 98.8, 98.8, 99): False
'    
'    (2, 98.6, 98.6, 98.6, 98.4) = (1, 98.6, 98.8, 98.8, 99): False
' </Snippet1>
