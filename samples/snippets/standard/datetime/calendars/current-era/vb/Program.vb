Imports System.Globalization

Public Module Example
    Public Sub Main()
        Dim japaneseCal = New JapaneseCalendar()
        Dim jaJp = New CultureInfo("ja-JP")
        jaJp.DateTimeFormat.Calendar = japaneseCal

        Dim dat = New DateTime(2, 1, 1, japaneseCal)
        Console.WriteLine($"Gregorian calendar dat: {dat:d}")
        Console.WriteLine($"Japanese calendar dat: {dat.ToString("d", jaJp)}")
    End Sub
End Module
