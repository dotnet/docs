' Visual Basic .NET Document
Option Strict On

Module Example2
    Public Sub Main()
        ' <Snippet10>
        Dim value1 As Single = 10.201438
        value1 = CSng(Math.Sqrt(CSng(Math.Pow(value1, 2))))
        Dim value2 As Single = CSng(Math.Pow(value1 * CSng(3.51), 2))
        value2 = CSng(Math.Sqrt(value2) / CSng(3.51))
        Console.WriteLine("{0} = {1}: {2}",
                        value1, value2, value1.Equals(value2))

        ' The example displays the following output on .NET:
        '       10.201438 = 10.201439: False
        ' The example displays the following output on .NET Framework:
        '       10.20144 = 10.20144: False
        ' </Snippet10>
    End Sub
End Module
