'<snippet1>
Imports System.Net.Security
Imports System.ServiceModel
Imports System.Text

Namespace Microsoft.WCF.Documentation
  <ServiceContract(Namespace:="Microsoft.WCF.Documentation")> _
  Public Interface ISampleService
	' This operation specifies an explicit protection level requirement.
	<OperationContract(ProtectionLevel:=ProtectionLevel.EncryptAndSign)> _
	Function SampleMethod(ByVal msg As String) As String
  End Interface

  Friend Class SampleService
	  Implements ISampleService
  #Region "ISampleService Members"

  Public Function SampleMethod(ByVal msg As String) As String Implements ISampleService.SampleMethod
	Console.WriteLine("Called with: {0}", msg)
	   Return "The service greets you: " & msg
  End Function

  #End Region
  End Class
End Namespace
'</snippet1>
