			Dim behaviors As KeyedByTypeCollection(Of IContractBehavior) = cd.Behaviors
			Console.WriteLine(Constants.vbTab & "Display all behaviors:")
			For Each behavior As IContractBehavior In behaviors
				Console.WriteLine(Constants.vbTab + Constants.vbTab + CType(behavior, Object).ToString())
			Next behavior