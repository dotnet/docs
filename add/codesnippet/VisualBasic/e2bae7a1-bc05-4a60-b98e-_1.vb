   ' The Evaluate method is overridden to return the
   ' DataValue property instead of the DefaultValue.
   Protected Overrides Function Evaluate(context As HttpContext, control As Control) As Object
      If context Is Nothing Then
          Return Nothing
      Else
          Return DataValue
      End If
   End Function