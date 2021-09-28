' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet8>
Imports System.Text

Module Example
    Public Sub Main()
        Dim strings() As String = {"This is the first sentence. ",
                                    "This is the second sentence. "}
        Dim asciiEncoding As Encoding = Encoding.ASCII

        ' Create array of adequate size.
        Dim bytes(50) As Byte
        ' Create index for current position of array.
        Dim index As Integer = 0

        Console.WriteLine("Strings to encode:")
        For Each stringValue In strings
            Console.WriteLine("   {0}", stringValue)

            Dim count As Integer = asciiEncoding.GetByteCount(stringValue)
            If count + index >= bytes.Length Then
                Array.Resize(bytes, bytes.Length + 50)
            End If
            Dim written As Integer = asciiEncoding.GetBytes(stringValue, 0,
                                                            stringValue.Length,
                                                            bytes, index)

            index = index + written
        Next
        Console.WriteLine()
        Console.WriteLine("Encoded bytes:")
        Console.WriteLine("{0}", ShowByteValues(bytes, index))
        Console.WriteLine()

        ' Decode Unicode byte array to a string.
        Dim newString As String = asciiEncoding.GetString(bytes, 0, index)
        Console.WriteLine("Decoded: {0}", newString)
    End Sub

    Private Function ShowByteValues(bytes As Byte(), last As Integer) As String
        Dim returnString As String = "   "
        For ctr As Integer = 0 To last - 1
            If ctr Mod 20 = 0 Then returnString += vbCrLf + "   "
            returnString += String.Format("{0:X2} ", bytes(ctr))
        Next
        Return returnString
    End Function
End Module
' The example displays the following output:
'       Strings to encode:
'          This is the first sentence.
'          This is the second sentence.
'       
'       Encoded bytes:
'       
'          54 68 69 73 20 69 73 20 74 68 65 20 66 69 72 73 74 20 73 65
'          6E 74 65 6E 63 65 2E 20 54 68 69 73 20 69 73 20 74 68 65 20
'          73 65 63 6F 6E 64 20 73 65 6E 74 65 6E 63 65 2E 20
'       
'       Decoded: This is the first sentence. This is the second sentence.
' </Snippet8>
