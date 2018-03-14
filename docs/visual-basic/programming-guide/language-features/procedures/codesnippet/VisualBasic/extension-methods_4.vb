Option Strict Off
Imports System.Runtime.CompilerServices

Module Module4

    Sub Main()
        Dim aString As String = "Initial value for aString"
        aString.PrintMe()

        Dim anObject As Object = "Initial value for anObject"
        ' The following statement causes a run-time error when Option
        ' Strict is off, and a compiler error when Option Strict is on.
        'anObject.PrintMe()
    End Sub

    <Extension()> 
    Public Sub PrintMe(ByVal str As String)
        Console.WriteLine(str)
    End Sub

    <Extension()> 
    Public Sub PrintMe(ByVal obj As Object)
        Console.WriteLine(obj)
    End Sub

End Module