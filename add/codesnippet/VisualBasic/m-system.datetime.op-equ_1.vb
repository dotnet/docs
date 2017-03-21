      Dim april19 As New DateTime(2001, 4, 19)
      Dim otherDate As New DateTime(1991, 6, 5)

      Dim areEqual As Boolean
      ' areEqual gets false.
      areEqual = DateTime.op_Equality(april19, otherDate)

      otherDate = New DateTime(2001, 4, 19)
      ' areEqual gets true.
      areEqual = System.DateTime.op_Equality(april19, otherDate)