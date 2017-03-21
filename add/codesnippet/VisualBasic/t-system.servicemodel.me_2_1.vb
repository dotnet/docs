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