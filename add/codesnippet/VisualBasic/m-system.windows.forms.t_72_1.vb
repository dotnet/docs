   ' This method defines the behavior of the MouseEnter event.
   ' It sets the state of the rolloverValue field to true and
   ' tells the control to repaint.
   Protected Overrides Sub OnMouseEnter(e As EventArgs)
      MyBase.OnMouseEnter(e)
      
      Me.rolloverValue = True
      
      Me.Invalidate()
    End Sub