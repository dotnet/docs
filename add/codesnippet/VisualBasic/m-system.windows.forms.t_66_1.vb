   ' This method defines the behavior of the MouseLeave event.
   ' It sets the state of the rolloverValue field to false and
   ' tells the control to repaint.
   Protected Overrides Sub OnMouseLeave(e As EventArgs)
      MyBase.OnMouseLeave(e)
      
      Me.rolloverValue = False
      
      Me.Invalidate()
    End Sub