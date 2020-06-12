Imports System.Numerics

Module Example
    Public Sub Main()
        Dim value = BigInteger.Pow(Int64.MaxValue, 2)
        Console.WriteLine(value.ToString("R"))
    End Sub
End Module
' The example displays the following output:
'      85070591730234615847396907784232501249  
