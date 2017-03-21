        Dim testVar As Object
        ' No instance has been assigned to variable testVar yet.
        Dim testCheck As Boolean
        ' The following call returns True.
        testCheck = IsNothing(testVar)
        ' Assign a string instance to variable testVar.
        testVar = "ABCDEF"
        ' The following call returns False.
        testCheck = IsNothing(testVar)
        ' Disassociate variable testVar from any instance.
        testVar = Nothing
        ' The following call returns True.
        testCheck = IsNothing(testVar)