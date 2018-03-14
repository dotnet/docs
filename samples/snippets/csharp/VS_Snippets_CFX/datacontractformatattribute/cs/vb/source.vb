Imports System.Security.Permissions
Imports System
Imports System.Collections
Imports System.ServiceModel
Imports System.Runtime.Serialization
Imports System.Xml.Serialization
<assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution := True)>
NotInheritable Public Class Test
    Public Shared Sub Main() 
    
    End Sub 
End Class 'Test

'<snippet1>
<ServiceContract(), DataContractFormat(Style := OperationFormatStyle.Rpc)>  _
Interface ICalculator
    <OperationContract(), DataContractFormat(Style := OperationFormatStyle.Rpc)>  _
    Function Add(ByVal a As Double, ByVal b As Double) As Double 
    
    <OperationContract(), DataContractFormat(Style := OperationFormatStyle.Document)>  _
    Function Subtract(ByVal a As Double, ByVal b As Double) As Double 
End Interface 
'</snippet1>