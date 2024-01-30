' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example2
   Public Sub Main()
       Dim value1 As Double = 6.185
       Dim value2 As Object = value1 * .1 / .1
       Console.WriteLine("Comparing {0} and {1}: {2}",
                         value1, value2, value1.CompareTo(value2))
       Console.WriteLine()
       Console.WriteLine("Comparing {0:R} and {1:R}: {2}",
                         value1, value2, value1.CompareTo(value2))
   End Sub
End Module
' The example displays the following output:
'       Comparing 6.185 and 6.185: -1
'       
'       Comparing 6.185 and 6.1850000000000005: -1
' </Snippet2>

