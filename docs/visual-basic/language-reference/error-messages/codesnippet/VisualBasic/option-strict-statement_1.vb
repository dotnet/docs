        ' If Option Strict is on, this implicit narrowing
        ' conversion causes a compile-time error.
        ' The commented statements below use explicit
        ' conversions to avoid a compile-time error.
        Dim cyclists As Long = 5
        Dim bicycles As Integer = cyclists
        'Dim bicycles As Integer = CType(cyclists, Integer)
        'Dim bicycles As Integer = CInt(cyclists)
        'Dim bicycles As Integer = Convert.ToInt32(cyclists)


        ' If Option Strict is on, this implicit narrowing
        ' conversion causes a compile-time error.
        ' The commented statements below use explicit
        ' conversions to avoid a compile-time error.
        Dim charVal As Char = "a"
        'Dim charVal As Char = "a"c
        'Dim charVal As Char = CType("a", Char)


        ' If Option Strict is on, a compile-time error occurs.
        ' If Option Strict is off, the string is implicitly converted
        ' to a Double, and then is added to the other number.
        Dim myAge As Integer = "34" + 6


        ' If Option Strict is on, a compile-time error occurs.
        ' If Option Strict is off, the floating-point number
        ' is implicitly converted to a Long.
        Dim num = 123.45 \ 10