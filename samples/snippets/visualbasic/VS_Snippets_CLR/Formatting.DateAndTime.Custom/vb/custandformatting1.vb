' Visual Basic .NET Document
Option Strict On

Module Example
    Public Sub Main()
        ' <Snippet17>
        Dim thisDate1 As Date = #6/10/2011#
        Console.WriteLine("Today is " + thisDate1.ToString("MMMM dd, yyyy") + ".")

        Dim thisDate2 As New DateTimeOffset(2011, 6, 10, 15, 24, 16, TimeSpan.Zero)
        Console.WriteLine("The current date and time: {0:MM/dd/yy H:mm:ss zzz}",
                          thisDate2)
        ' The example displays the following output:
        '    Today is June 10, 2011.
        '    The current date and time: 06/10/11 15:24:16 +00:00
        ' </Snippet17>
    End Sub
End Module

