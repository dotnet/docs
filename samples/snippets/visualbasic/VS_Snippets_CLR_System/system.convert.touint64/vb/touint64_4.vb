' Visual Basic .NET Document
Option Strict On

' <Snippet17>
Imports System.Globalization
Imports System.Text.RegularExpressions

Public Enum SignBit As Integer
   Positive = 1
   Zero = 0
   Negative = -1
End Enum

Public Structure HexString : Implements IConvertible
   Private signBit As SignBit
   Private hexString As String
   
   Public Property Sign As SignBit
      Set
         signBit = value
      End Set
      Get
         Return signBit
      End Get
   End Property
   
   Public Property Value As String
      Set
         If value.Trim().Length > 16 Then
            Throw New ArgumentException("The hexadecimal representation of a 64-bit integer cannot have more than 16 characters.")
         ElseIf Not Regex.IsMatch(value, "([0-9,A-F]){1,8}", RegexOptions.IgnoreCase) Then
            Throw New ArgumentException("The hexadecimal representation of a 64-bit integer contains invalid characters.")             
         Else
            hexString = value
         End If   
      End Set
      Get
         Return hexString
      End Get
   End Property
   
   ' IConvertible implementations.
   Public Function GetTypeCode() As TypeCode _
                   Implements IConvertible.GetTypeCode
      Return TypeCode.Object
   End Function
   
   Public Function ToBoolean(provider As IFormatProvider) As Boolean _
                   Implements IConvertible.ToBoolean
      Return signBit <> SignBit.Zero
   End Function 
   
   Public Function ToByte(provider As IFormatProvider) As Byte _
                   Implements IConvertible.ToByte
      If signBit = SignBit.Negative Then
         Throw New OverflowException(String.Format("{0} is out of range of the Byte type.", Convert.ToInt64(hexString, 16))) 
      Else
         Try
            Return Byte.Parse(hexString, NumberStyles.HexNumber)
         Catch e As OverflowException
            Throw New OverflowException(String.Format("{0} is out of range of the Byte type.", Convert.ToUInt64(hexString, 16)), e)
         End Try   
      End If       
   End Function
   
   Public Function ToChar(provider As IFormatProvider) As Char _
                   Implements IConvertible.ToChar
      If signBit = SignBit.Negative Then 
         Throw New OverflowException(String.Format("{0} is out of range of the Char type.", Convert.ToInt64(hexString, 16)))
      End If
      
      Try
         Dim codePoint As UInt16 = UInt16.Parse(Me.hexString, NumberStyles.HexNumber)
         Return Convert.ToChar(codePoint)
      Catch e As OverflowException
         Throw New OverflowException(String.Format("{0} is out of range of the Char type.", Convert.ToUInt64(hexString, 16)))
      End Try      
   End Function 
   
   Public Function ToDateTime(provider As IFormatProvider) As Date _
                   Implements IConvertible.ToDateTime
      Throw New InvalidCastException("Hexadecimal to DateTime conversion is not supported.")
   End Function
   
   Public Function ToDecimal(provider As IFormatProvider) As Decimal _
                   Implements IConvertible.ToDecimal
      If signBit = SignBit.Negative Then
         Dim hexValue As Long = Int64.Parse(hexString, NumberStyles.HexNumber)
         Return Convert.ToDecimal(hexValue)
      Else
         Dim hexValue As ULong = UInt64.Parse(hexString, NumberStyles.HexNumber)
         Return Convert.ToDecimal(hexValue)
      End If
   End Function
   
   Public Function ToDouble(provider As IFormatProvider) As Double _
                   Implements IConvertible.ToDouble
      If signBit = SignBit.Negative Then
         Return Convert.ToDouble(Int64.Parse(hexString, NumberStyles.HexNumber))
      Else
         Return Convert.ToDouble(UInt64.Parse(hexString, NumberStyles.HexNumber))
      End If   
   End Function   
   
   Public Function ToInt16(provider As IFormatProvider) As Int16 _
                   Implements IConvertible.ToInt16
      If signBit = SignBit.Negative Then
         Try
            Return Convert.ToInt16(Int64.Parse(hexString, NumberStyles.HexNumber))
         Catch e As OverflowException
            Throw New OverflowException(String.Format("{0} is out of range of the Int16 type.", Convert.ToInt64(hexString, 16)), e)
         End Try
      Else
         Try
            Return Convert.ToInt16(UInt64.Parse(hexString, NumberStyles.HexNumber))
         Catch e As OverflowException
            Throw New OverflowException(String.Format("{0} is out of range of the Int16 type.", Convert.ToUInt64(hexString, 16)), e)
         End Try
      End If   
   End Function
   
   Public Function ToInt32(provider As IFormatProvider) As Int32 _
                   Implements IConvertible.ToInt32
      If signBit = SignBit.Negative Then
         Try
            Return Convert.ToInt32(Int64.Parse(hexString, NumberStyles.HexNumber))
         Catch e As OverflowException
            Throw New OverflowException(String.Format("{0} is out of range of the Int32 type.", Convert.ToUInt64(hexString, 16)), e)
         End Try
      Else
         Try
            Return Convert.ToInt32(UInt64.Parse(hexString, NumberStyles.HexNumber))
         Catch e As OverflowException
            Throw New OverflowException(String.Format("{0} is out of range of the Int32 type.", Convert.ToUInt64(hexString, 16)), e)
         End Try   
      End If   
   End Function
   
   Public Function ToInt64(provider As IFormatProvider) As Int64 _
                   Implements IConvertible.ToInt64
      If signBit = SignBit.Negative Then
         Return Int64.Parse(hexString, NumberStyles.HexNumber)
      Else
         Try
            Return Convert.ToInt64(UInt64.Parse(hexString, NumberStyles.HexNumber))
         Catch e As OverflowException
            Throw New OverflowException(String.Format("{0} is out of range of the Int64 type.", Convert.ToUInt64(hexString, 16)), e)
         End Try
      End If   
   End Function
   
   Public Function ToSByte(provider As IFormatProvider) As SByte _
                   Implements IConvertible.ToSByte
      If signBit = SignBit.Negative Then
         Try
            Return Convert.ToSByte(Int64.Parse(hexString, NumberStyles.HexNumber))
         Catch e As OverflowException
            Throw New OverflowException(String.Format("{0} is outside the range of the SByte type.", _
                                                      Int64.Parse(hexString, NumberStyles.HexNumber), e))
         End Try
      Else
         Try
            Return Convert.ToSByte(UInt64.Parse(hexString, NumberStyles.HexNumber))
         Catch e As OverflowException
            Throw New OverflowException(String.Format("{0} is outside the range of the SByte type.", _
                                                    UInt64.Parse(hexString, NumberStyles.HexNumber)), e)
         End Try   
      End If
   End Function

   Public Function ToSingle(provider As IFormatProvider) As Single _
                   Implements IConvertible.ToSingle
      If signBit = SignBit.Negative Then
         Return Convert.ToSingle(Int64.Parse(hexString, NumberStyles.HexNumber))
      Else
         Return Convert.ToSingle(UInt64.Parse(hexString, NumberStyles.HexNumber))
      End If   
   End Function

   Public Overloads Function ToString(provider As IFormatProvider) As String _
                   Implements IConvertible.ToString
      Return "0x" & Me.hexString
   End Function
   
   Public Function ToType(conversionType As Type, provider As IFormatProvider) As Object _
                   Implements IConvertible.ToType
      Select Case Type.GetTypeCode(conversionType)
         Case TypeCode.Boolean 
            Return Me.ToBoolean(Nothing)
         Case TypeCode.Byte
            Return Me.ToByte(Nothing)
         Case TypeCode.Char
            Return Me.ToChar(Nothing)
         Case TypeCode.DateTime
            Return Me.ToDateTime(Nothing)
         Case TypeCode.Decimal
            Return Me.ToDecimal(Nothing)
         Case TypeCode.Double
            Return Me.ToDouble(Nothing)
         Case TypeCode.Int16
            Return Me.ToInt16(Nothing)
         Case TypeCode.Int32
            Return Me.ToInt32(Nothing)
         Case TypeCode.Int64
            Return Me.ToInt64(Nothing)
         Case TypeCode.Object
            If GetType(HexString).Equals(conversionType) Then
               Return Me
            Else
               Throw New InvalidCastException(String.Format("Conversion to a {0} is not supported.", conversionType.Name))
            End If 
         Case TypeCode.SByte
            Return Me.ToSByte(Nothing)
         Case TypeCode.Single
            Return Me.ToSingle(Nothing)
         Case TypeCode.String
            Return Me.ToString(Nothing)
         Case TypeCode.UInt16
            Return Me.ToUInt16(Nothing)
         Case TypeCode.UInt32
            Return Me.ToUInt32(Nothing)
         Case TypeCode.UInt64
            Return Me.ToUInt64(Nothing)   
         Case Else
            Throw New InvalidCastException(String.Format("Conversion to {0} is not supported.", conversionType.Name))   
      End Select
   End Function
   
   Public Function ToUInt16(provider As IFormatProvider) As UInt16 _
                   Implements IConvertible.ToUInt16
      If signBit = SignBit.Negative Then
         Throw New OverflowException(String.Format("{0} is outside the range of the UInt16 type.", _
                                                   Int64.Parse(hexString, NumberStyles.HexNumber)))
      Else
         Try
            Return Convert.ToUInt16(UInt64.Parse(hexString, NumberStyles.HexNumber))
         Catch e As OverflowException
            Throw New OverflowException(String.Format("{0} is out of range of the UInt16 type.", Convert.ToUInt64(hexString, 16)), e)
         End Try            
      End If   
   End Function

   Public Function ToUInt32(provider As IFormatProvider) As UInt32 _
                   Implements IConvertible.ToUInt32
      If signBit = SignBit.Negative Then
         Throw New OverflowException(String.Format("{0} is outside the range of the UInt32 type.", _
                                                   Int64.Parse(hexString, NumberStyles.HexNumber)))
      Else
         Try
            Return Convert.ToUInt32(UInt64.Parse(hexString, NumberStyles.HexNumber))
         Catch e As OverflowException
         Throw New OverflowException(String.Format("{0} is outside the range of the UInt32 type.", _
                                                   UInt64.Parse(hexString, NumberStyles.HexNumber)))
         End Try   
      End If   
   End Function
   
   Public Function ToUInt64(provider As IFormatProvider) As UInt64 _
                   Implements IConvertible.ToUInt64
      If signBit = SignBit.Negative Then
         Throw New OverflowException(String.Format("{0} is outside the range of the UInt64 type.", _
                                                   Int64.Parse(hexString, NumberStyles.HexNumber)))
      Else
         Return Convert.ToUInt64(hexString, 16)
      End If   
   End Function
