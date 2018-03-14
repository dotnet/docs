' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Diagnostics.Contracts

Class ValidationHelper 
   <ContractArgumentValidator> 
   Public Shared Sub NotNull(argument As Object, parameterName As String) 
      If argument Is Nothing Then 
         Throw New ArgumentNullException(parameterName, 
                                         "The parameter cannot be null.")
         Contract.EndContractBlock()
      End If
   End Sub
End Class
' </Snippet2>

Module Example
   Public Sub Execute(value As String)
      ValidationHelper.NotNull(value , "value")
      
      ' Body of method goes here.
   End Sub
End Module
