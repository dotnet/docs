Option Strict On

' <Snippet1>
Imports System.Globalization
Imports System.Numerics

Public Class BinaryFormatter : Implements IFormatProvider, ICustomFormatter
   ' IFormatProvider.GetFormat implementation.
   Public Function GetFormat(formatType As Type) As Object _
                   Implements IFormatProvider.GetFormat
      ' Determine whether custom formatting object is requested.
      If formatType Is GetType(ICustomFormatter) Then
         Return Me
      Else
         Return Nothing
      End If
   End Function   

   ' Format number in binary (B), octal (O), or hexadecimal (H).
   Public Function Format(fmt As String, arg As Object, _
                          formatProvider As IFormatProvider) As String _
                   Implements ICustomFormatter.Format

     ' Handle format string.
      Dim base As Integer
      ' Handle null or empty format string, string with precision specifier.
      Dim thisFmt As String = String.Empty
      ' Extract first character of format string (precision specifiers
      ' are not supported by BinaryFormatter).
      If Not String.IsNullOrEmpty(fmt) Then
         thisFmt = CStr(IIf(fmt.Length > 1, fmt.Substring(0, 1), fmt))
      End If
         


      ' Get a byte array representing the numeric value.
      Dim bytes() As Byte
      If TypeOf(arg) Is SByte Then
         Dim byteString As String = CType(arg, SByte).ToString("X2")
         bytes = New Byte(0) { Byte.Parse(byteString, System.Globalization.NumberStyles.HexNumber ) }
      ElseIf TypeOf(arg) Is Byte Then
         bytes = New Byte(0) { CType(arg, Byte) }
      ElseIf TypeOf(arg) Is Int16 Then
         bytes = BitConverter.GetBytes(CType(arg, Int16))
      ElseIf TypeOf(arg) Is Int32 Then
         bytes = BitConverter.GetBytes(CType(arg, Int32))
      ElseIf TypeOf(arg) Is Int64 Then
         bytes = BitConverter.GetBytes(CType(arg, Int64))
      ElseIf TypeOf(arg) Is UInt16 Then
         bytes = BitConverter.GetBytes(CType(arg, UInt16))
      ElseIf TypeOf(arg) Is UInt32 Then
         bytes = BitConverter.GetBytes(CType(arg, UInt64))
      ElseIf TypeOf(arg) Is UInt64 Then
         bytes = BitConverter.GetBytes(CType(arg, UInt64))                  
      ElseIf TypeOf(arg) Is BigInteger Then
         bytes = CType(arg, BigInteger).ToByteArray()
      Else
         Try 
            Return HandleOtherFormats(fmt, arg) 
         Catch e As FormatException 
            Throw New FormatException(String.Format("The format of '{0}' is invalid.", fmt), e)
         End Try
      End If

      Select Case thisFmt.ToUpper()
         ' Binary formatting.
         Case "B"
            base = 2        
         Case "O"
            base = 8
         Case "H"
            base = 16
         ' Handle unsupported format strings.
         Case Else
            Try 
               Return HandleOtherFormats(fmt, arg) 
            Catch e As FormatException 
               Throw New FormatException(String.Format("The format of '{0}' is invalid.", fmt), e)
            End Try
      End Select
      
      ' Return a formatted string.
      Dim numericString As String = String.Empty
      For ctr As Integer = bytes.GetUpperBound(0) To bytes.GetLowerBound(0) Step -1
         Dim byteString As String = Convert.ToString(bytes(ctr), base)
         If base = 2 Then
            byteString = New String("0"c, 8 - byteString.Length) + byteString
         ElseIf base = 8 Then
            byteString = New String("0"c, 4 - byteString.Length) + byteString
         ' Base is 16.
         Else     
            byteString = New String("0"c, 2 - byteString.Length) + byteString
         End If
         numericString +=  byteString + " "
      Next
      Return numericString.Trim()
   End Function
   
   Private Function HandleOtherFormats(fmt As String, arg As Object) As String
      ' <Snippet3>
      If TypeOf arg Is IFormattable Then
         Return DirectCast(arg, IFormattable).ToString(fmt, CultureInfo.CurrentCulture)
      ElseIf arg IsNot Nothing Then
         Return arg.ToString()
      ' </Snippet3>
      Else
         Return String.Empty
      End If
   End Function
End Class
' </Snippet1>

' <Snippet2>
Public Module Example
   Public Sub Main
      Console.WindowWidth = 100
      
      Dim byteValue As Byte = 124
      ' <Snippet4>
      Console.WriteLine(String.Format(New BinaryFormatter(), _
                                      "{0} (binary: {0:B}) (hex: {0:H})", byteValue))
      ' </Snippet4>
      
      Dim intValue As Integer = 23045
      Console.WriteLine(String.Format(New BinaryFormatter(), _
                                      "{0} (binary: {0:B}) (hex: {0:H})", intValue))
      
      Dim ulngValue As ULong = 31906574882
      Console.WriteLine(String.Format(New BinaryFormatter(), _
                                      "{0} {1}   (binary: {0:B}) {1}   (hex: {0:H})", _
                                      ulngValue, vbCrLf))

      Dim bigIntValue As BigInteger = BigInteger.Multiply(Int64.MaxValue, 2)
      Console.WriteLine(String.Format(New BinaryFormatter(), _
                                      "{0} {1}   (binary: {0:B}) {1}   (hex: {0:H})", _
                                      bigIntValue, vbCrLf))
   End Sub
End Module
' The example displays the following output:
'    124 (binary: 01111100) (hex: 7c)
'    23045 (binary: 00000000 00000000 01011010 00000101) (hex: 00 00 5a 05)
'    31906574882
'       (binary: 00000000 00000000 00000000 00000111 01101101 11000111 10110010 00100010)
'       (hex: 00 00 00 07 6d c7 b2 22)
'    18446744073709551614
'       (binary: 00000000 11111111 11111111 11111111 11111111 11111111 11111111 11111111 11111110)
'       (hex: 00 ff ff ff ff ff ff ff fe)
' </Snippet2>
