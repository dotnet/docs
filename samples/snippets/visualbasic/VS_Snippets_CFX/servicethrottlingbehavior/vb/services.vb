' <snippet2>


Imports System
Imports System.Collections.Generic
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports System.ServiceModel.Dispatcher
Imports System.Text

Namespace Microsoft.WCF.Documentation
  <ServiceContract(Namespace:="http://microsoft.wcf.documentation")> _
  Public Interface ISampleService
	<OperationContract> _
	Function SampleMethod(ByVal msg As String) As String
  End Interface

  Friend Class SampleService
	  Implements ISampleService
  #Region "ISampleService Members"

  Public Function SampleMethod(ByVal msg As String) As String Implements ISampleService.SampleMethod
	Dim currentThrottle As ServiceThrottle = OperationContext.Current.EndpointDispatcher.ChannelDispatcher.ServiceThrottle
	Console.WriteLine("Service called. Current throttle values: ")
	Console.WriteLine("MaxConcurrentCalls: {0}.", currentThrottle.MaxConcurrentCalls.ToString())
	Console.WriteLine("MaxConnections: {0}.", currentThrottle.MaxConcurrentSessions.ToString())
	Console.WriteLine("MaxInstances: {0}.", currentThrottle.MaxConcurrentInstances.ToString())
	   Return "The service greets you: " & msg
  End Function

  #End Region
  End Class
End Namespace
' </snippet2>

