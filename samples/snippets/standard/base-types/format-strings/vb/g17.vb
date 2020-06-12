Module Example
    Public Sub Main()
        Dim original As Double = 0.84551240822557006
        Dim rSpecifier = original.ToString("R")
        Dim g17Specifier = original.ToString("G17")

        Dim rValue = Double.Parse(rSpecifier)
        Dim g17Value = Double.Parse(g17Specifier)

        Console.WriteLine($"{original:G17} = {rSpecifier} (R): {original.Equals(rValue)}")
        Console.WriteLine($"{original:G17} = {g17Specifier} (G17): {original.Equals(g17Value)}")
    End Sub
End Module
' The example displays the following output:
'     0.84551240822557006 = 0.84551240822557 (R): False
'     0.84551240822557006 = 0.84551240822557006 (G17): True
