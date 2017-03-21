<assembly: ContractNamespaceAttribute("http://www.cohowinery.com/employees", _
   ClrNamespace := "Microsoft.Contracts.Examples")>

Namespace Microsoft.Contracts.Examples
    <DataContract()>  _
    Public Class Person
        <DataMember()>  _
        Friend FirstName As String
        <DataMember()>  _
        Friend LastName As String
    End Class 
End Namespace 