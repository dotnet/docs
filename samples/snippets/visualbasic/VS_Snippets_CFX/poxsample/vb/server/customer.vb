Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.Serialization

Namespace Microsoft.ServiceModel.Samples
	<DataContract(Namespace := "http://tempuri.org/Customer")> _
	Public Class Customer
		<DataMember> _
		Public Name As String
		<DataMember> _
		Public Address As String
	End Class
End Namespace