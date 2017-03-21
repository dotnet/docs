    <AspNetCompatibilityRequirements(RequirementsMode:=AspNetCompatibilityRequirementsMode.Required)> _
    Public Class CalculatorService
        Implements ICalculatorSession

        Property Result() As Double
            ' Store result in AspNet Session.
            Get
                If (HttpContext.Current.Session("Result") Is Nothing) Then
                    Return 0D
                End If
                Return HttpContext.Current.Session("Result")
            End Get
            Set(ByVal value As Double)
                HttpContext.Current.Session("Result") = value
            End Set
        End Property

        Public Sub Clear() _
 Implements ICalculatorSession.Clear
            Result = 0D
        End Sub

        Public Sub AddTo(ByVal n As Double) _
Implements ICalculatorSession.AddTo
            Result += n
        End Sub

        Public Sub SubtractFrom(ByVal n As Double) _
Implements ICalculatorSession.SubtractFrom

            Result -= n
        End Sub

        Public Sub MultiplyBy(ByVal n As Double) _
Implements ICalculatorSession.MultiplyBy

            Result *= n
        End Sub

        Public Sub DivideBy(ByVal n As Double) _
Implements ICalculatorSession.DivideBy

            Result /= n
        End Sub

        Public Function Equal() As Double _
Implements ICalculatorSession.Equal

            Return Result
        End Function
    End Class