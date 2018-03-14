' <snippet2>
Imports System
Imports System.IO
Imports System.Text


Namespace Samples.AspNet.VB.Controls

    Public Class UpperCaseFilterStream
        Inherits Stream

        ' This filter changes all characters passed through it to uppercase.
        Private strSink As Stream
        Private lngPosition As Long


        Public Sub New(ByVal sink As Stream)
            strSink = sink
        End Sub 'New

        ' The following members of Stream must be overriden.  
        Public Overrides ReadOnly Property CanRead() As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanSeek() As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanWrite() As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property Length() As Long
            Get
                Return 0
            End Get
        End Property

        Public Overrides Property Position() As Long
            Get
                Return lngPosition
            End Get
            Set(ByVal value As Long)
                lngPosition = Value
            End Set
        End Property

        Public Overrides Function Seek( _
        ByVal offset As Long, ByVal direction As System.IO.SeekOrigin) As Long
            Return strSink.Seek(offset, direction)
        End Function 'Seek


        Public Overrides Sub SetLength(ByVal length As Long)
            strSink.SetLength(length)
        End Sub 'SetLength


        Public Overrides Sub Close()
            strSink.Close()
        End Sub 'Close


        Public Overrides Sub Flush()
            strSink.Flush()
        End Sub 'Flush


        Public Overrides Function Read( _
        ByVal buffer() As Byte, ByVal offset As Integer, ByVal count As Integer) As Integer
            Return strSink.Read(buffer, offset, count)
        End Function 'Read


        ' The Write method actually does the filtering.
        Public Overrides Sub Write( _
        ByVal buffer() As Byte, ByVal offset As Integer, ByVal count As Integer)

            Dim data(count) As Byte
            System.Buffer.BlockCopy(buffer, offset, data, 0, count)
            Dim inputstring As String = Encoding.ASCII.GetString(data).ToUpper()
            data = Encoding.ASCII.GetBytes(InputString)
            strSink.Write(data, 0, count)

        End Sub 'Write 

    End Class 'UpperCaseFilter

End Namespace
' </snippet2>