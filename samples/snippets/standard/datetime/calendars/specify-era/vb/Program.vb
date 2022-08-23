Imports System.Globalization

Public Module Example
    Public Sub Main()
        Dim japaneseCal = New JapaneseCalendar()
        Dim jaJp = New CultureInfo("ja-JP")
        jaJp.DateTimeFormat.Calendar = japaneseCal

        ' We can get the era index by calling DateTimeFormatInfo.GetEraName.
        Dim eraIndex As Integer = 0

        For ctr As Integer = 0 To jaJp.DateTimeFormat.Calendar.Eras.Length - 1
            If jaJp.DateTimeFormat.GetEraName(ctr) = "明治" Then eraIndex = ctr
        Next
        Dim date1 = japaneseCal.ToDateTime(23, 9, 8, 0, 0, 0, 0, eraIndex)
        Console.WriteLine($"{date1.ToString("d", jaJp)} (Gregorian {date1:d})")

        Try
            Dim date2 = DateTime.Parse("明治23/9/8", jaJp)
            Console.WriteLine($"{date2.ToString("d", jaJp)} (Gregorian {date2:d})")
        Catch e As FormatException
            Console.WriteLine("The parsing operation failed.")
        End Try

        Try
            Dim date3 = DateTime.ParseExact("明治23/9/8", "gyy/M/d", jaJp)
            Console.WriteLine($"{date3.ToString("d", jaJp)} (Gregorian {date3:d})")
        Catch e As FormatException
            Console.WriteLine("The parsing operation failed.")
        End Try
    End Sub
End Module
' The example displays the following output:
'   明治23/9/8 (Gregorian 9/8/1890)
'   明治23/9/8 (Gregorian 9/8/1890)
'   明治23/9/8 (Gregorian 9/8/1890)
