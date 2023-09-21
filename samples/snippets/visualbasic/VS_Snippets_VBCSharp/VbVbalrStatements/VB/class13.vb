Option Strict Off

' Option Strict Statement
' 5883e0c1-a920-4274-8e46-b0ff047eaee5

Public Class Class13

    Public Sub Process()
    End Sub

    Private Sub ImplicitConversion()
        '<Snippet161>
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
        '</Snippet161>
    End Sub

    Private Sub LateBinding()
        '<Snippet162>
        ' If Option Strict is on, this late binding
        ' causes a compile-time error. If Option Strict
        ' is off, the late binding instead causes a
        ' run-time error.
        Dim punchCard As New Object
        punchCard.Column = 5
        '</Snippet162>
    End Sub

    Private Sub DeclaredWithImplicitType()
        '<Snippet163>
        ' If Option Strict is on and Option Infer is off,
        ' this Dim statement without an As clause 
        ' causes a compile-time error.
        Dim cardReaders = 5

        ' If Option Strict is on, a compile-time error occurs.
        ' If Option Strict is off, the variable is set to Nothing.
        Dim dryWall
        '</Snippet163>
    End Sub

    '<Snippet164>
    ' If Option Strict is on, this parameter without an
    ' As clause causes a compile-time error.
    Private Sub DetectIntergalacticRange(ByVal photonAttenuation)

    End Sub
    '</Snippet164>

End Class
