
'-----------------------------------------------------------------------------
'<Snippet3>
' File: TestCode.vb

Imports UtilityMethods

Module Test

    Sub Main(ByVal args As String())


        System.Console.WriteLine("Calling methods from MathLibrary.DLL:")

        If args.Length <> 2 Then
            System.Console.WriteLine("Usage: TestCode <num1> <num2>")
            Return
        End If

        Dim num1 As Long = Long.Parse(args(0))
        Dim num2 As Long = Long.Parse(args(1))

        Dim sum As Long = AddClass.Add(num1, num2)
        Dim product As Long = MultiplyClass.Multiply(num1, num2)

        System.Console.WriteLine("{0} + {1} = {2}", num1, num2, sum)
        System.Console.WriteLine("{0} * {1} = {2}", num1, num2, product)

    End Sub

End Module

' Output (assuming 1234 and 5678 are entered as command-line arguments):
' Calling methods from MathLibrary.DLL:
' 1234 + 5678 = 6912
' 1234 * 5678 = 7006652        

'</Snippet3>


'-----------------------------------------------------------------------------
Module Module1
    Sub Test()
        Dim num1 As Long = 100
        Dim num2 As Long = 200

        '<Snippet4>
        MultiplyClass.Multiply(num1, num2)
        '</Snippet4>

        '<Snippet5>
        UtilityMethods.MultiplyClass.Multiply(num1, num2)
        '</Snippet5>
    End Sub
End Module




