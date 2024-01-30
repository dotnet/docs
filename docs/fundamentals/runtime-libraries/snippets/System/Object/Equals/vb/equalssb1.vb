' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Imports System.Text

Module Example5
    Public Sub Main()
        Dim sb1 As New StringBuilder("building a string...")
        Dim sb2 As New StringBuilder("building a string...")

        Console.WriteLine("sb1.Equals(sb2): {0}", sb1.Equals(sb2))
        Console.WriteLine("CObj(sb1).Equals(sb2): {0}",
                        CObj(sb1).Equals(sb2))
        Console.WriteLine("Object.Equals(sb1, sb2): {0}",
                        Object.Equals(sb1, sb2))

        Console.WriteLine()
        Dim sb3 As Object = New StringBuilder("building a string...")
        Console.WriteLine("sb3.Equals(sb2): {0}", sb3.Equals(sb2))
    End Sub
End Module
' The example displays the following output:
'       sb1.Equals(sb2): True
'       CObj(sb1).Equals(sb2): False
'       Object.Equals(sb1, sb2): False
'
'       sb3.Equals(sb2): False
' </Snippet5>
