' Visual Basic .NET Document
Option Strict On

<Assembly: CLSCompliant(True)>
Module Example1
    Public Sub Main()
        ' <Snippet10>
        Dim number1 As Double = 1234567890
        Dim value1 As String = number1.ToString("(###) ###-####")
        Console.WriteLine(value1)

        Dim number2 As Integer = 42
        Dim value2 As String = number2.ToString("My Number = #")
        Console.WriteLine(value2)
        ' The example displays the following output:
        '       (123) 456-7890
        '       My Number = 42
        ' </Snippet10>      
    End Sub
End Module

