' **************************************************************************
Option Infer On

Module Module1
    Sub Main()
        '<Snippet1>
        Dim ridesBusToWork1? As Boolean
        Dim ridesBusToWork2 As Boolean?
        Dim ridesBusToWork3 As Nullable(Of Boolean)
        '</Snippet1>

        '<Snippet2>
        Dim numberOfChildren? As Integer
        '</Snippet2>

        '<Snippet3>
        numberOfChildren = 2
        '</Snippet3>

        '<Snippet4>
        numberOfChildren = Nothing
        '</Snippet4>

        '<Snippet5>
        If numberOfChildren.HasValue Then
            MsgBox("There are " & CStr(numberOfChildren) & " children.")
        Else
            MsgBox("It is not known how many children there are.")
        End If
        '</Snippet5>

        '<Snippet6>
        Dim b1? As Boolean
        Dim b2? As Boolean
        b1 = True
        b2 = Nothing

        ' The following If statement displays "Expression is not true".
        If (b1 And b2) Then
            Console.WriteLine("Expression is true")
        Else
            Console.WriteLine("Expression is not true")
        End If

        ' The following If statement displays "Expression is not false".
        If Not (b1 And b2) Then
            Console.WriteLine("Expression is false")
        Else
            Console.WriteLine("Expression is not false")
        End If
        '</Snippet6>

        '<Snippet7>
        ' Variable n is a nullable type, but both m and n have proper values.
        Dim m As Integer = 3
        Dim n? As Integer = 2

        ' The comparison evaluated is 3>2, but compare1 is inferred to be of 
        ' type Boolean?.
        Dim compare1 = m > n
        ' The values summed are 3 and 2, but sum1 is inferred to be of type Integer?.
        Dim sum1 = m + n

        ' The following line displays: 3 * 2 * 5 * True
        Console.WriteLine(m & " * " & n & " * " & sum1 & " * " & compare1)
        '</Snippet7>

        '<Snippet8>
        ' Change the value of n to Nothing.
        n = Nothing

        Dim compare2 = m > n
        Dim sum2 = m + n

        ' Because the values of n, compare2, and sum2 are all Nothing, the
        ' following line displays 3 * * *
        Console.WriteLine(m & " * " & n & " * " & sum2 & " * " & compare2)
        '</Snippet8>
    End Sub
End Module
