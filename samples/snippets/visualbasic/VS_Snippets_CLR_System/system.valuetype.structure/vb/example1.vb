' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Numerics

Public Class Utility
   Public Enum NumericRelationship As Integer
      GreaterThan = 1
      EqualTo = 0
      LessThan = -1
   End Enum
      
   Public Shared Function Compare(value1 As ValueType, value2 As ValueType) _
                                  As NumericRelationship
      If Not IsNumeric(value1) Then 
         Throw New ArgumentException("value1 is not a number.")
      Else If Not IsNumeric(value2) Then
         Throw New ArgumentException("value2 is not a number.")
      Else
         ' Use BigInteger as common integral type
         If isInteger(value1) And IsInteger(value2) Then
            Dim bigint1 As BigInteger = CType(value1, BigInteger)
            Dim bigInt2 As BigInteger = CType(value2, BigInteger)
            Return CType(BigInteger.Compare(bigint1, bigint2), NumericRelationship)
         ' At least one value is floating point; use Double.
         Else   
            Dim dbl1, dbl2 As Double
            Try
               dbl1 = CDbl(value1)
            Catch e As OverflowException
               Console.WriteLine("value1 is outside the range of a Double.")
            End Try
               
            Try
               dbl2 = CDbl(value2)
            Catch e As OverflowException
               Console.WriteLine("value2 is outside the range of a Double.")
            End Try
            Return CType(dbl1.CompareTo(dbl2), NumericRelationship)
         End If
      End If
   End Function
   
   Public Shared Function IsInteger(value As ValueType) As Boolean         
      Return (TypeOf value Is SByte Or TypeOf value Is Int16 Or TypeOf value Is Int32 _
                 Or TypeOf value Is Int64 Or TypeOf value Is Byte Or TypeOf value Is UInt16 _ 
                 Or TypeOf value Is UInt32 Or TypeOf value Is UInt64 _
                 Or TypeOf value Is BigInteger) 
   End Function

   Public Shared Function IsFloat(value As ValueType) As Boolean         
      Return (TypeOf value Is Single Or TypeOf value Is Double Or TypeOf value Is Decimal)
   End Function

   Public Shared Function IsNumeric(value As ValueType) As Boolean
      Return TypeOf value Is Byte OrElse
         TypeOf value Is Int16 OrElse
         TypeOf value Is Int32 OrElse
         TypeOf value Is Int64 OrElse
         TypeOf value Is SByte OrElse
         TypeOf value Is UInt16 OrElse
         TypeOf value Is UInt32 OrElse
         TypeOf value Is UInt64 OrElse
         TypeOf value Is BigInteger OrElse
         TypeOf value Is Decimal OrElse
         TypeOf value Is Double OrElse
         TypeOf value Is Single
   End Function
End Class
' </Snippet1>

' <Snippet2>   
Module Example
   Public Sub Main()
      Console.WriteLine(Utility.IsNumeric(12))
      Console.WriteLine(Utility.IsNumeric(True))
      Console.WriteLine(Utility.IsNumeric("c"c))
      Console.WriteLine(Utility.IsNumeric(#01/01/2012#))
      Console.WriteLine(Utility.IsInteger(12.2))
      Console.WriteLine(Utility.IsInteger(123456789))
      Console.WriteLine(Utility.IsFloat(True))
      Console.WriteLine(Utility.IsFloat(12.2))
      Console.WriteLine(Utility.IsFloat(12))
      Console.WriteLine("{0} {1} {2}", 12.1, Utility.Compare(12.1, 12), 12)
   End Sub
End Module
' The example displays the following output:
'       True
'       False
'       False
'       False
'       False
'       True
'       False
'       True
'       False
'       12.1 GreaterThan 12
' </Snippet2>
