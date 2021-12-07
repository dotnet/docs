' <Snippet15>
Public Class ByteByByteFormatter : Implements IFormatProvider, ICustomFormatter
    Public Function GetFormat(formatType As Type) As Object _
                    Implements IFormatProvider.GetFormat
        If formatType Is GetType(ICustomFormatter) Then
            Return Me
        Else
            Return Nothing
        End If
    End Function

    Public Function Format(fmt As String, arg As Object,
                           formatProvider As IFormatProvider) As String _
                           Implements ICustomFormatter.Format

        If Not formatProvider.Equals(Me) Then Return Nothing

        ' Handle only hexadecimal format string.
        If Not fmt.StartsWith("X") Then
            Return Nothing
        End If

        ' Handle only integral types.
        If Not typeof arg Is Byte AndAlso
           Not typeof arg Is Int16 AndAlso
           Not typeof arg Is Int32 AndAlso
           Not typeof arg Is Int64 AndAlso
           Not typeof arg Is SByte AndAlso
           Not typeof arg Is UInt16 AndAlso
           Not typeof arg Is UInt32 AndAlso
           Not typeof arg Is UInt64 Then _
              Return Nothing

        Dim bytes() As Byte = BitConverter.GetBytes(arg)
        Dim output As String = Nothing

        For ctr As Integer = bytes.Length - 1 To 0 Step -1
            output += String.Format("{0:X2} ", bytes(ctr))
        Next

        Return output.Trim()
    End Function
End Class
' </Snippet15>

' <Snippet16>
Public Module Example10
    Public Sub Main10()
        Dim value As Long = 3210662321
        Dim value1 As Byte = 214
        Dim value2 As Byte = 19

        Console.WriteLine((String.Format(New ByteByByteFormatter(), "{0:X}", value)))
        Console.WriteLine((String.Format(New ByteByByteFormatter(), "{0:X} And {1:X} = {2:X} ({2:000})",
                                        value1, value2, value1 And value2)))
        Console.WriteLine(String.Format(New ByteByByteFormatter(), "{0,10:N0}", value))
    End Sub
End Module
' The example displays the following output:
'       00 00 00 00 BF 5E D1 B1
'       00 D6 And 00 13 = 00 12 (018)
'       3,210,662,321
' </Snippet16>
