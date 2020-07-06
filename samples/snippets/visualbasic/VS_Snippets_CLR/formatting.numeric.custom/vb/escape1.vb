' Visual Basic .NET Document
Option Strict On

Module Example
    Public Sub Main()
        ' <Snippet11>
        Dim value As Integer = 123
        Console.WriteLine(value.ToString("\#\#\# ##0 dollars and \0\0 cents \#\#\#"))
        Console.WriteLine(String.Format("{0:\#\#\# ##0 dollars and \0\0 cents \#\#\#}",
                                        value))
        ' Displays ### 123 dollars and 00 cents ###

        Console.WriteLine(value.ToString("\\\\\\ ##0 dollars and \0\0 cents \\\\\\"))
        Console.WriteLine(String.Format("{0:\\\\\\ ##0 dollars and \0\0 cents \\\\\\}",
                                        value))
        ' Displays \\\ 123 dollars and 00 cents \\\
        ' </Snippet11>
    End Sub
End Module