End Structure
' </Snippet17>

' <Snippet18>
Module Example
   Public Sub Main()
      Dim positiveValue As UInt64 = CULng(UInt64.MaxValue - 100000)
      Dim negativeValue As Int64 = -1
      
      
      Dim positiveString As New HexString()
      positiveString.Sign = CType(Math.Sign(positiveValue), SignBit)
      positiveString.Value = positiveValue.ToString("X")
      
      Dim negativeString As New HexString()
      negativeString.Sign = CType(Math.Sign(negativeValue), SignBit)
      negativeString.Value = negativeValue.ToString("X")
      
      Try
         Console.WriteLine("0x{0} converts to {1}.", positiveString.Value, Convert.ToUInt64(positiveString))
      Catch e As OverflowException
         Console.WriteLine("{0} is outside the range of the UInt64 type.", _
                           Int64.Parse(positiveString.Value, NumberStyles.HexNumber))
      End Try

      Try
         Console.WriteLine("0x{0} converts to {1}.", negativeString.Value, Convert.ToUInt64(negativeString))
      Catch e As OverflowException
         Console.WriteLine("{0} is outside the range of the UInt64 type.", _
                           Int64.Parse(negativeString.Value, NumberStyles.HexNumber))
      End Try   
   End Sub
End Module
' The example dosplays the following output:
'       0xFFFFFFFFFFFE795F converts to 18446744073709451615.
'       -1 is outside the range of the UInt64 type.
' </Snippet18>
