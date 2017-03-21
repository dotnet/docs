        Dim prop = New Hashtable()
        prop("port") = 9000

        Dim clientChain = New BinaryClientFormatterSinkProvider()

        Dim serverChain = New SoapServerFormatterSinkProvider()
        serverChain.Next = New BinaryServerFormatterSinkProvider()

        ChannelServices.RegisterChannel(New HttpChannel(prop, clientChain, serverChain))