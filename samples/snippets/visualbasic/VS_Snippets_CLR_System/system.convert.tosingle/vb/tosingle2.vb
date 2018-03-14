' Visual Basic .NET Document
Option Strict On

' <Snippet14>
Imports System.Globalization

Public Class Temperature : Implements IConvertible
   Private m_Temp As Single

   Public Sub New(temperature As Single)
      Me.m_Temp = temperature
   End Sub
   
   Public ReadOnly Property Celsius() As Single
      Get
         Return Me.m_Temp
      End Get   
   End Property
   
   Public ReadOnly Property Kelvin() As Single
      Get
         Return Me.m_Temp + 273.15F
      End Get
   End Property
   
   Public ReadOnly Property Fahrenheit() As Single
      Get
         Return CSng(Math.Round(Me.m_Temp * 9 / 5 + 32, 2))
      End Get      
   End Property
   
   Public Overrides Function ToString() As String
      Return m_Temp.ToString("N2") & " °C"
   End Function

   ' IConvertible implementations.
   Public Function GetTypeCode() As TypeCode _
                   Implements IConvertible.GetTypeCode
      Return TypeCode.Object
   End Function
   
   Public Function ToBoolean(provider As IFormatProvider) As Boolean _
                   Implements IConvertible.ToBoolean
      If m_Temp = 0 Then
         Return False
      Else
         Return True
      End If
   End Function 
   
   Public Function ToByte(provider As IFormatProvider) As Byte _
                   Implements IConvertible.ToByte
      If m_Temp < Byte.MinValue Or m_Temp > Byte.MaxValue Then
         Throw New OverflowException(String.Format("{0} is out of range of the Byte type.", _ 
                                                   Me.m_Temp)) 
      Else
         Return Convert.ToByte(Me.m_Temp)
      End If       
   End Function
   
   Public Function ToChar(provider As IFormatProvider) As Char _
                   Implements IConvertible.ToChar
      Throw New InvalidCastException("Temperature to Char conversion is not supported.")
   End Function 
   
   Public Function ToDateTime(provider As IFormatProvider) As Date _
                   Implements IConvertible.ToDateTime
      Throw New InvalidCastException("Temperature to DateTime conversion is not supported.")
   End Function
   
   Public Function ToDecimal(provider As IFormatProvider) As Decimal _
                   Implements IConvertible.ToDecimal
      Return Convert.ToDecimal(Me.m_Temp)
   End Function
   
   Public Function ToDouble(provider As IFormatProvider) As Double _
                   Implements IConvertible.ToDouble
      Return Convert.ToDouble(Me.m_Temp)
   End Function   
   
   Public Function ToInt16(provider As IFormatProvider) As Int16 _
                   Implements IConvertible.ToInt16
      If Me.m_Temp < Int16.MinValue Or Me.m_Temp > Int16.MaxValue Then
         Throw New OverflowException(String.Format("{0} is out of range of the Int16 type.", _
                                                   Me.m_Temp))
      Else
         Return Convert.ToInt16(Me.m_Temp)   
      End If
   End Function
   
   Public Function ToInt32(provider As IFormatProvider) As Int32 _
                   Implements IConvertible.ToInt32
      If Me.m_Temp < Int32.MinValue Or Me.m_Temp > Int32.MaxValue Then
         Throw New OverflowException(String.Format("{0} is out of range of the Int32 type.", _
                                                   Me.m_Temp))
      Else
         Return Convert.ToInt32(Me.m_Temp)
      End If      
   End Function
   
   Public Function ToInt64(provider As IFormatProvider) As Int64 _
                   Implements IConvertible.ToInt64
      If Me.m_Temp < Int64.MinValue Or Me.m_Temp > Int64.MaxValue Then
         Throw New OverflowException(String.Format("{0} is out of range of the Int64 type.", _
                                                   Me.m_Temp))
      Else
         Return Convert.ToInt64(Me.m_Temp)
      End If      
   End Function
   
   Public Function ToSByte(provider As IFormatProvider) As SByte _
                   Implements IConvertible.ToSByte
      If Me.m_Temp < SByte.MinValue Or Me.m_Temp > SByte.MaxValue Then
         Throw New OverflowException(String.Format("{0} is out of range of the SByte type.", _
                                                   Me.m_Temp))
      Else
         Return Convert.ToSByte(Me.m_Temp)
      End If      
   End Function

   Public Function ToSingle(provider As IFormatProvider) As Single _
                   Implements IConvertible.ToSingle
      Return Me.m_Temp
   End Function

   Public Overloads Function ToString(provider As IFormatProvider) As String _
                   Implements IConvertible.ToString
      Return m_Temp.ToString("N2", provider) & " °C"
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
            If GetType(Temperature).Equals(conversionType) Then
               Return Me
            Else
               Throw New InvalidCastException(String.Format("Conversion to a {0} is not supported.", _
                                                            conversionType.Name))
            End If 
         Case TypeCode.SByte
            Return Me.ToSByte(Nothing)
         Case TypeCode.Single
            Return Me.ToSingle(Nothing)
         Case TypeCode.String
            Return Me.ToString(provider)
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
      If Me.m_Temp < UInt16.MinValue Or Me.m_Temp > UInt16.MaxValue Then
         Throw New OverflowException(String.Format("{0} is out of range of the UInt16 type.", _
                                                   Me.m_Temp))
      Else
         Return Convert.ToUInt16(Me.m_Temp)
      End If   
   End Function

   Public Function ToUInt32(provider As IFormatProvider) As UInt32 _
                   Implements IConvertible.ToUInt32
      If Me.m_Temp < UInt32.MinValue Or Me.m_Temp > UInt32.MaxValue Then
         Throw New OverflowException(String.Format("{0} is out of range of the UInt32 type.", _
                                                   Me.m_Temp))
      Else
         Return Convert.ToUInt32(Me.m_Temp)
      End If   
   End Function
   
   Public Function ToUInt64(provider As IFormatProvider) As UInt64 _
                   Implements IConvertible.ToUInt64
      If Me.m_Temp < UInt64.MinValue Or Me.m_Temp > UInt64.MaxValue Then
         Throw New OverflowException(String.Format("{0} is out of range of the UInt64 type.", _
                                                   Me.m_Temp))
      Else
         Return Convert.ToUInt64(Me.m_temp)
      End If   
   End Function
End Class
' </Snippet14>

' <Snippet15>
Module Example
   Public Sub Main()
      Dim cold As New Temperature(-40)
      Dim freezing As New Temperature(0)
      Dim boiling As New Temperature(100)
      
      Console.WriteLine(Convert.ToInt32(cold, Nothing))
      Console.WriteLine(Convert.ToInt32(freezing, Nothing))
      Console.WriteLine(Convert.ToDouble(boiling, Nothing))
   End Sub
End Module
' The example displays the following output:
'       -40
'       0
'       100
' </Snippet15>
