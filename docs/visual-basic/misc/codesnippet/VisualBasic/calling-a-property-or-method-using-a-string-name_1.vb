    Class MathClass
        Function SquareRoot(ByVal X As Double) As Double
            Return Math.Sqrt(X)
        End Function
        Function InverseSine(ByVal X As Double) As Double
            Return Math.Atan(X / Math.Sqrt(-X * X + 1))
        End Function
        Function Acos(ByVal X As Double) As Double
            Return Math.Atan(-X / Math.Sqrt(-X * X + 1)) + 2 * Math.Atan(1)
        End Function
    End Class