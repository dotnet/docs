			Dim binding As New CustomBinding()
			Dim bpCol As New BindingParameterCollection()
			Dim baseAddress As New Uri("http://MyServer/Base")
			Dim relAddress As String = "MyService"
			Dim context As New BindingContext(binding, bpCol, baseAddress, relAddress, ListenUriMode.Explicit)