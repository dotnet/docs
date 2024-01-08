' <Snippet1>
Public Structure Path
    Implements IEquatable(Of Path)

    Public ReadOnly Property Segments As IReadOnlyList(Of String)

    Public Sub New(ParamArray ByVal segments() As String)
        Me.Segments = segments
    End Sub

    Public Overrides Function Equals(obj As Object) As Boolean
        Return (TypeOf obj Is Path) AndAlso Equals(DirectCast(obj, Path))
    End Function

    Public Overloads Function Equals(other As Path) As Boolean Implements IEquatable(Of Path).Equals
        If ReferenceEquals(Segments, other.Segments) Then Return True
        If Segments Is Nothing OrElse other.Segments Is Nothing Then Return False
        If Segments.Count <> other.Segments.Count Then Return False

        For i As Integer = 0 To Segments.Count - 1
            If Not PathEquals(Segments(i), other.Segments(i)) Then Return False
        Next

        Return True
    End Function

    Public Overrides Function GetHashCode() As Integer
        Dim hash As HashCode = New HashCode()

        For i As Integer = 0 To Segments?.Count - 1
            AddPath(hash, Segments(i))
        Next

        Return hash.ToHashCode()
    End Function
    
End Structure

Friend Module PlatformUtils

    Public Function PathEquals(ByVal a As String, ByVal b As String) As Boolean
        Return String.Equals(a, b, StringComparison.OrdinalIgnoreCase)
    End Function

    Public Sub AddPath(ByRef hash As HashCode, ByVal path As String)
        hash.Add(path, StringComparer.OrdinalIgnoreCase)
    End Sub

End Module

Module Program

    Sub Main(args As String())
        Dim hashSet As HashSet(Of Path) = New HashSet(Of Path) From {
            New Path("C:", "tmp", "file.txt"),
            New Path("C:", "TMP", "file.txt"),
            New Path("C:", "tmp", "FILE.TXT")
        }
        Console.WriteLine($"Item count: {hashSet.Count}.")
    End Sub

End Module
' The example displays the following output:
' Item count: 1.
' </Snippet1>