        Dim numbers() = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9}
        Dim lastIndex =
          Function(intArray() As Integer) intArray.Length - 1
        For i = 0 To lastIndex(numbers)
            numbers(i) += 1
        Next