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