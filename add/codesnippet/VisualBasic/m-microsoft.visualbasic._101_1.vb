        Dim testVar As Object
        Dim nullCheck As Boolean
        nullCheck = IsDBNull(testVar)
        testVar = ""
        nullCheck = IsDBNull(testVar)
        testVar = System.DBNull.Value
        nullCheck = IsDBNull(testVar)
        ' The first two calls to IsDBNull return False; the third returns True.