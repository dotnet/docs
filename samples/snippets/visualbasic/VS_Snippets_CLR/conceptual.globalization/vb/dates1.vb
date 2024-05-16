' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization
Imports System.Threading

Module Example3
    Dim dates() As Date = {New Date(2012, 10, 11, 7, 6, 0),
                            New Date(2012, 10, 11, 18, 19, 0)}

    Public Sub Main3()
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("hr-HR")
        ShowDayInfo()
        Console.WriteLine()
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB")
        ShowDayInfo()
    End Sub

    Private Sub ShowDayInfo()
        Console.WriteLine("Date: {0:D}", dates(0))
        Console.WriteLine("   Sunrise: {0:T}", dates(0))
        Console.WriteLine("   Sunset:  {0:T}", dates(1))
    End Sub
End Module
' The example displays the following output:
'       Date: 11. listopada 2012.
'          Sunrise: 7:06:00
'          Sunset:  18:19:00
'       
'       Date: 11 October 2012
'          Sunrise: 07:06:00
'          Sunset:  18:19:00
' </Snippet2>

