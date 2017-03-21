
		NetNamedPipeBinding binding = new NetNamedPipeBinding();
		IBindingRuntimePreferences s  =
		       binding.GetProperty<IBindingRuntimePreferences>
		       (new BindingParameterCollection());
		bool receiveSynchronously = s.ReceiveSynchronously;
