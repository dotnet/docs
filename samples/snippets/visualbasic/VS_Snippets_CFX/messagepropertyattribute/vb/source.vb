
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ServiceModel

Namespace Snippets
	'<snippet0>
	<MessageContractAttribute> _
	Public Class CustomMessage
		Private internalPerson As Person
		<MessageProperty> _
		Private a As Integer = 23
		<MessageBodyMember(Name:="Person")> _
		Public Property Data() As PersonType
			Get
				Return internalPerson
			End Get
			Set(ByVal value As PersonType)
				Me.internalPerson = CType(value, Person)
			End Set
		End Property
	End Class
	'</snippet0>
	Public Class Person
		Inherits PersonType
	End Class
	Public Class PersonType
	End Class

End Namespace
