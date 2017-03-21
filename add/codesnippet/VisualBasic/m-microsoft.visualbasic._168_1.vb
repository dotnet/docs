        Dim TestString As String = "Left"
        Dim lString As String
        ' Returns "Left      "
        lString = LSet(TestString, 10)
        ' Returns "Le"
        lString = LSet(TestString, 2)
        ' Returns "Left"
        lString = LSet(TestString, 4)