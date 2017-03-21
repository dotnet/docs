	Private Shared Sub SnippetReceiveSynchronously()
		Dim binding As New WSHttpBinding()
		Dim s As IBindingRuntimePreferences = binding.GetProperty(Of IBindingRuntimePreferences) (New BindingParameterCollection())
            Dim receiveSynchronously = s.ReceiveSynchronously

	End Sub