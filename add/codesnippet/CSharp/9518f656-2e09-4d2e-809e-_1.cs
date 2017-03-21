	static void SnippetReceiveSynchronously ()
	{
		WSHttpBinding binding = new WSHttpBinding();
		IBindingRuntimePreferences s  =
					       binding.GetProperty<IBindingRuntimePreferences>
					       (new BindingParameterCollection());
		bool receiveSynchronously = s.ReceiveSynchronously;

	}