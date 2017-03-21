			Dim d As ServiceDescription = ServiceDescription.GetService(New CalculatorService())
			For Each isb As IServiceBehavior In d.Behaviors
				Console.WriteLine(CType(isb, Object).GetType())
			Next isb
			Console.WriteLine()