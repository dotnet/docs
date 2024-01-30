' Visual Basic .NET Document
Option Strict On

Imports System.IO
Imports System.Threading.Tasks

Module Example3
    Public Sub Main()
        Dim name As String = ".\TestFile.dat"
        Dim fs As New FileStream(name,
                                 FileMode.Create,
                                 FileAccess.Write)
        Console.WriteLine("Filename: {0}, Encoding: {1}",
                          name, FileUtilities3.GetEncodingType(fs))
    End Sub
End Module

' <Snippet4>
Public Class FileUtilities3
    Public Enum EncodingType As Integer
        None = 0
        Unknown = -1
        Utf8 = 1
        Utf16 = 2
        Utf32 = 3
    End Enum

    Public Shared Function GetEncodingType(fs As FileStream) As EncodingType
        If Not fs.CanRead Then
            Return EncodingType.Unknown
        End If

        Dim bytes(3) As Byte
        Dim t As Task(Of Integer) = fs.ReadAsync(bytes, 0, 4)
        t.Wait()
        Dim bytesRead As Integer = t.Result
        If bytesRead < 2 Then Return EncodingType.None

        If bytesRead >= 3 And (bytes(0) = &HEF AndAlso bytes(1) = &HBB AndAlso bytes(2) = &HBF) Then
            Return EncodingType.Utf8
        End If

        If bytesRead = 4 Then
            Dim value As UInteger = BitConverter.ToUInt32(bytes, 0)
            If value = &HFEFF Or value = &HFEFF0000 Then
                Return EncodingType.Utf32
            End If
        End If

        Dim value16 As UInt16 = BitConverter.ToUInt16(bytes, 0)
        If value16 = &HFEFF Or value16 = &HFFFE Then
            Return EncodingType.Utf16
        End If

        Return EncodingType.Unknown
    End Function
End Class
' The example displays the following output:
'       Filename: .\TestFile.dat, Encoding: Unknown
' </Snippet4>

