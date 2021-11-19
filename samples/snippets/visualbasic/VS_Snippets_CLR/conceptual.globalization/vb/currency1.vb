' Visual Basic .NET Document
Option Strict On

' <Snippet16>
Imports System.Globalization
Imports System.IO
Imports System.Threading

Module Example1
    Public Sub Main1()
        ' Display the currency value.
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US")
        Dim value As Decimal = 16039.47D
        Console.WriteLine("Current Culture: {0}", CultureInfo.CurrentCulture.DisplayName)
        Console.WriteLine("Currency Value: {0:C2}", value)

        ' Persist the currency value as a string.
        Dim sw As New StreamWriter("currency.dat")
        sw.Write(value.ToString("C2"))
        sw.Close()

        ' Read the persisted data using the current culture.
        Dim sr As New StreamReader("currency.dat")
        Dim currencyData As String = sr.ReadToEnd()
        sr.Close()

        ' Restore and display the data using the conventions of the current culture.
        Dim restoredValue As Decimal
        If Decimal.TryParse(currencyData, restoredValue) Then
            Console.WriteLine(restoredValue.ToString("C2"))
        Else
            Console.WriteLine("ERROR: Unable to parse '{0}'", currencyData)
        End If
        Console.WriteLine()

        ' Restore and display the data using the conventions of the en-GB culture.
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB")
        Console.WriteLine("Current Culture: {0}",
                          Thread.CurrentThread.CurrentCulture.DisplayName)
        If Decimal.TryParse(currencyData, NumberStyles.Currency, Nothing, restoredValue) Then
            Console.WriteLine(restoredValue.ToString("C2"))
        Else
            Console.WriteLine("ERROR: Unable to parse '{0}'", currencyData)
        End If
        Console.WriteLine()
    End Sub
End Module
' The example displays output like the following:
'       Current Culture: English (United States)
'       Currency Value: $16,039.47
'       ERROR: Unable to parse '$16,039.47'
'       
'       Current Culture: English (United Kingdom)
'       ERROR: Unable to parse '$16,039.47'
' </Snippet16>
