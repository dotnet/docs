  Class Sample
    Inherits Control
    
    Dim currentIndex As Integer
    
        Protected Overrides Sub OnInit(ByVal e As EventArgs)
            Page.RegisterRequiresControlState(Me)
            currentIndex = 0
            MyBase.OnInit(e)
        End Sub
    
        Protected Overrides Function SaveControlState() As Object
            If currentIndex <> 0 Then
                Return CType(currentIndex, Object)
            Else
                Return Nothing
            End If
        End Function
    
        Protected Overrides Sub LoadControlState(ByVal state As Object)
            If (state <> Nothing) Then
                currentIndex = CType(state, Integer)
            End If
        End Sub
    
  End Class