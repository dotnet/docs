' The binary layout is as follows:
'    Bytes 0 - 19: string text, padded to the right with null
'    characters
'    Bytes 20+: double value
Public Sub Read(ByVal r As System.IO.BinaryReader) _
  Implements Microsoft.SqlServer.Server.IBinarySerialize.Read
    
    Dim maxStringSize As Integer = 20
    Dim chars As Char()
    Dim stringEnd As Integer
    Dim stringValue As String
    Dim value As double

    ' Read the characters from the binary stream.
    chars = r.ReadChars(maxStringSize)
    
    ' Find the start of the null character padding.
    stringEnd = Array.IndexOf(chars, ControlChars.NullChar)

    If StringEnd = 0 Then
       stringValue = Nothing
       Exit Sub
    End If

    ' Build the string from the array of characters.
    stringValue = new String(chars, 0, stringEnd)

    ' Read the double value from the binary stream.
    value = r.ReadDouble()

    ' Set the object's properties equal to the values.
    Me.StringValue = stringValue
    Me.DoubleValue = value

End Sub