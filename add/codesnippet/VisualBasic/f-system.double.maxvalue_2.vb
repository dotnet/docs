    Public Class Temperature

        Public Shared ReadOnly Property MinValue() As Double
            Get
                Return Double.MinValue
            End Get
        End Property

        Public Shared ReadOnly Property MaxValue() As Double
            Get
                Return Double.MaxValue
            End Get
        End Property

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