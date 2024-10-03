Imports System.IO

Public Class CipherStream
    Inherits Stream

    Const ENCODING_OFFSET As Byte = 80

    Private _readable As Boolean = False
    Private _writable As Boolean = False

    Private _wrappedBaseStream As Stream

    Public Overrides ReadOnly Property CanRead As Boolean
        Get
            Return _readable
        End Get
    End Property

    Public Overrides ReadOnly Property CanSeek As Boolean
        Get
            Return False
        End Get
    End Property

    Public Overrides ReadOnly Property CanWrite As Boolean
        Get
            Return _writable
        End Get
    End Property

    Public Overrides ReadOnly Property Length As Long
        Get
            Return _wrappedBaseStream.Length
        End Get
    End Property

    Public Overrides Property Position As Long
        Get
            Return _wrappedBaseStream.Position
        End Get
        Set(value As Long)
            _wrappedBaseStream.Position = value
        End Set
    End Property

    Public Shared Function CreateForRead(baseStream As Stream) As CipherStream
        Return New CipherStream(baseStream) With
        {
            ._readable = True,
            ._writable = False
        }
    End Function

    Public Shared Function CreateForWrite(baseStream As Stream) As CipherStream
        Return New CipherStream(baseStream) With
        {
            ._readable = False,
            ._writable = True
        }
    End Function

    Private Sub New(baseStream As Stream)
        _wrappedBaseStream = baseStream
    End Sub

    Public Overrides Function Read(buffer() As Byte, offset As Integer, count As Integer) As Integer

        If Not _readable Then Throw New NotSupportedException()
        If count = 0 Then Return 0

        Dim returnCounter As Integer = 0

        For i = 0 To count - 1

            Dim value As Integer = _wrappedBaseStream.ReadByte()

            If (value = -1) Then Return returnCounter

            value += ENCODING_OFFSET
            If value > Byte.MaxValue Then
                value -= Byte.MaxValue
            End If

            buffer(i + offset) = Convert.ToByte(value)
            returnCounter += 1

        Next

        Return returnCounter

    End Function

    Public Overrides Sub Write(buffer() As Byte, offset As Integer, count As Integer)
        If Not _writable Then Throw New NotSupportedException()

        Dim newBuffer(count) As Byte
        buffer.CopyTo(newBuffer, offset)

        For i = 0 To count - 1

            Dim value As Integer = newBuffer(i)

            value -= ENCODING_OFFSET

            If value < 0 Then
                value = Byte.MaxValue - value
            End If

            newBuffer(i) = Convert.ToByte(value)

        Next

        _wrappedBaseStream.Write(newBuffer, 0, count)

    End Sub


    Public Overrides Sub Flush()
        _wrappedBaseStream.Flush()
    End Sub

    Public Overrides Function Seek(offset As Long, origin As SeekOrigin) As Long
        Throw New NotSupportedException()
    End Function

    Public Overrides Sub SetLength(value As Long)
        Throw New NotSupportedException()
    End Sub

End Class
