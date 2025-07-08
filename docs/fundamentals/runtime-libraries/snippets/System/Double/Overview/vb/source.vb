Imports System.Globalization

Namespace Snippets
    Class Launcher
        Public Overloads Shared Sub Main()
            Dim t1 As Temperature = Temperature.Parse("20'F", NumberStyles.Float, Nothing)
            Console.WriteLine(t1.ToString("F", Nothing))

            Dim str1 As String = t1.ToString("C", Nothing)
            Console.WriteLine(str1)

            Dim t2 As Temperature = Temperature.Parse(str1, NumberStyles.Float, Nothing)
            Console.WriteLine(t2.ToString("F", Nothing))

            Console.WriteLine(t1.CompareTo(t2))

            Dim t3 As Temperature = Temperature.Parse("20'C", NumberStyles.Float, Nothing)
            Console.WriteLine(t3.ToString("F", Nothing))

            Console.WriteLine(t1.CompareTo(t3))

            Console.ReadLine()
        End Sub
    End Class
    '<snippet1>
    ' Temperature class stores the value as Double
    ' and delegates most of the functionality 
    ' to the Double implementation.
    Public Class Temperature
        Implements IComparable, IFormattable

        Public Overloads Function CompareTo(ByVal obj As Object) As Integer _
            Implements IComparable.CompareTo

            If TypeOf obj Is Temperature Then
                Dim temp As Temperature = CType(obj, Temperature)

                Return m_value.CompareTo(temp.m_value)
            End If

            Throw New ArgumentException("object is not a Temperature")
        End Function

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

        ' Parses the temperature from a string in form
        ' [ws][sign]digits['F|'C][ws]
        Public Shared Function Parse(ByVal s As String, ByVal styles As NumberStyles, ByVal provider As IFormatProvider) As Temperature
            Dim temp As New Temperature()

            If s.TrimEnd().EndsWith("'F") Then
                temp.Value = Double.Parse(s.Remove(s.LastIndexOf("'"c), 2), styles, provider)
            Else
                If s.TrimEnd().EndsWith("'C") Then
                    temp.Celsius = Double.Parse(s.Remove(s.LastIndexOf("'"c), 2), styles, provider)
                Else
                    temp.Value = Double.Parse(s, styles, provider)
                End If
            End If
            Return temp
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
    '</snippet1>
End Namespace

Namespace Snippets2
    '<snippet2>
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
    '</snippet2>
End Namespace

Namespace Snippets3
    '<snippet3>
    Public Class Temperature
        Implements IComparable

        Public Overloads Function CompareTo(ByVal obj As Object) As Integer _
            Implements IComparable.CompareTo

            If TypeOf obj Is Temperature Then
                Dim temp As Temperature = CType(obj, Temperature)

                Return m_value.CompareTo(temp.m_value)
            End If

            Throw New ArgumentException("object is not a Temperature")
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
    '</snippet3>
End Namespace

Namespace Snippets4
    '<snippet4>
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
    '</snippet4>
End Namespace

Namespace Snippets5
    '<snippet5>
    Public Class Temperature
        ' Parses the temperature from a string in form
        ' [ws][sign]digits['F|'C][ws]
        Public Shared Function Parse(ByVal s As String) As Temperature
            Dim temp As New Temperature()

            If s.TrimEnd().EndsWith("'F") Then
                temp.Value = Double.Parse(s.Remove(s.LastIndexOf("'"c), 2))
            Else
                If s.TrimEnd().EndsWith("'C") Then
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
    '</snippet5>
End Namespace

Namespace Snippets6
    '<snippet6>
    Public Class Temperature
        ' Parses the temperature from a string in form
        ' [ws][sign]digits['F|'C][ws]
        Public Shared Function Parse(ByVal s As String, ByVal provider As IFormatProvider) As Temperature
            Dim temp As New Temperature()

            If s.TrimEnd().EndsWith("'F") Then
                temp.Value = Double.Parse(s.Remove(s.LastIndexOf("'"c), 2), provider)
            Else
                If s.TrimEnd().EndsWith("'C") Then
                    temp.Celsius = Double.Parse(s.Remove(s.LastIndexOf("'"c), 2), provider)
                Else
                    temp.Value = Double.Parse(s, provider)
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
    '</snippet6>
End Namespace

Namespace Snippets7
    '<snippet7>
    Public Class Temperature
        ' Parses the temperature from a string in form
        ' [ws][sign]digits['F|'C][ws]
        Public Shared Function Parse(ByVal s As String, ByVal styles As NumberStyles) As Temperature
            Dim temp As New Temperature()

            If s.TrimEnd().EndsWith("'F") Then
                temp.Value = Double.Parse(s.Remove(s.LastIndexOf("'"c), 2), styles)
            Else
                If s.TrimEnd().EndsWith("'C") Then
                    temp.Celsius = Double.Parse(s.Remove(s.LastIndexOf("'"c), 2), styles)
                Else
                    temp.Value = Double.Parse(s, styles)
                End If
            End If
            Return temp
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
    '</snippet7>
End Namespace

Namespace Snippets8
    '<snippet8>
    Public Class Temperature
        ' Parses the temperature from a string in form
        ' [ws][sign]digits['F|'C][ws]
        Public Shared Function Parse(ByVal s As String, ByVal styles As NumberStyles, ByVal provider As IFormatProvider) As Temperature
            Dim temp As New Temperature()

            If s.TrimEnd().EndsWith("'F") Then
                temp.Value = Double.Parse(s.Remove(s.LastIndexOf("'"c), 2), styles, provider)
            Else
                If s.TrimEnd().EndsWith("'C") Then
                    temp.Celsius = Double.Parse(s.Remove(s.LastIndexOf("'"c), 2), styles, provider)
                Else
                    temp.Value = Double.Parse(s, styles, provider)
                End If
            End If
            Return temp
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
    '</snippet8>
End Namespace
