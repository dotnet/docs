Dim LastError As Exception
Dim ErrMessage As String

LastError = Server.GetLastError()

If Not LastError Is Nothing Then
   ErrMessage = LastError.Message
Else
   ErrMessage = "No Errors"
End If
 
Response.Write("Last Error = " & ErrMessage)
   