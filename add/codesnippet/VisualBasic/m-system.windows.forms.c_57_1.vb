Protected Overrides Sub SetClientSizeCore(x As Integer, y As Integer)
   ' Keep the client size square.
   If x > y Then
      MyBase.SetClientSizeCore(x, x)
   Else
      MyBase.SetClientSizeCore(y, y)
   End If
End Sub