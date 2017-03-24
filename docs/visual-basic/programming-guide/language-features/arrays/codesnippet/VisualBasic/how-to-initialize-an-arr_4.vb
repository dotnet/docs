        Dim numbers = {{1, 2}, {3, 4}, {5, 6}}

        ' Iterate through the array.
        For index0 = 0 To numbers.GetUpperBound(0)
            For index1 = 0 To numbers.GetUpperBound(1)
                Debug.Write(numbers(index0, index1).ToString & " ")
            Next
            Debug.WriteLine("")
        Next
        ' Output
        '  1 2
        '  3 4
        '  5 6