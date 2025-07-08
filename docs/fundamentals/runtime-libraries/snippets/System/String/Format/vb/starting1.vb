' Visual Basic .NET Document
Option Strict On

Imports System.Text

Module Example14
    Public Sub Main()
        ' <Snippet30>
        Dim temp As Decimal = 20.4D
        Dim s As String = String.Format("The temperature is {0}°C.", temp)
        Console.WriteLine(s)
        ' Displays 'The temperature is 20.4°C.'
        ' </Snippet30>

        Snippet31()
        Snippet32()
        Snippet33()
        Snippet34()
    End Sub

    Private Sub Snippet31()
        ' <Snippet31>
        Dim s As String = String.Format("At {0}, the temperature is {1}°C.",
                                      Date.Now, 20.4)
        ' Output similar to: 'At 4/10/2015 9:29:41 AM, the temperature is 20.4°C.'
        ' </Snippet31>
        Console.WriteLine(s)
    End Sub

    Private Sub Snippet32()
        ' <Snippet32>
        Dim s As String = String.Format("It is now {0:d} at {0:t}",
                                      Date.Now)
        ' Output similar to: 'It is now 4/10/2015 at 10:04 AM'
        ' </Snippet32>
        Console.WriteLine(s)
    End Sub

    Private Sub Snippet33()
        ' <Snippet33>
        Dim years() As Integer = {2013, 2014, 2015}
        Dim population() As Integer = {1025632, 1105967, 1148203}
        Dim sb As New StringBuilder()
        sb.Append(String.Format("{0,6} {1,15}{2}{2}",
                               "Year", "Population", vbCrLf))
        For index As Integer = 0 To years.Length - 1
            sb.AppendFormat("{0,6} {1,15:N0}{2}",
                          years(index), population(index), vbCrLf)
        Next
        ' Result:
        '      Year      Population
        '
        '      2013       1,025,632
        '      2014       1,105,967
        '      2015       1,148,203
        ' </Snippet33>
        Console.WriteLine(sb)
    End Sub

    Private Sub Snippet34()
        ' <Snippet34>
        Dim years() As Integer = {2013, 2014, 2015}
        Dim population() As Integer = {1025632, 1105967, 1148203}
        Dim s As String = String.Format("{0,-10} {1,-10}{2}{2}",
                                       "Year", "Population", vbCrLf)
        For index As Integer = 0 To years.Length - 1
            s += String.Format("{0,-10} {1,-10:N0}{2}",
                             years(index), population(index), vbCrLf)
        Next
        ' Result:
        '    Year       Population
        '
        '    2013       1,025,632
        '    2014       1,105,967
        '    2015       1,148,203
        ' </Snippet34>
        Console.WriteLine(vbCrLf + s)
    End Sub
End Module

