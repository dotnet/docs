        ' Declare the jagged array.
        ' The New clause sets the array variable to a 12-element
        ' array. Each element is an array of Double elements.
        Dim sales()() As Double = New Double(11)() {}

        ' Set each element of the sales array to a Double
        ' array of the appropriate size.
        For month As Integer = 0 To 11
            Dim days As Integer =
                DateTime.DaysInMonth(Year(Now), month + 1)
            sales(month) = New Double(days - 1) {}
        Next month

        ' Store values in each element.
        For month As Integer = 0 To 11
            Dim upper = sales(month).GetUpperBound(0)
            For day = 0 To upper
                sales(month)(day) = (month * 100) + day
            Next
        Next