    Public Class Temperature
        Implements IFormattable

        Public Overloads Function ToString(ByVal format As String, ByVal provider As IFormatProvider) As String _
            Implements IFormattable.ToString

            If Not (format Is Nothing) Then
                If format.Equals("F") Then
                    Return [String].Format("{0}'F", Me.Value.ToString())
                End If
                If format.Equals("C") Then
                    Return [String].Format("{0}'C", Me.Celsius.ToString())
                End If
            End If

            Return m_value.ToString(format, provider)
        End Function

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