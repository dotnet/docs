' Visual Basic .NET Document
Option Strict On

Module Example2
    Public Sub Main()
        ' <Snippet8>
        Dim dat As Date = #1/17/2012 9:30AM#
        Dim city As String = "Chicago"
        Dim temp As Integer = -16
        Dim output As String = String.Format("At {0} in {1}, the temperature was {2} degrees.",
                                           dat, city, temp)
        Console.WriteLine(output)
        ' The example displays the following output:
        '    At 1/17/2012 9:30:00 AM in Chicago, the temperature was -16 degrees.   
        ' </Snippet8>
    End Sub
End Module

