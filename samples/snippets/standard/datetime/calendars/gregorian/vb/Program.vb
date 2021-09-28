Imports System.Globalization

Public Module Example
    Public Sub Main()
        Dim japaneseCal = New JapaneseCalendar()
        Dim jaJp = New CultureInfo("ja-JP")
        jaJp.DateTimeFormat.Calendar = japaneseCal

        Dim dat = New DateTime(1905, 2, 12)
        Console.WriteLine($"Gregorian calendar date: {dat:d}")

        ' Call the ToString(IFormatProvider) method.
        Console.WriteLine($"Japanese calendar date: {dat.ToString("d", jaJp)}")

        ' Use a FormattableString object.
        Dim fmt As FormattableString = $"{dat:d}"
        Console.WriteLine($"Japanese calendar date: {fmt.ToString(jaJp)}")

        ' Use the JapaneseCalendar object.
        Console.WriteLine($"Japanese calendar date: {jaJp.DateTimeFormat.GetEraName(japaneseCal.GetEra(dat))}" +
                          $"{japaneseCal.GetYear(dat)}/{japaneseCal.GetMonth(dat)}/{japaneseCal.GetDayOfMonth(dat)}")

        ' Use the current culture.
        CultureInfo.CurrentCulture = jaJp
        Console.WriteLine($"Japanese calendar date: {dat:d}")
    End Sub
End Module
' The example displays the following output:
'   Gregorian calendar date: 2/12/1905
'   Japanese calendar date: 明治38/2/12
'   Japanese calendar date: 明治38/2/12
'   Japanese calendar date: 明治38/2/12
'   Japanese calendar date: 明治38/2/12


