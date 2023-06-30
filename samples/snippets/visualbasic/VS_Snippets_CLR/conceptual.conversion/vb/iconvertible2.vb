' Visual Basic .NET Document
Option Strict On

' <Snippet10>
Public MustInherit Class Temperature
    Implements IConvertible

    Protected temp As Decimal

    Public Sub New(temperature As Decimal)
        Me.temp = temperature
    End Sub

    Public Property Value As Decimal
        Get
            Return Me.temp
        End Get
        Set
            Me.temp = Value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return temp.ToString() & "º"
    End Function

    ' IConvertible implementations.
    Public Function GetTypeCode() As TypeCode Implements IConvertible.GetTypeCode
        Return TypeCode.Object
    End Function

    Public Function ToBoolean(provider As IFormatProvider) As Boolean Implements IConvertible.ToBoolean
        Throw New InvalidCastException(String.Format("Temperature-to-Boolean conversion is not supported."))
    End Function

    Public Function ToByte(provider As IFormatProvider) As Byte Implements IConvertible.ToByte
        If temp < Byte.MinValue Or temp > Byte.MaxValue Then
            Throw New OverflowException(String.Format("{0} is out of range of the Byte data type.", temp))
        Else
            Return CByte(temp)
        End If
    End Function

    Public Function ToChar(provider As IFormatProvider) As Char Implements IConvertible.ToChar
        Throw New InvalidCastException("Temperature-to-Char conversion is not supported.")
    End Function

    Public Function ToDateTime(provider As IFormatProvider) As DateTime Implements IConvertible.ToDateTime
        Throw New InvalidCastException("Temperature-to-DateTime conversion is not supported.")
    End Function

    Public Function ToDecimal(provider As IFormatProvider) As Decimal Implements IConvertible.ToDecimal
        Return temp
    End Function

    Public Function ToDouble(provider As IFormatProvider) As Double Implements IConvertible.ToDouble
        Return CDbl(temp)
    End Function

    Public Function ToInt16(provider As IFormatProvider) As Int16 Implements IConvertible.ToInt16
        If temp < Int16.MinValue Or temp > Int16.MaxValue Then
            Throw New OverflowException(String.Format("{0} is out of range of the Int16 data type.", temp))
        End If
        Return CShort(Math.Round(temp))
    End Function

    Public Function ToInt32(provider As IFormatProvider) As Int32 Implements IConvertible.ToInt32
        If temp < Int32.MinValue Or temp > Int32.MaxValue Then
            Throw New OverflowException(String.Format("{0} is out of range of the Int32 data type.", temp))
        End If
        Return CInt(Math.Round(temp))
    End Function

    Public Function ToInt64(provider As IFormatProvider) As Int64 Implements IConvertible.ToInt64
        If temp < Int64.MinValue Or temp > Int64.MaxValue Then
            Throw New OverflowException(String.Format("{0} is out of range of the Int64 data type.", temp))
        End If
        Return CLng(Math.Round(temp))
    End Function

    Public Function ToSByte(provider As IFormatProvider) As SByte Implements IConvertible.ToSByte
        If temp < SByte.MinValue Or temp > SByte.MaxValue Then
            Throw New OverflowException(String.Format("{0} is out of range of the SByte data type.", temp))
        Else
            Return CSByte(temp)
        End If
    End Function

    Public Function ToSingle(provider As IFormatProvider) As Single Implements IConvertible.ToSingle
        Return CSng(temp)
    End Function

    Public Overridable Overloads Function ToString(provider As IFormatProvider) As String Implements IConvertible.ToString
        Return temp.ToString(provider) & " °C"
    End Function

    ' If conversionType is a implemented by another IConvertible method, call it.
    Public Overridable Function ToType(conversionType As Type, provider As IFormatProvider) As Object Implements IConvertible.ToType
        Select Case Type.GetTypeCode(conversionType)
            Case TypeCode.Boolean
                Return Me.ToBoolean(provider)
            Case TypeCode.Byte
                Return Me.ToByte(provider)
            Case TypeCode.Char
                Return Me.ToChar(provider)
            Case TypeCode.DateTime
                Return Me.ToDateTime(provider)
            Case TypeCode.Decimal
                Return Me.ToDecimal(provider)
            Case TypeCode.Double
                Return Me.ToDouble(provider)
            Case TypeCode.Empty
                Throw New NullReferenceException("The target type is null.")
            Case TypeCode.Int16
                Return Me.ToInt16(provider)
            Case TypeCode.Int32
                Return Me.ToInt32(provider)
            Case TypeCode.Int64
                Return Me.ToInt64(provider)
            Case TypeCode.Object
                ' Leave conversion of non-base types to derived classes.
                Throw New InvalidCastException(String.Format("Cannot convert from Temperature to {0}.", _
                                               conversionType.Name))
            Case TypeCode.SByte
                Return Me.ToSByte(provider)
            Case TypeCode.Single
                Return Me.ToSingle(provider)
            Case TypeCode.String
                Return Me.ToString(provider)
            Case TypeCode.UInt16
                Return Me.ToUInt16(provider)
            Case TypeCode.UInt32
                Return Me.ToUInt32(provider)
            Case TypeCode.UInt64
                Return Me.ToUInt64(provider)
            Case Else
                Throw New InvalidCastException("Conversion not supported.")
        End Select
    End Function

    Public Function ToUInt16(provider As IFormatProvider) As UInt16 Implements IConvertible.ToUInt16
        If temp < UInt16.MinValue Or temp > UInt16.MaxValue Then
            Throw New OverflowException(String.Format("{0} is out of range of the UInt16 data type.", temp))
        End If
        Return CUShort(Math.Round(temp))
    End Function

    Public Function ToUInt32(provider As IFormatProvider) As UInt32 Implements IConvertible.ToUInt32
        If temp < UInt32.MinValue Or temp > UInt32.MaxValue Then
            Throw New OverflowException(String.Format("{0} is out of range of the UInt32 data type.", temp))
        End If
        Return CUInt(Math.Round(temp))
    End Function

    Public Function ToUInt64(provider As IFormatProvider) As UInt64 Implements IConvertible.ToUInt64
        If temp < UInt64.MinValue Or temp > UInt64.MaxValue Then
            Throw New OverflowException(String.Format("{0} is out of range of the UInt64 data type.", temp))
        End If
        Return CULng(Math.Round(temp))
    End Function
