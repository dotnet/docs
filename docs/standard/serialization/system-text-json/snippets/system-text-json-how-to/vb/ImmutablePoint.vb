Namespace SystemTextJsonSamples

    ' <ImmutablePoint>
    Public Structure ImmutablePoint

        Public Sub New(x As Integer, y As Integer)
            Me.X = x
            Me.Y = y
        End Sub

        Public ReadOnly Property X As Integer
        Public ReadOnly Property Y As Integer
    End Structure

    ' </ImmutablePoint>
End Namespace
