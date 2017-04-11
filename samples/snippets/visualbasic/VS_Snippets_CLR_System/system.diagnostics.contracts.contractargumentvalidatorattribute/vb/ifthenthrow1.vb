' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Class ValidationHelper 
   Public Shared Sub NotNull(argument As Object, parameterName As String) 
      If argument Is Nothing Then 
         Throw New ArgumentNullException(parameterName, 
                                         "The parameter cannot be null.")
      End If
   End Sub
End Class

Module Example
   Public Sub Execute(value As String)
      ValidationHelper.NotNull(value, "value")
      
      ' Body of method goes here.
   End Sub
End Module
' </Snippet1>
