' <snippet1>


Imports System
Imports System.Collections.Generic
Imports System.ServiceModel
Imports System.Text

Namespace Microsoft.WCF.Documentation
  <ServiceContract(Name:="HelloWorld", Namespace:="http://Microsoft.WCF.Documentation")> _
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
