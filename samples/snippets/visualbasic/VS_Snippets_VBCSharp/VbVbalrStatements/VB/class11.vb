Public Class Class11
    ' fae3eca1-f0b2-4400-994b-7aa58a848448
    ' Dim Statement (Visual Basic)

    Private Sub DimsMethod()

        '<Snippet141>
        ' Declare and initialize a Long variable.
        Dim startingAmount As Long = 500

        ' Declare a local variable that always retains its value,
        ' even after its procedure returns to the calling code.
        Static totalSales As Double

        ' Declare a variable that refers to an array.
        Dim highTemperature(31) As Integer

        ' Declare and initialize an array variable that
        ' holds four Boolean check values.
        Dim checkValues() As Boolean = {False, False, True, False}
        '</Snippet141>

        totalSales = 50
    End Sub

    '<Snippet142>
    Public Sub ListPrimes()
        ' The sb variable can be accessed only
        ' within the ListPrimes procedure.
        Dim sb As New System.Text.StringBuilder()

        ' The number variable can be accessed only
        ' within the For...Next block.  A different
        ' variable with the same name could be declared
        ' outside of the For...Next block.
        For number As Integer = 1 To 30
            If CheckIfPrime(number) = True Then
                sb.Append(number.ToString & " ")
            End If
        Next

        Debug.WriteLine(sb.ToString)
        ' Output: 2 3 5 7 11 13 17 19 23 29
    End Sub

    Private Function CheckIfPrime(ByVal number As Integer) As Boolean
        If number < 2 Then
            Return False
        Else
            ' The root and highCheck variables can be accessed
            ' only within the Else block.  Different variables
            ' with the same names could be declared outside of
            ' the Else block.
            Dim root As Double = Math.Sqrt(number)
            Dim highCheck As Integer = Convert.ToInt32(Math.Truncate(root))

            ' The div variable can be accessed only within
            ' the For...Next block.
            For div As Integer = 2 To highCheck
                If number Mod div = 0 Then
                    Return False
                End If
            Next

            Return True
        End If
    End Function
    '</Snippet142>

    Public Sub OperateCar()
        '<Snippet144>
        ' Create a new instance of a Car.
        Dim theCar As New Car()
        theCar.Accelerate(30)
        theCar.Accelerate(20)
        theCar.Accelerate(-5)

        Debug.WriteLine(theCar.Speed.ToString)
        ' Output: 45
        '</Snippet144>
    End Sub

    '<Snippet145>
    Public Class Car
        ' The speedValue variable can be accessed by
        ' any procedure in the Car class.
        Private speedValue As Integer = 0

        Public ReadOnly Property Speed() As Integer
            Get
                Return speedValue
            End Get
        End Property

        Public Sub Accelerate(ByVal speedIncrease As Integer)
            speedValue += speedIncrease
        End Sub
    End Class
    '</Snippet145>

End Class
