
Imports System
Imports System.Runtime.Serialization
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports System.ServiceModel.Channels
Imports System.Collections
Imports System.Collections.Generic

Namespace Test
	<ServiceContract> _
	Public Interface IContract
		<OperationContract(Action := "http://SomeAction")> _
		Function Hello() As String
		<OperationContract(Action := "http://SomeAction")> _
		Function HelloTwo() As String
	End Interface

    Module Module1
        Sub Main(ByVal args() As String)
            Dim contract As ContractDescription = ContractDescription.GetContract(GetType(IContract))
            Dim op As OperationDescription = contract.Operations(0)
            Dim mdc As MessageDescriptionCollection = op.Messages

            Dim md As MessageDescription = mdc.Find("http://SomeAction")
            Dim col As ICollection(Of MessageDescription) = mdc.FindAll("http://SomeAction")

            For Each desc As MessageDescription In col
                Console.WriteLine("Action = {0}", desc.Action)
            Next desc
        End Sub
    End Module
End Namespace
