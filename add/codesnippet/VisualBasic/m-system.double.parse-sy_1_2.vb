    Public Class Temperature
        ' Parses the temperature from a string in form
        ' [ws][sign]digits['F|'C][ws]
        Public Shared Function Parse(ByVal s As String) As Temperature
            Dim temp As New Temperature()

            If s.TrimEnd(Nothing).EndsWith("'F") Then
                temp.Value = Double.Parse(s.Remove(s.LastIndexOf("'"c), 2))
            Else
                If s.TrimEnd(Nothing).EndsWith("'C") Then
                    temp.Celsius = Double.Parse(s.Remove(s.LastIndexOf("'"c), 2))
                Else
                    temp.Value = Double.Parse(s)
                End If
            End If
            Return temp
        End Function 'Parse

        ' The value holder
        Protected m_value As Double

        Public Property Value() As Double
            Get
                Return m_value
            End Get
            Set(ByVal Value As Double)
                m_value = Value
            End Set
        End Property

        Public Property Celsius() As Double
            Get
                Return (m_value - 32) / 1.8
            End Get
            Set(ByVal Value As Double)
                m_value = Value * 1.8 + 32
            End Set
        End Property
    End Class