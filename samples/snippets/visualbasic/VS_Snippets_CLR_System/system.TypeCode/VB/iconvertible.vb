'<snippet1>
Imports System

Module Module1

    Public Class Complex
        Implements IConvertible
        Private x As Double
        Private y As Double


        Public Sub New(ByVal x As Double, ByVal y As Double)
            Me.x = x
            Me.y = y
        End Sub 'New


        Public Function GetTypeCode() As TypeCode Implements IConvertible.GetTypeCode
            Return TypeCode.Object
        End Function


        Function ToBoolean(ByVal provider As IFormatProvider) As Boolean Implements IConvertible.ToBoolean
            If x <> 0 Or y <> 0 Then
                Return True
            Else
                Return False
            End If
        End Function

        Function GetDoubleValue() As Double
            Return Math.Sqrt((x * x + y * y))
        End Function


        Function ToByte(ByVal provider As IFormatProvider) As Byte Implements IConvertible.ToByte
            Return Convert.ToByte(GetDoubleValue())
        End Function


        Function ToChar(ByVal provider As IFormatProvider) As Char Implements IConvertible.ToChar
            Return Convert.ToChar(GetDoubleValue())
        End Function


        Function ToDateTime(ByVal provider As IFormatProvider) As DateTime Implements IConvertible.ToDateTime
            Return Convert.ToDateTime(GetDoubleValue())
        End Function


        Function ToDecimal(ByVal provider As IFormatProvider) As Decimal Implements IConvertible.ToDecimal
            Return Convert.ToDecimal(GetDoubleValue())
        End Function


        Function ToDouble(ByVal provider As IFormatProvider) As Double Implements IConvertible.ToDouble
            Return GetDoubleValue()
        End Function


        Function ToInt16(ByVal provider As IFormatProvider) As Short Implements IConvertible.ToInt16
            Return Convert.ToInt16(GetDoubleValue())
        End Function


        Function ToInt32(ByVal provider As IFormatProvider) As Integer Implements IConvertible.ToInt32
            Return Convert.ToInt32(GetDoubleValue())
        End Function


        Function ToInt64(ByVal provider As IFormatProvider) As Long Implements IConvertible.ToInt64
            Return Convert.ToInt64(GetDoubleValue())
        End Function


        Function ToSByte(ByVal provider As IFormatProvider) As SByte Implements IConvertible.ToSByte
            Return Convert.ToSByte(GetDoubleValue())
        End Function


        Function ToSingle(ByVal provider As IFormatProvider) As Single Implements IConvertible.ToSingle
            Return Convert.ToSingle(GetDoubleValue())
        End Function


        Overloads Function ToString(ByVal provider As IFormatProvider) As String Implements IConvertible.ToString
            Return "( " + x.ToString() + " , " + y.ToString() + " )"
        End Function


        Function ToType(ByVal conversionType As Type, ByVal provider As IFormatProvider) As Object Implements IConvertible.ToType
            Return Convert.ChangeType(GetDoubleValue(), conversionType)
        End Function


        Function ToUInt16(ByVal provider As IFormatProvider) As UInt16 Implements IConvertible.ToUInt16
            Return Convert.ToUInt16(GetDoubleValue())
        End Function


        Function ToUInt32(ByVal provider As IFormatProvider) As UInt32 Implements IConvertible.ToUInt32
            Return Convert.ToUInt32(GetDoubleValue())
        End Function


        Function ToUInt64(ByVal provider As IFormatProvider) As UInt64 Implements IConvertible.ToUInt64
            Return Convert.ToUInt64(GetDoubleValue())
        End Function

    End Class


    Sub Main()
        Dim testComplex As New Complex(4, 7)

        WriteObjectInfo(testComplex)
        WriteObjectInfo(Convert.ToBoolean(testComplex))
        WriteObjectInfo(Convert.ToDecimal(testComplex))
        WriteObjectInfo(Convert.ToString(testComplex))

    End Sub

'<snippet2>
    Sub WriteObjectInfo(ByVal testObject As Object)
        Dim typeCode As TypeCode = Type.GetTypeCode(testObject.GetType())

        Select Case typeCode
            Case typeCode.Boolean
                Console.WriteLine("Boolean: {0}", testObject)

            Case typeCode.Double
                Console.WriteLine("Double: {0}", testObject)

            Case Else
                Console.WriteLine("{0}: {1}", typeCode.ToString(), testObject)
        End Select
    End Sub
'</snippet2>

End Module

' This code example produces the following results:
'
' Object: ConsoleApplication2.Complex
' Boolean: True
' Decimal: 8.06225774829855
' String: ( 4 , 7 )
'
'</snippet1>
