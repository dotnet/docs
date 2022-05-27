' Visual Basic .NET Document
Option Strict On

' <Snippet17>
Imports System.Globalization
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Threading

<Serializable> Friend Structure CurrencyValue
    Public Sub New(amount As Decimal, name As String)
        Me.Amount = amount
        Me.CultureName = name
    End Sub

    Public Amount As Decimal
    Public CultureName As String
End Structure

Module Example2
    Public Sub Main2()
        ' Display the currency value.
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US")
        Dim value As Decimal = 16039.47D
        Console.WriteLine("Current Culture: {0}", CultureInfo.CurrentCulture.DisplayName)
        Console.WriteLine("Currency Value: {0:C2}", value)

        ' Serialize the currency data.
        Dim bf As New BinaryFormatter()
        Dim fw As New FileStream("currency.dat", FileMode.Create)
        Dim data As New CurrencyValue(value, CultureInfo.CurrentCulture.Name)
        bf.Serialize(fw, data)
        fw.Close()
        Console.WriteLine()

        ' Change the current culture.
        CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB")
        Console.WriteLine("Current Culture: {0}", CultureInfo.CurrentCulture.DisplayName)

        ' Deserialize the data.
        Dim fr As New FileStream("currency.dat", FileMode.Open)
        Dim restoredData As CurrencyValue = CType(bf.Deserialize(fr), CurrencyValue)
        fr.Close()

        ' Display the original value.
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
