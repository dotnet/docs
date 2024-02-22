' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.IO
Imports System.Threading.Tasks

Module Example2
    Public Sub Main()
        Dim name As String = ".\TestFile.dat"
        Dim fs As New FileStream(name,
                               FileMode.Create,
                               FileAccess.Write)
        Console.WriteLine("Filename: {0}, Encoding: {1}",
                        name, FileUtilities2.GetEncodingType(fs))
    End Sub
End Module

Public Class FileUtilities2
    Public Enum EncodingType As Integer
        None = 0
        Unknown = -1
        Utf8 = 1
        Utf16 = 2
        Utf32 = 3
    End Enum

    Public Shared Function GetEncodingType(fs As FileStream) As EncodingType
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
'    Unhandled Exception: System.NotSupportedException: Stream does not support reading.
'       at System.IO.Stream.BeginReadInternal(Byte[] buffer, Int32 offset, Int32 count, AsyncCallback callback, Object state,
'     Boolean serializeAsynchronously)
'       at System.IO.FileStream.BeginRead(Byte[] array, Int32 offset, Int32 numBytes, AsyncCallback userCallback, Object stat
'    eObject)
'       at System.IO.Stream.<>c.<BeginEndReadAsync>b__43_0(Stream stream, ReadWriteParameters args, AsyncCallback callback, O
'    bject state)
'       at System.Threading.Tasks.TaskFactory`1.FromAsyncTrim[TInstance,TArgs](TInstance thisRef, TArgs args, Func`5 beginMet
'    hod, Func`3 endMethod)
'       at System.IO.Stream.BeginEndReadAsync(Byte[] buffer, Int32 offset, Int32 count)
'       at System.IO.FileStream.ReadAsync(Byte[] buffer, Int32 offset, Int32 count, CancellationToken cancellationToken)
'       at System.IO.Stream.ReadAsync(Byte[] buffer, Int32 offset, Int32 count)
'       at FileUtilities2.GetEncodingType(FileStream fs)
'       at Example.Main()
' </Snippet3>

