Imports System.Globalization

Module Program
    Dim jaJp As CultureInfo
    Dim japaneseCal As Calendar

    Sub Main()
        Dim enUs = New CultureInfo("en-US")
        japaneseCal = New JapaneseCalendar()
        jaJp = New CultureInfo("ja-JP")
        jaJp.DateTimeFormat.Calendar = japaneseCal
        Dim heiseiEra = "平成"

        Dim dat = japaneseCal.ToDateTime(1, 8, 18, 0, 0, 0, 0, GetEraIndex(heiseiEra))
        Dim fmt As FormattableString = $"{dat:D}"
        Console.WriteLine($"Japanese calendar date: {fmt.ToString(jaJp)} (Gregorian: {fmt.ToString(enUs)})")
    End Sub

    Private Function GetEraIndex(eraName As String) As Integer
        For Each ctr In japaneseCal.Eras
            If jaJp.DateTimeFormat.GetEraName(ctr) = eraName Then
                Return ctr
            End If
        Next
        Return 0
    End Function
End Module
' The example displays the following output:
'    Japanese calendar date: 平成元年8月18日 (Gregorian: Friday, August 18, 1989)
