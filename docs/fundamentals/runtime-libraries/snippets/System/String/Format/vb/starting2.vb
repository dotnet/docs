' Visual Basic .NET Document
Option Strict On

Module Example15
    Public Sub Main()
        ' <Snippet35>
        Dim pricePerOunce As Decimal = 17.36D
        Dim s As String = String.Format("The current price is {0} per ounce.",
                                      pricePerOunce)
        ' Result: The current price is 17.36 per ounce.
        ' </Snippet35>
        Console.WriteLine(s)
        ShowFormatted()
    End Sub

    Private Sub ShowFormatted()
        ' <Snippet36>
        Dim pricePerOunce As Decimal = 17.36D
        Dim s As String = String.Format("The current price is {0:C2} per ounce.",
                                      pricePerOunce)
        ' Result if current culture is en-US:
        '      The current price is $17.36 per ounce.
        ' </Snippet36>
        Console.WriteLine(s)
    End Sub
End Module

