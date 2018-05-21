        ' Defines variables.
        Dim TestStr1 As String = "ABCD"
        Dim TestStr2 As String = "abcd"
        Dim TestComp As Integer
        ' The two strings sort equally. Returns 0.
        TestComp = StrComp(TestStr1, TestStr2, CompareMethod.Text)
        ' TestStr1 sorts before TestStr2. Returns -1.
        TestComp = StrComp(TestStr1, TestStr2, CompareMethod.Binary)
        ' TestStr2 sorts after TestStr1. Returns 1.
        TestComp = StrComp(TestStr2, TestStr1, CompareMethod.Binary)