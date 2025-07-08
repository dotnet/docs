' Visual Basic .NET Document
Option Strict On

' <Snippet7>
Imports System.Globalization
Imports System.Text

Module Example4
    Public Sub Main()
        Dim rnd As New Random()
        Dim sb As New StringBuilder()

        ' Generate 10 random numbers and store them in a StringBuilder.
        For ctr As Integer = 0 To 9
            sb.Append(rnd.Next().ToString("N5"))
        Next
        Console.WriteLine("The original string:")
        Console.WriteLine(sb.ToString())
        Console.WriteLine()

        ' Decrease each number by one.
        For ctr As Integer = 0 To sb.Length - 1
            If Char.GetUnicodeCategory(sb(ctr)) = UnicodeCategory.DecimalDigitNumber Then
                Dim number As Integer = CType(Char.GetNumericValue(sb(ctr)), Integer)
                number -= 1
                If number < 0 Then number = 9

                sb(ctr) = number.ToString()(0)
            End If
        Next
        Console.WriteLine("The new string:")
        Console.WriteLine(sb.ToString())
    End Sub
End Module
' The example displays the following output:
'    The original string:
'    1,457,531,530.00000940,522,609.000001,668,113,564.000001,998,992,883.000001,792,660,834.00
'    000101,203,251.000002,051,183,075.000002,066,000,067.000001,643,701,043.000001,702,382,508
'    .00000
'    
'    The new string:
'    0,346,420,429.99999839,411,598.999990,557,002,453.999990,887,881,772.999990,681,559,723.99
'    999090,192,140.999991,940,072,964.999991,955,999,956.999990,532,690,932.999990,691,271,497
'    .99999
' </Snippet7>

