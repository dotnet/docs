' The binary layout is as follows:
'    Bytes 0 - 19: string text, padded to the right with null characters
'    Bytes 20+: Double value
Public Sub Write(ByVal w As System.IO.BinaryWriter) _
  Implements Microsoft.SqlServer.Server.IBinarySerialize.Write

    Dim maxStringSize As Integer = 20
    Dim stringValue As String = "The value of PI: "
    Dim paddedString As String
    Dim value As Double = 3.14159

    ' Pad the string from the right with null characters.
    paddedString = stringValue.PadRight(maxStringSize, ControlChars.NullChar)
    
    
    ' Write the string value one byte at a time.
    Dim i As Integer
    For i = 0 To paddedString.Length - 1 Step 1 
        w.Write(paddedString(i))
    Next

    ' Write the double value.
    w.Write(value)
    
End Sub