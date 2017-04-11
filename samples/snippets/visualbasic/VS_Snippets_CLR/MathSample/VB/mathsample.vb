' <Snippet1>
'The following class represents simple functionality of the trapezoid.
Class MathTrapezoidSample

    Private m_longBase As Double
    Private m_shortBase As Double
    Private m_leftLeg As Double
    Private m_rightLeg As Double

    Public Sub New(ByVal longbase As Double, ByVal shortbase As Double, ByVal leftLeg As Double, ByVal rightLeg As Double)
        m_longBase = Math.Abs(longbase)
        m_shortBase = Math.Abs(shortbase)
        m_leftLeg = Math.Abs(leftLeg)
        m_rightLeg = Math.Abs(rightLeg)
    End Sub

    Private Function GetRightSmallBase() As Double
        GetRightSmallBase = (Math.Pow(m_rightLeg, 2) - Math.Pow(m_leftLeg, 2) + Math.Pow(m_longBase, 2) + Math.Pow(m_shortBase, 2) - 2 * m_shortBase * m_longBase) / (2 * (m_longBase - m_shortBase))
    End Function

    Public Function GetHeight() As Double
        Dim x As Double = GetRightSmallBase()
        GetHeight = Math.Sqrt(Math.Pow(m_rightLeg, 2) - Math.Pow(x, 2))
    End Function

    Public Function GetSquare() As Double
        GetSquare = GetHeight() * m_longBase / 2
    End Function

    Public Function GetLeftBaseRadianAngle() As Double
        Dim sinX As Double = GetHeight() / m_leftLeg
        GetLeftBaseRadianAngle = Math.Round(Math.Asin(sinX), 2)
    End Function

    Public Function GetRightBaseRadianAngle() As Double
        Dim x As Double = GetRightSmallBase()
        Dim cosX As Double = (Math.Pow(m_rightLeg, 2) + Math.Pow(x, 2) - Math.Pow(GetHeight(), 2)) / (2 * x * m_rightLeg)
        GetRightBaseRadianAngle = Math.Round(Math.Acos(cosX), 2)
    End Function

    Public Function GetLeftBaseDegreeAngle() As Double
        Dim x As Double = GetLeftBaseRadianAngle() * 180 / Math.PI
        GetLeftBaseDegreeAngle = Math.Round(x, 2)
    End Function

    Public Function GetRightBaseDegreeAngle() As Double
        Dim x As Double = GetRightBaseRadianAngle() * 180 / Math.PI
        GetRightBaseDegreeAngle = Math.Round(x, 2)
    End Function

    Public Shared Sub Main()
        Dim trpz As MathTrapezoidSample = New MathTrapezoidSample(20, 10, 8, 6)
        Console.WriteLine("The trapezoid's bases are 20.0 and 10.0, the trapezoid's legs are 8.0 and 6.0")
        Dim h As Double = trpz.GetHeight()
        Console.WriteLine("Trapezoid height is: " + h.ToString())
        Dim dxR As Double = trpz.GetLeftBaseRadianAngle()
        Console.WriteLine("Trapezoid left base angle is: " + dxR.ToString() + " Radians")
        Dim dyR As Double = trpz.GetRightBaseRadianAngle()
        Console.WriteLine("Trapezoid right base angle is: " + dyR.ToString() + " Radians")
        Dim dxD As Double = trpz.GetLeftBaseDegreeAngle()
        Console.WriteLine("Trapezoid left base angle is: " + dxD.ToString() + " Degrees")
        Dim dyD As Double = trpz.GetRightBaseDegreeAngle()
        Console.WriteLine("Trapezoid left base angle is: " + dyD.ToString() + " Degrees")
    End Sub
End Class
' </Snippet1>
