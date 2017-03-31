Imports System
Imports System.ServiceModel.Channels
Imports System.Collections.Generic
Imports System.Text
Imports System.ServiceModel

Namespace Microsoft.ServiceModel.Samples
	<ServiceContract> _
	Public Interface IUniversalContract
		<OperationContract(Action := "*", ReplyAction := "*")> _
		Function ProcessMessage(ByVal input As Message) As Message
	End Interface
End Namespace
