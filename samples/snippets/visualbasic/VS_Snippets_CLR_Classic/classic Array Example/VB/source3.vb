' <Snippet2>
Public Class SamplesArray2

    Public Shared Sub Main()

        ' Creates and initializes a new three-dimensional Array of
        ' type Int32.
        Dim myArr As Array = Array.CreateInstance(GetType(Int32), 2, 3, 4)
        Dim i As Integer
        For i = myArr.GetLowerBound(0) To myArr.GetUpperBound(0)
            Dim j As Integer
            For j = myArr.GetLowerBound(1) To myArr.GetUpperBound(1)
                Dim k As Integer
                For k = myArr.GetLowerBound(2) To myArr.GetUpperBound(2)
                    myArr.SetValue(i * 100 + j * 10 + k, i, j, k)
                Next k
            Next j
        Next i ' Displays the properties of the Array.
        Console.WriteLine("The Array has {0} dimension(s) and a " _
           + "total of {1} elements.", myArr.Rank, myArr.Length)
        Console.WriteLine(ControlChars.Tab + "Length" + ControlChars.Tab _
           + "Lower" + ControlChars.Tab + "Upper")
        For i = 0 To myArr.Rank - 1
            Console.Write("{0}:" + ControlChars.Tab + "{1}", i,
               myArr.GetLength(i))
            Console.WriteLine(ControlChars.Tab + "{0}" + ControlChars.Tab _
               + "{1}", myArr.GetLowerBound(i), myArr.GetUpperBound(i))
        Next i

        ' Displays the contents of the Array.
        Console.WriteLine("The Array contains the following values:")
        PrintValues(myArr)
    End Sub

    Public Shared Sub PrintValues(myArr As Array)
        Dim myEnumerator As System.Collections.IEnumerator =
           myArr.GetEnumerator()
        Dim i As Integer = 0
        Dim cols As Integer = myArr.GetLength(myArr.Rank - 1)
        While myEnumerator.MoveNext()
            If i < cols Then
                i += 1
            Else
                Console.WriteLine()
                i = 1
            End If
            Console.Write(ControlChars.Tab + "{0}", myEnumerator.Current)
        End While
        Console.WriteLine()
    End Sub
End Class

' This code produces the following output.
' 
' The Array has 3 dimension(s) and a total of 24 elements.
'     Length    Lower    Upper
' 0:    2    0    1
' 1:    3    0    2
' 2:    4    0    3
' The Array contains the following values:
'     0    1    2    3
'     10    11    12    13
'     20    21    22    23
'     100    101    102    103
'     110    111    112    113
'     120    121    122    123 
' </Snippet2>