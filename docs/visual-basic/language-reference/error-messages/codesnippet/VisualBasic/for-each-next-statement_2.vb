        ' Create lists of numbers and letters
        ' by using array initializers.
        Dim numbers() As Integer = {1, 4, 7}
        Dim letters() As String = {"a", "b", "c"}

        ' Iterate through the list by using nested loops.
        For Each number As Integer In numbers
            For Each letter As String In letters
                Debug.Write(number.ToString & letter & " ")
            Next
        Next
        Debug.WriteLine("")
        'Output: 1a 1b 1c 4a 4b 4c 7a 7b 7c 