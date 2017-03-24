        ' Create a jagged array of arrays that have different lengths.
        Dim jaggedNumbers = {({1, 2, 3}), ({4, 5}), ({6}), ({7})}

        For indexA = 0 To jaggedNumbers.Length - 1
            For indexB = 0 To jaggedNumbers(indexA).Length - 1
                Debug.Write(jaggedNumbers(indexA)(indexB) & " ")
            Next
            Debug.WriteLine("")
        Next

        ' Output:
        '  1 2 3 
        '  4 5 
        '  6
        '  7