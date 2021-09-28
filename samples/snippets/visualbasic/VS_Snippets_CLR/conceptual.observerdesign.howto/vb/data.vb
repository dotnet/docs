' <Snippet1>
Public Structure Temperature
    Private temp As Decimal
    Private tempDate As DateTime

    Public Sub New(ByVal temperature As Decimal, ByVal dateAndTime As DateTime)
        Me.temp = temperature
        Me.tempDate = dateAndTime
    End Sub

    Public ReadOnly Property Degrees As Decimal
        Get
            Return Me.temp
        End Get
    End Property

    Public ReadOnly Property [Date] As DateTime
        Get
            Return tempDate
        End Get
    End Property
End Structure
' </Snippet1>
