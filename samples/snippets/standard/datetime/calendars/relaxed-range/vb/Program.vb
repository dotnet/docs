Imports System.Globalization

Public Module Example
    Dim jaJp As CultureInfo
    Dim cal As Calendar

    Public Sub Main()
        jaJp = New CultureInfo("ja-JP")
        cal = New JapaneseCalendar()
        jaJp.DateTimeFormat.Calendar = cal
        Dim showaEra = "昭和"

        Dim dt = cal.ToDateTime(65, 1, 9, 15, 0, 0, 0, GetEraIndex(showaEra))
        Dim fmt As FormattableString = $"{dt:d}"
        Console.WriteLine($"Japanese calendar date: {fmt.ToString(jaJp)}")
        Console.WriteLine($"Gregorian calendar date: {fmt}")
    End Sub

    Private Function GetEraIndex(eraName As String) As Integer
        For Each ctr As Integer In cal.Eras
            If jaJp.DateTimeFormat.GetEraName(ctr) = eraName Then Return ctr
        Next
        Return 0
    End Function
End Module
' The example displays the following output:
'   Japanese calendar date: 平成2/1/9
'   Gregorian calendar date: 1/9/1990
