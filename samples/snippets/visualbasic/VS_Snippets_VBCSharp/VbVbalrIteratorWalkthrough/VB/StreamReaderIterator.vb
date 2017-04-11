Option Strict On 

Public Class StreamReaderEnumerable
    '<Snippet1>
    Implements IEnumerable(Of String)
    '</Snippet1>

    '<Snippet2>
    Private _filePath As String

    Public Sub New(ByVal filePath As String)
        _filePath = filePath
    End Sub
    '</Snippet2>

    '<Snippet3>
    Public Function GetEnumerator() As IEnumerator(Of String) _
        Implements IEnumerable(Of String).GetEnumerator

        Return New StreamReaderEnumerator(_filePath)
    End Function

    Private Function GetEnumerator1() As IEnumerator _
        Implements IEnumerable.GetEnumerator

        Return Me.GetEnumerator()
    End Function
    '</Snippet3>
End Class

Public Class StreamReaderEnumerator
    '<Snippet4>
    Implements IEnumerator(Of String)
    '</Snippet4>

    '<Snippet5>
    Private _sr As IO.StreamReader

    Public Sub New(ByVal filePath As String)
        _sr = New IO.StreamReader(filePath)
    End Sub
    '</Snippet5>

    '<Snippet6>
    Private _current As String

    Public ReadOnly Property Current() As String _
        Implements IEnumerator(Of String).Current

        Get
            If _sr Is Nothing OrElse _current Is Nothing Then
                Throw New InvalidOperationException()
            End If

            Return _current
        End Get
    End Property

    Private ReadOnly Property Current1() As Object _
        Implements IEnumerator.Current

        Get
            Return Me.Current
        End Get
    End Property
    '</Snippet6>

    '<Snippet7>
    Public Function MoveNext() As Boolean _
        Implements System.Collections.IEnumerator.MoveNext

        _current = _sr.ReadLine()
        If _current Is Nothing Then Return False
        Return True
    End Function
    '</Snippet7>

    '<Snippet8>
    Public Sub Reset() _
        Implements System.Collections.IEnumerator.Reset

        _sr.DiscardBufferedData()
        _sr.BaseStream.Seek(0, IO.SeekOrigin.Begin)
        _current = Nothing
    End Sub
    '</Snippet8>


    '<Snippet9>
    Private disposedValue As Boolean = False

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' Dispose of managed resources.
            End If
            _current = Nothing
            _sr.Close()
            _sr.Dispose()
        End If

        Me.disposedValue = True
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Protected Overrides Sub Finalize()
        Dispose(False)
    End Sub
    '</Snippet9>
End Class