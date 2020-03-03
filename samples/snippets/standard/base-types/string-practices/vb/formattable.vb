Imports System.Globalization

Module Program
    Sub Main()
        Dim value As Decimal = 126.03
        Dim amount As FormattableString = $"The amount is {value:C}" 
        Console.WriteLine(amount.ToString())
        Console.WriteLine(amount.ToString(new CultureInfo("fr-FR")))
        Console.WriteLine(FormattableString.Invariant(amount))
    End Sub
End Module
' The example displays the following output:
'    The amount is $126.03
'    The amount is 126,03 €
'    The amount is ¤126.03
