        Dim testVar As Object
        Dim numericCheck As Boolean
        testVar = "53"
        ' The following call to IsNumeric returns True.
        numericCheck = IsNumeric(testVar)
        testVar = "459.95"
        ' The following call to IsNumeric returns True.
        numericCheck = IsNumeric(testVar)
        testVar = "45 Help"
        ' The following call to IsNumeric returns False.
        numericCheck = IsNumeric(testVar)