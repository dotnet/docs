Imports System.Security.Permissions
Imports System
Imports System.ServiceModel
Imports System.Runtime.Serialization
<assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution := True)>

'<snippet1>
<ServiceContract(), XmlSerializerFormat(Style := OperationFormatStyle.Rpc, _
   Use := OperationFormatUse.Encoded)>  _
Public Interface ICalculator
    <OperationContract(), XmlSerializerFormat(Style := OperationFormatStyle.Rpc, _
        Use := OperationFormatUse.Encoded)>  _
    Function Add(ByVal a As Double, ByVal b As Double) As Double 
End Interface 
'</snippet1>

NotInheritable Public Class Test
    
    Private Sub New() 
    
    End Sub 
    
    Public Shared Sub Main() 
    
    End Sub 
End Class 