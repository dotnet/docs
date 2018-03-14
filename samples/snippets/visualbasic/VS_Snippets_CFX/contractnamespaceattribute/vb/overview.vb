Imports System.Security.Permissions
Imports System
Imports System.Runtime.Serialization
<assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution := True)>
'<snippet1>
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
'</snippet1>
Namespace TestNamespace
    
    Public Class Test
        
        Shared Sub Main() 
            Console.WriteLine("Just for compiling.")
        
        End Sub 'Main
    End Class 'Test
End Namespace 'TestNamespace

