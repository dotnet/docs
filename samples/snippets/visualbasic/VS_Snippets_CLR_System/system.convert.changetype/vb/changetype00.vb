' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Public Class InterceptProvider : Implements IFormatProvider
   Public Function GetFormat(formatType As Type) As Object _
          Implements IFormatProvider.GetFormat
      If formatType.Equals(GetType(NumberFormatInfo)) Then
         Console.WriteLine("   Returning a fr-FR numeric format provider.")
         Return New CultureInfo("fr-FR").NumberFormat
      ElseIf formatType.Equals(GetType(DateTimeFormatInfo)) Then
         Console.WriteLine("   Returning an en-US date/time format provider.")
         Return New CultureInfo("en-US").DateTimeFormat
      Else
         Console.WriteLine("   Requesting a format provider of {0}.", formatType.Name)
         Return Nothing
      End If
   End Function
End Class

Module Example
   Public Sub Main()
      Dim values() As Object = { 103.5r, #12/26/2010 2:34PM# }
      Dim provider As New InterceptProvider()
      
      ' Convert value to each of the types represented in TypeCode enum.
      For Each value As Object In values
         ' Iterate types in TypeCode enum.
         For Each enumType As TypeCode In DirectCast([Enum].GetValues(GetType(TypeCode)), TypeCode())         
            If enumType = TypeCode.DbNull Or enumType = TypeCode.Empty Then Continue For
            
            Try
               Console.WriteLine("{0} ({1}) --> {2} ({3}).", _
                                 value, value.GetType().Name, _
                                 Convert.ChangeType(value, enumType, provider), _
                                 enumType.ToString())
            Catch e As InvalidCastException
               Console.WriteLine("Cannot convert a {0} to a {1}", _
                                 value.GetType().Name, enumType.ToString())
            Catch e As OverflowException
               Console.WriteLine("Overflow: {0} is out of the range of a {1}", _
                                 value, enumType.ToString())
            End Try
         Next
         Console.WriteLine()
      Next
   End Sub
End Module
' The example displays the following output:
'    103.5 (Double) --> 103.5 (Object).
'    103.5 (Double) --> True (Boolean).
'    Cannot convert a Double to a Char
'    103.5 (Double) --> 104 (SByte).
'    103.5 (Double) --> 104 (Byte).
'    103.5 (Double) --> 104 (Int16).
'    103.5 (Double) --> 104 (UInt16).
'    103.5 (Double) --> 104 (Int32).
'    103.5 (Double) --> 104 (UInt32).
'    103.5 (Double) --> 104 (Int64).
'    103.5 (Double) --> 104 (UInt64).
'    103.5 (Double) --> 103.5 (Single).
'    103.5 (Double) --> 103.5 (Double).
'    103.5 (Double) --> 103.5 (Decimal).
'    Cannot convert a Double to a DateTime
'       Returning a fr-FR numeric format provider.
'    103.5 (Double) --> 103,5 (String).
'    
'    12/26/2010 2:34:00 PM (DateTime) --> 12/26/2010 2:34:00 PM (Object).
'    Cannot convert a DateTime to a Boolean
'    Cannot convert a DateTime to a Char
'    Cannot convert a DateTime to a SByte
'    Cannot convert a DateTime to a Byte
'    Cannot convert a DateTime to a Int16
'    Cannot convert a DateTime to a UInt16
'    Cannot convert a DateTime to a Int32
'    Cannot convert a DateTime to a UInt32
'    Cannot convert a DateTime to a Int64
'    Cannot convert a DateTime to a UInt64
'    Cannot convert a DateTime to a Single
'    Cannot convert a DateTime to a Double
'    Cannot convert a DateTime to a Decimal
'    12/26/2010 2:34:00 PM (DateTime) --> 12/26/2010 2:34:00 PM (DateTime).
'       Returning an en-US date/time format provider.
'    12/26/2010 2:34:00 PM (DateTime) --> 12/26/2010 2:34:00 PM (String).
' </Snippet1>
      
      

