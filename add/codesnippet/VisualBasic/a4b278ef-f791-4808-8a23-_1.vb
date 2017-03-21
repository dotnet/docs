        Dim TestStrings(2) As String
        TestStrings(0) = "This"
        TestStrings(1) = "Is"
        TestStrings(2) = "It"
        Dim subStrings() As String
        ' Returns ["This", "Is"].
        subStrings = Filter(TestStrings, "is", True, CompareMethod.Text)
        ' Returns ["This"].
        subStrings = Filter(TestStrings, "is", True, CompareMethod.Binary)
        ' Returns ["Is", "It"].
        subStrings = Filter(TestStrings, "is", False, CompareMethod.Binary)