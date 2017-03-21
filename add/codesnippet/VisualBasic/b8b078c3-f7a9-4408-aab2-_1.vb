        Dim nextSink As IServerChannelSink = Nothing
        If Not (nextProvider Is Nothing) Then
            Console.WriteLine("The next server provider is:" + CType(nextProvider,Object).ToString())
            ' Create a sink chain calling the 'SaopServerFormatterProvider'
            ' 'CreateSink' method.
            nextSink = nextProvider.CreateSink(channel)
        End If
        Return New MyServerChannelSink(nextSink)