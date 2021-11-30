' Visual Basic .NET Document
Option Strict On

Module Example8
    Public Sub Main8()
        ' <Snippet9>
        Dim customFormat As String = "MMMM dd, yyyy (dddd)"
        Dim date1 As Date = #8/28/2009#
        Console.WriteLine(date1.ToString(customFormat))
        ' The example displays the following output if run on a system
        ' whose language is English:
        '       August 28, 2009 (Friday)      
        ' </Snippet9>
    End Sub
End Module

