' Defines the enumerator for the Boxes collection.
' (Some prefer this class nested in the collection class.)
Public Class BoxEnumerator
    Implements IEnumerator(Of Box)
    Private _collection As BoxCollection
    Private curIndex As Integer
    Private curBox As Box


    Public Sub New(ByVal collection As BoxCollection)
        MyBase.New()
        _collection = collection
        curIndex = -1
        curBox = Nothing

    End Sub

    Private Property Box As Box
    Public Function MoveNext() As Boolean _
        Implements IEnumerator(Of Box).MoveNext
        curIndex = curIndex + 1
        If curIndex = _collection.Count Then
            ' Avoids going beyond the end of the collection.
            Return False
        Else
            'Set current box to next item in collection.
            curBox = _collection(curIndex)
        End If
        Return True
    End Function

    Public Sub Reset() _
        Implements IEnumerator(Of Box).Reset
        curIndex = -1
    End Sub

    Public Sub Dispose() _
        Implements IEnumerator(Of Box).Dispose

    End Sub

    Public ReadOnly Property Current() As Box _
        Implements IEnumerator(Of Box).Current

        Get
            If curBox Is Nothing Then
                Throw New InvalidOperationException()
            End If

            Return curBox
        End Get
    End Property

    Private ReadOnly Property Current1() As Object _
        Implements IEnumerator.Current

        Get
            Return Me.Current
        End Get
    End Property
End Class

' Defines two boxes as equal if they have the same dimensions.
Public Class BoxSameDimensions
    Inherits EqualityComparer(Of Box)

    Public Overrides Function Equals(ByVal b1 As Box, ByVal b2 As Box) As Boolean
        If b1.Height = b2.Height And b1.Length = b2.Length And b1.Width = b2.Width Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Overrides Function GetHashCode(ByVal bx As Box) As Integer
        Dim hCode As Integer = bx.Height ^ bx.Length ^ bx.Width
        Return hCode.GetHashCode()
    End Function
End Class