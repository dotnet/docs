
Public Class Automobile

    Sub New(ByVal model As String, ByVal topSpeed As Integer)
        ' TODO: Complete member initialization 
        _model = model
        _topSpeed = topSpeed
    End Sub

    '<Snippet5>
    Sub New()
        Model = "Not specified"
        TopSpeed = -1
        IsRunning = True
    End Sub
    '</Snippet5>

    Property Model As String
    Property TopSpeed As Integer
    Property IsRunning As Boolean

    '<Snippet6>
    Sub Start()
        If Model <> "Not specified" Or TopSpeed <> -1 Then
            IsRunning = True
        Else
            IsRunning = False
        End If
    End Sub
    '</Snippet6>

End Class
