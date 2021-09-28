' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization
Imports System.Threading

Module Example
    Public Sub Main()
        Dim culture1 As CultureInfo = CultureInfo.CurrentCulture
        Dim culture2 As CultureInfo = Thread.CurrentThread.CurrentCulture
        Console.WriteLine("The current culture is {0}", culture1.Name)
        Console.WriteLine("The two CultureInfo objects are equal: {0}",
                          culture1.Equals(culture2))
    End Sub
End Module
' The example displays output like the following:
'     The current culture is en-US
'     The two CultureInfo objects are equal: True
' </Snippet1>
