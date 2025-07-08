' Visual Basic .NET Document
Option Strict On

' <Snippet10>
Imports System.Globalization
Imports System.Threading

Module Example3
    Public Sub Main()
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US")
        Console.WriteLine(String.Compare("A", "a", StringComparison.CurrentCulture))
        Console.WriteLine(String.Compare("A", "a", StringComparison.Ordinal))
    End Sub
End Module
' The example displays the following output:
'       1                                                                                     
'       -32
' </Snippet10>
