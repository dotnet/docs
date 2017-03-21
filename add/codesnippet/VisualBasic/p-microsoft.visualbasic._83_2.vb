    ' Typical use of Number property.
Sub test()
  On Error GoTo out

  Dim x, y As Integer
  x = 1 / y   ' Create division by zero error.
  Exit Sub
out:
  MsgBox(Err.Number)
  MsgBox(Err.Description)
  ' Check for division by zero error.
  If Err.Number = 11 Then
      y = y + 1
  End If
  Resume Next
End Sub