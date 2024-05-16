' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Imports System.Globalization
Imports System.Threading

Module Example14
    Public Sub Main14()
        Dim dateForMonth As Date = #1/1/2013#
        Dim temperatures() As Double = {3.4, 3.5, 7.6, 10.4, 14.5, 17.2,
                                         19.9, 18.2, 15.9, 11.3, 6.9, 5.3}

        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fr-FR")
        Console.WriteLine("Current Culture: {0}", CultureInfo.CurrentCulture.DisplayName)
        Dim fmtString As String = "{0,-" + GetLongestMonthNameLength().ToString() + ":MMMM}     {1,4}"
        For ctr = 0 To temperatures.Length - 1
            Console.WriteLine(fmtString,
                              dateForMonth.AddMonths(ctr),
                              temperatures(ctr))
        Next
        Console.WriteLine()

        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US")
        Console.WriteLine("Current Culture: {0}", CultureInfo.CurrentCulture.DisplayName)
        ' Build the format string dynamically so we allocate enough space for the month name.
        fmtString = "{0,-" + GetLongestMonthNameLength().ToString() + ":MMMM}     {1,4}"
        For ctr = 0 To temperatures.Length - 1
            Console.WriteLine(fmtString,
                              dateForMonth.AddMonths(ctr),
                              temperatures(ctr))
        Next
    End Sub

    Private Function GetLongestMonthNameLength() As Integer
        Dim length As Integer
        For Each nameOfMonth In DateTimeFormatInfo.CurrentInfo.MonthNames
            If nameOfMonth.Length > length Then length = nameOfMonth.Length
        Next
        Return length
    End Function
End Module
' The example displays the following output:
'       Current Culture: French (France)
'       janvier        3,4
'       février        3,5
'       mars           7,6
'       avril         10,4
'       mai           14,5
'       juin          17,2
'       juillet       19,9
'       août          18,2
'       septembre     15,9
'       octobre       11,3
'       novembre       6,9
'       décembre       5,3
'       
'       Current Culture: English (United States)
'       January        3.4
'       February       3.5
'       March          7.6
'       April         10.4
'       May           14.5
'       June          17.2
'       July          19.9
'       August        18.2
'       September     15.9
'       October       11.3
'       November       6.9
'       December       5.3
' </Snippet5>

