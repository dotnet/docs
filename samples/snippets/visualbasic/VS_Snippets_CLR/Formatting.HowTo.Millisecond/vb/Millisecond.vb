' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization
Imports System.Text.REgularExpressions

Module MillisecondDisplay
    Public Sub Main()

        Dim dateString As String = "7/16/2008 8:32:45.126 AM"

        Try
            Dim dateValue As Date = Date.Parse(dateString)
            Dim dateOffsetValue As DateTimeOffset = DateTimeOffset.Parse(dateString)

            ' Display Millisecond component alone.
            Console.WriteLine("Millisecond component only: {0}", _
                              dateValue.ToString("fff"))
            Console.WriteLine("Millisecond component only: {0}", _
                              dateOffsetValue.ToString("fff"))

            ' Display Millisecond component with full date and time.
            Console.WriteLine("Date and Time with Milliseconds: {0}", _
                              dateValue.ToString("MM/dd/yyyy hh:mm:ss.fff tt"))
            Console.WriteLine("Date and Time with Milliseconds: {0}", _
                              dateOffsetValue.ToString("MM/dd/yyyy hh:mm:ss.fff tt"))

            ' Append millisecond pattern to current culture's full date time pattern
            Dim fullPattern As String = DateTimeFormatInfo.CurrentInfo.FullDateTimePattern
            fullPattern = Regex.Replace(fullPattern, "(:ss|:s)", "$1.fff")

            ' Display Millisecond component with modified full date and time pattern.
            Console.WriteLine("Modified full date time pattern: {0}", _
                              dateValue.ToString(fullPattern))
            Console.WriteLine("Modified full date time pattern: {0}", _
                              dateOffsetValue.ToString(fullPattern))
        Catch e As FormatException
            Console.WriteLine("Unable to convert {0} to a date.", dateString)
        End Try
    End Sub
End Module
' The example displays the following output if the current culture is en-US:
'    Millisecond component only: 126
'    Millisecond component only: 126
'    Date and Time with Milliseconds: 07/16/2008 08:32:45.126 AM
'    Date and Time with Milliseconds: 07/16/2008 08:32:45.126 AM
'    Modified full date time pattern: Wednesday, July 16, 2008 8:32:45.126 AM
'    Modified full date time pattern: Wednesday, July 16, 2008 8:32:45.126 AM
' </Snippet1>

Public Module AdditionalSnippets

    Public Sub Show
        ' <Snippet2>
        Dim dateValue As New Date(2008, 7, 16, 8, 32, 45, 180)
        Console.WriteLIne(dateValue.ToString("fff"))
        Console.WriteLine(dateValue.ToString("FFF"))
        ' The example displays the following output to the console:
        '    180
        '    18      
        ' </Snippet2>
    End Sub

    Public Sub Show2()
        ' <Snippet3>
        Dim dateValue As New DateTime(2008, 7, 16, 8, 32, 45, 180)
        Console.WriteLine("{0} seconds", dateValue.ToString("s.f"))
        Console.WriteLine("{0} seconds", dateValue.ToString("s.ff"))
        Console.WriteLine("{0} seconds", dateValue.ToString("s.ffff"))
        ' The example displays the following output to the console:
        '    45.1 seconds
        '    45.18 seconds
        '    45.1800 seconds
        ' </Snippet3>      
    End Sub

End Module
