Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Workflow.Activities

Namespace OperationInfoSnippets
	Friend Class OperationInfoSnippets
		Private Sub container0()
            ' OperationInfo.OperationInfo().
			'<snippet0>
			Dim info As New OperationInfo()
			'</snippet0>
		End Sub

		Private Sub container1()
            ' OperationInfo.ContractName.
			'<snippet1>
			Dim info As New OperationInfo()
			info.ContractName = "Contract1"
			'</snippet1>
		End Sub
		Private Sub container2()
            ' OperationInfo.HasProtectionLevel.
			'<snippet2>
			Dim info As New OperationInfo()
            Dim hasProtectionLevel = info.HasProtectionLevel
			'</snippet2>
		End Sub
		Private Sub container3()
            ' OperationInfo.IsOneWay.
			'<snippet3>
			Dim info As New OperationInfo()
            Dim isOneWay = info.IsOneWay
			'</snippet3>
		End Sub
		Private Sub container4()
            ' OperationInfo.Parameters.
			'<snippet4>
			Dim receive As New ReceiveActivity()
			Dim info As New OperationInfo()
			info.Name = "Echo"
			Dim parameterInfo As New OperationParameterInfo()
            parameterInfo.Attributes = (CType((System.Reflection.ParameterAttributes.Out Or System.Reflection.ParameterAttributes.Retval),  _
                                        System.Reflection.ParameterAttributes))
			parameterInfo.Name = "(ReturnValue)"
			parameterInfo.ParameterType = GetType(String)
			parameterInfo.Position = -1
			info.Parameters.Add(parameterInfo)
			receive.ServiceOperationInfo = info
			'</snippet4>
		End Sub
		Private Sub container5()
            ' OperationInfo.ProtectionLevel.
			'<snippet5>
			Dim info As New OperationInfo()
			info.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign
			'</snippet5>
		End Sub
		Private Sub container6()
            ' OperationInfo.Clone.
			'<snippet6>
			Dim info1 As New OperationInfo()
            Dim info2 As OperationInfo = CType(info1.Clone(), OperationInfo)
			'</snippet6>
		End Sub
		Private Function container7() As Boolean
            ' OperationInfo.Equals.
			'<snippet7>
			Dim info1 As New OperationInfo()
			info1.Name = "ProcessData"
			Dim info2 As New OperationInfo()
			info2.Name = "ProcessData"
			Return info1.Equals(info2)
			'</snippet7>
		End Function
		Private Sub container8()
            ' OperationInfo.GetHashCode.
			'<snippet8>
			Dim info As New OperationInfo()
			info.Name = "ProcessData"
            Dim code = info.GetHashCode()
			'</snippet8>
		End Sub
		Private Sub container9()
            ' OperationInfo.ToString.
			'<snippet9>
			Dim info As New OperationInfo()
            Dim infoString = info.ToString()
			'</snippet9>
		End Sub



	End Class
End Namespace