End Class

Public Class TemperatureCelsius : Inherits Temperature : Implements IConvertible
    Public Sub New(value As Decimal)
        MyBase.New(value)
    End Sub

    ' Override ToString methods.
    Public Overrides Function ToString() As String
        Return Me.ToString(Nothing)
    End Function

    Public Overrides Function ToString(provider As IFormatProvider) As String
        Return temp.ToString(provider) + "°C"
    End Function

    ' If conversionType is a implemented by another IConvertible method, call it.
    Public Overrides Function ToType(conversionType As Type, provider As IFormatProvider) As Object
        ' For non-objects, call base method.
        If Type.GetTypeCode(conversionType) <> TypeCode.Object Then
            Return MyBase.ToType(conversionType, provider)
        Else
            If conversionType.Equals(GetType(TemperatureCelsius)) Then
                Return Me
            ElseIf conversionType.Equals(GetType(TemperatureFahrenheit))
                Return New TemperatureFahrenheit(CDec(Me.temp * 9 / 5 + 32))
                ' Unspecified object type: throw an InvalidCastException.
            Else
                Throw New InvalidCastException(String.Format("Cannot convert from Temperature to {0}.", _
                                               conversionType.Name))
            End If
        End If
    End Function
End Class

Public Class TemperatureFahrenheit : Inherits Temperature : Implements IConvertible
    Public Sub New(value As Decimal)
        MyBase.New(value)
    End Sub

    ' Override ToString methods.
    Public Overrides Function ToString() As String
        Return Me.ToString(Nothing)
    End Function

    Public Overrides Function ToString(provider As IFormatProvider) As String
        Return temp.ToString(provider) + "°F"
    End Function

    Public Overrides Function ToType(conversionType As Type, provider As IFormatProvider) As Object
        ' For non-objects, call base method.
        If Type.GetTypeCode(conversionType) <> TypeCode.Object Then
            Return MyBase.ToType(conversionType, provider)
        Else
            ' Handle conversion between derived classes.
            If conversionType.Equals(GetType(TemperatureFahrenheit)) Then
                Return Me
            ElseIf conversionType.Equals(GetType(TemperatureCelsius))
                Return New TemperatureCelsius(CDec((MyBase.temp - 32) * 5 / 9))
                ' Unspecified object type: throw an InvalidCastException.
            Else
                Throw New InvalidCastException(String.Format("Cannot convert from Temperature to {0}.", _
                                               conversionType.Name))
            End If
        End If
    End Function
End Class
' </Snippet10>

Module ConvertibleExampleTwo
    Public Sub Main()
        ' <Snippet11>
        Dim tempC1 As New TemperatureCelsius(0)
        Dim tempF1 As TemperatureFahrenheit = CType(Convert.ChangeType(tempC1, GetType(TemperatureFahrenheit), Nothing), TemperatureFahrenheit)
        Console.WriteLine("{0} equals {1}.", tempC1, tempF1)
        Dim tempC2 As TemperatureCelsius = CType(Convert.ChangeType(tempC1, GetType(TemperatureCelsius), Nothing), TemperatureCelsius)
        Console.WriteLine("{0} equals {1}.", tempC1, tempC2)
        Dim tempF2 As New TemperatureFahrenheit(212)
        Dim tempC3 As TEmperatureCelsius = CType(Convert.ChangeType(tempF2, GEtType(TemperatureCelsius), Nothing), TemperatureCelsius)
        Console.WriteLine("{0} equals {1}.", tempF2, tempC3)
        Dim tempF3 As TemperatureFahrenheit = CType(Convert.ChangeType(tempF2, GetType(TemperatureFahrenheit), Nothing), TemperatureFahrenheit)
        Console.WriteLine("{0} equals {1}.", tempF2, tempF3)
        ' The example displays the following output:
        '       0°C equals 32°F.
        '       0°C equals 0°C.
        '       212°F equals 100°C.
        '       212°F equals 212°F.
        ' </Snippet11>
    End Sub
End Module

