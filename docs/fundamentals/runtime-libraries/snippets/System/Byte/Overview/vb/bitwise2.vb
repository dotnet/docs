' Visual Basic .NET Document

' <Snippet2>
Imports System.Collections.Generic
Imports System.Globalization

Public Structure ByteString
   Public Value As String
   Public Sign As Integer
End Structure

Module Example2
    Public Sub Main()
        Dim values() As ByteString = CreateArray(-15, 123, 245)

        Dim mask As Byte = &H14        ' Mask all bits but 2 and 4.

        For Each strValue As ByteString In values
            Dim byteValue As Byte = Byte.Parse(strValue.Value, NumberStyles.AllowHexSpecifier)
            Console.WriteLine("{0} ({1}) And {2} ({3}) = {4} ({5})",
                           strValue.Sign * byteValue,
                           Convert.ToString(byteValue, 2),
                           mask, Convert.ToString(mask, 2),
                           (strValue.Sign And Math.Sign(mask)) * (byteValue And mask),
                           Convert.ToString(byteValue And mask, 2))
        Next
    End Sub

    Private Function CreateArray(ParamArray values() As Object) As ByteString()
        Dim byteStrings As New List(Of ByteString)
        For Each value As Object In values
            Dim temp As New ByteString()
            Dim sign As Integer = Math.Sign(value)
            temp.Sign = sign
            ' Change two's complement to magnitude-only representation.
            value = value * sign

            temp.Value = Convert.ToString(value, 16)
            byteStrings.Add(temp)
        Next
        Return byteStrings.ToArray()
    End Function
End Module
' The example displays the following output:
'       -15 (1111) And 20 (10100) = 4 (100)
'       123 (1111011) And 20 (10100) = 16 (10000)
'       245 (11110101) And 20 (10100) = 20 (10100)
' </Snippet2>
