' <Snippet17>
Imports System.Globalization
Imports System.Text.Json
Imports System.Threading

Friend Structure CurrencyValue
    Public Property Amount As Decimal
    Public Property CultureName As String
End Structure

Module Example2
    Public Sub Main2()
        ' Display the currency value.
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US")
        Dim value As Decimal = 16039.47D
        Console.WriteLine("Current Culture: {0}", CultureInfo.CurrentCulture.DisplayName)
        Console.WriteLine("Currency Value: {0:C2}", value)

        ' Serialize the currency data.
        Dim data As New CurrencyValue With {
            .Amount = value,
            .CultureName = CultureInfo.CurrentCulture.Name
        }

        Dim serialized As String = JsonSerializer.Serialize(data)
        Console.WriteLine()

        ' Change the current culture.
        CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB")
        Console.WriteLine("Current Culture: {0}", CultureInfo.CurrentCulture.DisplayName)

        ' Deserialize the data.
        Dim restoredData As CurrencyValue = JsonSerializer.Deserialize(Of CurrencyValue)(serialized)

        ' Display the round-tripped value.
        Dim culture As CultureInfo = CultureInfo.CreateSpecificCulture(restoredData.CultureName)
        Console.WriteLine("Currency Value: {0}", restoredData.Amount.ToString("C2", culture))
    End Sub
End Module

' The example displays the following output:
'       Current Culture: English (United States)
'       Currency Value: $16,039.47
'       
'       Current Culture: English (United Kingdom)
'       Currency Value: $16,039.47
' </Snippet17>
