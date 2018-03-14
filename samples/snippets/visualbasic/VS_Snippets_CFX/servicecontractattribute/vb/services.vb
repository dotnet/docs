' <snippet1>


Imports System
Imports System.Collections.Generic
Imports System.Net.Security
Imports System.ServiceModel
Imports System.Text

Namespace Microsoft.WCF.Documentation
  <ServiceContract(Namespace:="http://microsoft.wcf.documentation", Name:="SampleService", ProtectionLevel:=ProtectionLevel.EncryptAndSign)> _
  Public Interface ISampleService
	<OperationContract> _
	Function SampleMethod(ByVal msg As String) As String
  End Interface

  Friend Class SampleService
	  Implements ISampleService
  #Region "ISampleService Members"

  Public Function SampleMethod(ByVal msg As String) As String Implements ISampleService.SampleMethod
	   Return "The service greets you: " & msg
  End Function

  #End Region
  End Class
End Namespace
' </snippet1>
