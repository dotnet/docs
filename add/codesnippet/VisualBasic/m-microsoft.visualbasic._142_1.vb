        Dim testArray(3) As Boolean
        Dim testString As String = "Test string"
        Dim testObject As Object = New Object()
        Dim testNumber As Integer = 12
        testArray(0) = IsReference(testArray)
        testArray(1) = IsReference(testString)
        testArray(2) = IsReference(testObject)
        testArray(3) = IsReference(testNumber)