
' <Snippet1>
Imports System.Globalization

Public Class RatingInformation
    Implements IComparable
    Implements IComparable(Of RatingInformation)

    Public Sub New(rating As String)
        ArgumentNullException.ThrowIfNull(rating)

        Dim v As String = rating.ToUpper(CultureInfo.InvariantCulture)
        If (v.Length <> 1 Or
            String.Compare(v, "C", StringComparison.Ordinal) > 0 Or
            String.Compare(v, "A", StringComparison.Ordinal) < 0) Then
            Throw New ArgumentException("Invalid rating value was specified.", NameOf(rating))
        End If

        Me.Rating = v
    End Sub

    Public ReadOnly Property Rating As String

    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        If (obj Is Nothing) Then Return 1
        If (TypeOf obj IsNot RatingInformation) Then Return 0
        Dim other As RatingInformation = DirectCast(obj, RatingInformation)
        Return CompareTo(other)
    End Function

    Public Function CompareTo(other As RatingInformation) As Integer Implements IComparable(Of RatingInformation).CompareTo
        If (other Is Nothing) Then Return 1
        ' Ratings compare opposite To normal String order,
        ' so reverse the value returned by String.CompareTo.
        Return -String.Compare(Rating, other.Rating, StringComparison.OrdinalIgnoreCase)
    End Function

    Public Shared Operator =(one As RatingInformation, other As RatingInformation) As Boolean
        If (one Is Nothing) Then Return (other Is Nothing)
        If (other Is Nothing) Then Return False
        Return (one.Rating = other.Rating)
    End Operator

    Public Shared Operator <>(one As RatingInformation, other As RatingInformation) As Boolean
        If (one Is Nothing) Then Return (other IsNot Nothing)
        If (other Is Nothing) Then Return True
        Return (one.Rating <> other.Rating)
    End Operator

    Public Shared Operator <(one As RatingInformation, other As RatingInformation) As Boolean
        If (one Is Nothing) Then Return (other IsNot Nothing)
        If (other Is Nothing) Then Return False
        Return (one.Rating < other.Rating)
    End Operator

    Public Shared Operator >(one As RatingInformation, other As RatingInformation) As Boolean
        If (one Is Nothing) Then Return False
        If (other Is Nothing) Then Return True
        Return (one.Rating > other.Rating)
    End Operator

    Public Overrides Function Equals(obj As Object) As Boolean
        If ReferenceEquals(Me, obj) Then
            Return True
        End If

        If obj Is Nothing Then
            Return False
        End If

        Throw New NotImplementedException()
    End Function

    Public Overrides Function GetHashCode() As Integer
        Throw New NotImplementedException()
    End Function
End Class
' </Snippet1>

' <Snippet2>
Public Class TestCompare
    Public Shared Sub Main1036(ByVal args As String())
        If (args.Length < 2) Then
            Return
        End If
        Dim r1 As New RatingInformation(args(0))
        Dim r2 As New RatingInformation(args(1))
        Dim answer As String

        If (r1.CompareTo(r2) > 0) Then
            answer = "greater than"
        ElseIf (r1.CompareTo(r2) < 0) Then
            answer = "less than"
        Else
            answer = "equal to"
        End If

        Console.WriteLine("{0} is {1} {2}", r1.Rating, answer, r2.Rating)
    End Sub
End Class
' </Snippet2>
