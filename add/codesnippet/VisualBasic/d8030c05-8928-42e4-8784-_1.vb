            Dim binding2 As New CustomBinding()
            Dim bpCol2 As New BindingParameterCollection()
            Dim context2 As New BindingContext(binding2, bpCol2)
            be.BuildChannelListener(Of IDuplexChannel)(context2)