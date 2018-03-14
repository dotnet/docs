' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
    Public Sub Main()
        ' Declare a single-dimensional string array
        Dim array1d() As String = {"zero", "one", "two", "three"}
        ShowArrayInfo(array1d)

        ' Declare a two-dimensional string array
        Dim array2d(,) As String = {{"zero", "0"}, {"one", "1"},
                                     {"two", "2"}, {"three", "3"},
                                     {"four", "4"}, {"five", "5"}}
        ShowArrayInfo(array2d)

        ' Declare a three-dimensional integer array  
        Dim array3d(,,) As Integer = New Integer(,,) {{{1, 2, 3}, {4, 5, 6}},
                                        {{7, 8, 9}, {10, 11, 12}}}
        ShowArrayInfo(array3d)

    End Sub

    Private Sub ShowArrayInfo(arr As Array)
        Console.WriteLine("Length of Array:      {0,3}", arr.Length)
        Console.WriteLine("Number of Dimensions: {0,3}", arr.Rank)
        ' For multidimensional arrays, show number of elements in each dimension.
        If arr.Rank > 1 Then
            For dimension As Integer = 1 To arr.Rank
                Console.WriteLine("   Dimension {0}: {1,3}", dimension,
                                  arr.GetUpperBound(dimension - 1) + 1)
            Next
        End If
        Console.WriteLine()
    End Sub
End Module
' The example displays the following output:
'       Length of Array:        4
'       Number of Dimensions:   1
'       
'       Length of Array:       12
'       Number of Dimensions:   2
'          Dimension 1:   6
'          Dimension 2:   2
'       
'       Length of Array:       12
'       Number of Dimensions:   3
'          Dimension 1:   2
'          Dimension 2:   2
'          Dimension 3:   3
' </Snippet1>