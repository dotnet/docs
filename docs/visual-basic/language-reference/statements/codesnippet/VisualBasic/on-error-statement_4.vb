Public Sub OnErrorDemo()
   On Error GoTo ErrorHandler   ' Enable error-handling routine.
   Dim x As Integer = 32
   Dim y As Integer = 0
   Dim z As Integer
   z = x / y   ' Creates a divide by zero error
   On Error GoTo 0   ' Turn off error trapping.
   On Error Resume Next   ' Defer error trapping.
   z = x / y   ' Creates a divide by zero error again
   If Err.Number = 6 Then
      ' Tell user what happened. Then clear the Err object.
      Dim Msg As String
      Msg = "There was an error attempting to divide by zero!"
      MsgBox(Msg, , "Divide by zero error")
      Err.Clear() ' Clear Err object fields.
   End If
Exit Sub      ' Exit to avoid handler.
ErrorHandler:  ' Error-handling routine.
   Select Case Err.Number   ' Evaluate error number.
      Case 6   ' Divide by zero error
         MsgBox("You attempted to divide by zero!")
         ' Insert code to handle this error
      Case Else
         ' Insert code to handle other situations here...
   End Select
   Resume Next  ' Resume execution at the statement immediately 
                ' following the statement where the error occurred.
End Sub
