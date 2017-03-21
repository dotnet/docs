   ' The method defines the behavior of the Click event.
   ' It simply toggles the state of the clickedValue field.
   Protected Overrides Sub OnClick(e As EventArgs)
      MyBase.OnClick(e)
      
        Me.clickedValue = Me.clickedValue Xor True
    End Sub