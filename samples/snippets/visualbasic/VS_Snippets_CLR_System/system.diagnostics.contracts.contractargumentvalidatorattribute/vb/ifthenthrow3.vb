' Visual Basic .NET Document
Option Strict On

' <Snippet3>
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

   <ContractArgumentValidator>
   Public Shared Sub InRange(array() As Object, index As Integer, 
                             arrayName As String, indexName As String)
      NotNull(array, arrayName)
      
      If index < 0 Then 
         Throw New ArgumentOutOfRangeException(indexName, 
                                               "The index cannot be negative.")
      End If                                         
      If index >= array.Length Then 
         Throw New ArgumentOutOfRangeException(indexName, 
                                               "The index is outside the bounds of the array.")
      End If                                                                                              
      Contract.EndContractBlock()
   End Sub
End Class

Module Example
   Public Sub Execute(data() As Object, position As Integer)
      ValidationHelper.InRange(data, position, "data", "position")
      
      ' Body of method goes here.
   End Sub
End Module
' </Snippet3>
