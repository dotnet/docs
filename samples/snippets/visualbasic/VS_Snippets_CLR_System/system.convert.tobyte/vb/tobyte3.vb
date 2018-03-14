' Visual Basic .NET Document
Option Strict On

' <Snippet12>
Imports System.Globalization

Public Enum SignBit As Integer
   Positive = 1
   Zero = 0
   Negative = -1
End Enum

Public Structure ByteString : Implements IConvertible
   Private signBit As SignBit
   Private byteString As String
   
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
         If value.Trim().Length > 2 Then
            Throw New ArgumentException("The string representation of a byte cannot have more than two characters.")
         Else
            byteString = value
         End If   
      End Set
      Get
         Return byteString
      End Get
   End Property
   
   ' IConvertible implementations.
   Public Function GetTypeCode() As TypeCode _
                   Implements IConvertible.GetTypeCode
      Return TypeCode.Object
   End Function
   
   Public Function ToBoolean(provider As IFormatProvider) As Boolean _
                   Implements IConvertible.ToBoolean
      If signBit = SignBit.Zero Then
         Return False
      Else
         Return True
      End If
   End Function 
   
   Public Function ToByte(provider As IFormatProvider) As Byte _
                   Implements IConvertible.ToByte
      If signBit = signBit.Negative Then
         Throw New OverflowException(String.Format("{0} is out of range of the Byte type.", Convert.ToSByte(byteString, 16))) 
      Else
         Return Byte.Parse(byteString, NumberStyles.HexNumber)
      End If       
   End Function
   
   Public Function ToChar(provider As IFormatProvider) As Char _
                   Implements IConvertible.ToChar
      If signBit = signBit.Negative Then 
         Throw New OverflowException(String.Format("{0} is out of range of the Char type.", Convert.ToSByte(byteString, 16)))
      Else
         Dim byteValue As Byte = Byte.Parse(Me.byteString, NumberStyles.HexNumber)
         Return Convert.ToChar(byteValue)
      End If                
   End Function 
   
   Public Function ToDateTime(provider As IFormatProvider) As Date _
                   Implements IConvertible.ToDateTime
      Throw New InvalidCastException("ByteString to DateTime conversion is not supported.")
   End Function
   
   Public Function ToDecimal(provider As IFormatProvider) As Decimal _
                   Implements IConvertible.ToDecimal
      If signBit = signBit.Negative Then
         Dim byteValue As SByte = SByte.Parse(byteString, NumberStyles.HexNumber)
         Return Convert.ToDecimal(byteValue)
      Else
         Dim byteValue As Byte = Byte.Parse(byteString, NumberStyles.HexNumber)
         Return Convert.ToDecimal(byteValue)
      End If
   End Function
   
   Public Function ToDouble(provider As IFormatProvider) As Double _
                   Implements IConvertible.ToDouble
      If signBit = signBit.Negative Then
         Return Convert.ToDouble(SByte.Parse(byteString, NumberStyles.HexNumber))
      Else
         Return Convert.ToDouble(Byte.Parse(byteString, NumberStyles.HexNumber))
      End If   
   End Function   
   
   Public Function ToInt16(provider As IFormatProvider) As Int16 _
                   Implements IConvertible.ToInt16
      If signBit = signBit.Negative Then
         Return Convert.ToInt16(SByte.Parse(byteString, NumberStyles.HexNumber))
      Else
         Return Convert.ToInt16(Byte.Parse(byteString, NumberStyles.HexNumber))
      End If   
   End Function
   
   Public Function ToInt32(provider As IFormatProvider) As Int32 _
                   Implements IConvertible.ToInt32
      If signBit = signBit.Negative Then
         Return Convert.ToInt32(SByte.Parse(byteString, NumberStyles.HexNumber))
      Else
         Return Convert.ToInt32(Byte.Parse(byteString, NumberStyles.HexNumber))
      End If   
   End Function
   
   Public Function ToInt64(provider As IFormatProvider) As Int64 _
                   Implements IConvertible.ToInt64
      If signBit = signBit.Negative Then
         Return Convert.ToInt64(SByte.Parse(byteString, NumberStyles.HexNumber))
      Else
         Return Convert.ToInt64(Byte.Parse(byteString, NumberStyles.HexNumber))
      End If   
   End Function
   
   Public Function ToSByte(provider As IFormatProvider) As SByte _
                   Implements IConvertible.ToSByte
      If signBit = SignBit.Positive Then
         Try
            Return Convert.ToSByte(Byte.Parse(byteString, NumberStyles.HexNumber))
         Catch e As OverflowException
            Throw New OverflowException(String.Format("{0} is outside the range of the SByte type.", _
                                                   Byte.Parse(byteString, NumberStyles.HexNumber)), e)   
         End Try
      Else
         Return SByte.Parse(byteString, NumberStyles.HexNumber)
      End If
   End Function

   Public Function ToSingle(provider As IFormatProvider) As Single _
                   Implements IConvertible.ToSingle
      If signBit = signBit.Negative Then
         Return Convert.ToSingle(SByte.Parse(byteString, NumberStyles.HexNumber))
      Else
         Return Convert.ToSingle(Byte.Parse(byteString, NumberStyles.HexNumber))
      End If   
   End Function

   Public Overloads Function ToString(provider As IFormatProvider) As String _
                   Implements IConvertible.ToString
      Return Me.byteString
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
            If GetType(ByteString).Equals(conversionType) Then
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
      If signBit = signBit.Negative Then
         Throw New OverflowException(String.Format("{0} is outside the range of the UInt16 type.", _
                                                   SByte.Parse(byteString, NumberStyles.HexNumber)))
      Else
         Return Convert.ToUInt16(Byte.Parse(byteString, NumberStyles.HexNumber))
      End If   
   End Function

   Public Function ToUInt32(provider As IFormatProvider) As UInt32 _
                   Implements IConvertible.ToUInt32
      If signBit = signBit.Negative Then
         Throw New OverflowException(String.Format("{0} is outside the range of the UInt32 type.", _
                                                   SByte.Parse(byteString, NumberStyles.HexNumber)))
      Else
         Return Convert.ToUInt32(Byte.Parse(byteString, NumberStyles.HexNumber))
      End If   
   End Function
   
   Public Function ToUInt64(provider As IFormatProvider) As UInt64 _
                   Implements IConvertible.ToUInt64
      If signBit = signBit.Negative Then
         Throw New OverflowException(String.Format("{0} is outside the range of the UInt64 type.", _
                                                   SByte.Parse(byteString, NumberStyles.HexNumber)))
      Else
         Return Convert.ToUInt64(Byte.Parse(byteString, NumberStyles.HexNumber))
      End If   
   End Function
   
End Structure
' </Snippet12>

' <Snippet13>
Module modMain
   Public Sub Main()
      Dim positiveByte As Byte = 216
      Dim negativeByte As SByte = -101
      
      
      Dim positiveString As New ByteString()
      positiveString.Sign = CType(Math.Sign(positiveByte), SignBit)
      positiveString.Value = positiveByte.ToString("X2")
      
      Dim negativeString As New ByteString()
      negativeString.Sign = CType(Math.Sign(negativeByte), SignBit)
      negativeString.Value = negativeByte.ToString("X2")
      
      Try
         Console.WriteLine("'{0}' converts to {1}.", positiveString.Value, Convert.ToByte(positiveString))
      Catch e As OverflowException
         Console.WriteLine("0x{0} is outside the range of the Byte type.", positiveString.Value)
      End Try

      Try
         Console.WriteLine("'{0}' converts to {1}.", negativeString.Value, Convert.ToByte(negativeString))
      Catch e As OverflowException
         Console.WriteLine("0x{0} is outside the range of the Byte type.", negativeString.Value)
      End Try   
   End Sub
End Module
' The example dosplays the following output:
'       'D8' converts to 216.
'       0x9B is outside the range of the Byte type.
' </Snippet13>
