Option Explicit On
Option Strict On

Imports System
Imports System.IO
Imports System.Data.SqlTypes
Imports Microsoft.SqlServer.Server
Imports System.Text

Public Class Class1:Implements Microsoft.SqlServer.Server.IBinarySerialize

Dim StringValue As String
Dim DoubleValue As Double

Shared Sub Main()

    Dim fileName As String = "info.dat"
    Dim temp As Class1 = new Class1()

    Dim fs As FileStream = new FileStream(fileName, FileMode.Create)
    Dim w As BinaryWriter = new BinaryWriter(fs)

    temp.Write(w)

    w.Close()
    fs.Close()

    fs = new FileStream(fileName, FileMode.Open, FileAccess.Read)
    Dim r As BinaryReader = new BinaryReader(fs)

    temp.Read(r)

    Console.WriteLine("String Value: " & temp.StringValue)
    Console.WriteLine("Double value: " & temp.DoubleValue) 

End Sub

'<Snippet1>
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
'</Snippet1>

'<Snippet2>
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
'</Snippet2>

End Class
