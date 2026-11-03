Namespace Example

    Public Structure BaggageInfo
        Implements IEquatable(Of BaggageInfo)

        Public ReadOnly Property FlightNumber As Integer
        Public ReadOnly Property From As String
        Public ReadOnly Property Carousel As Integer

        Public Sub New(flightNumber As Integer, from As String, carousel As Integer)
            Me.FlightNumber = flightNumber
            Me.From = from
            Me.Carousel = carousel
        End Sub

        Public Overloads Function Equals(other As BaggageInfo) As Boolean Implements IEquatable(Of BaggageInfo).Equals
            Return FlightNumber = other.FlightNumber AndAlso
                   From = other.From AndAlso
                   Carousel = other.Carousel
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            If TypeOf obj Is BaggageInfo Then
                Return Equals(DirectCast(obj, BaggageInfo))
            End If
            Return False
        End Function

        Public Overrides Function GetHashCode() As Integer
            Return HashCode.Combine(FlightNumber, From, Carousel)
        End Function

        Public Shared Operator =(left As BaggageInfo, right As BaggageInfo) As Boolean
            Return left.Equals(right)
        End Operator

        Public Shared Operator <>(left As BaggageInfo, right As BaggageInfo) As Boolean
            Return Not left.Equals(right)
        End Operator
    End Structure

End Namespace
