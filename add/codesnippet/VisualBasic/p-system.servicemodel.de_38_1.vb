			Dim odc As OperationDescriptionCollection = cd.Operations
			Console.WriteLine(Constants.vbTab & "Display Operations:")
			For Each od As OperationDescription In odc
				Console.WriteLine(Constants.vbTab + Constants.vbTab + od.Name)
			Next od