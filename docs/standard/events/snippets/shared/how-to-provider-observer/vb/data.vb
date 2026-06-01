' <Snippet1>
Namespace Global.TemperatureSample

    Public Structure Temperature
        Public ReadOnly Property Degrees As Decimal
        Public ReadOnly Property [Date] As Date

        Public Sub New(degrees As Decimal, [date] As Date)
            Me.Degrees = degrees
            Me.Date = [date]
        End Sub
    End Structure

End Namespace
' </Snippet1>
