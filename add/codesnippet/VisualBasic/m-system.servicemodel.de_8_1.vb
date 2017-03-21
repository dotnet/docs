			Dim inheretedContracts As Collection(Of ContractDescription) = cd.GetInheritedContracts()
			Console.WriteLine(Constants.vbTab & "Inherited Contracts:")
			For Each contractdescription As ContractDescription In inheretedContracts
				Console.WriteLine(Constants.vbTab + Constants.vbTab + contractdescription.Name)
			Next contractdescription