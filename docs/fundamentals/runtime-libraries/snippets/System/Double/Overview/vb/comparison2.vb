' Visual Basic .NET Document
Option Strict On

' <Snippet10> 
Module Example2
    Public Sub Main()
        Dim value1 As Double = 100.10142
        value1 = Math.Sqrt(Math.Pow(value1, 2))
        Dim value2 As Double = Math.Pow(value1 * 3.51, 2)
        value2 = Math.Sqrt(value2) / 3.51
        Console.WriteLine("{0} = {1}: {2}",
                        value1, value2, value1.Equals(value2))
        Console.WriteLine()
        Console.WriteLine("{0:R} = {1:R}", value1, value2)
    End Sub
End Module
' The example displays the following output:
'    100.10142 = 100.10142: False
'    
'    100.10142 = 100.10141999999999
' </Snippet10>
