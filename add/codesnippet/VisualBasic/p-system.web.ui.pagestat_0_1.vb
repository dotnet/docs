        '
        ' Load ViewState and ControlState.
        '
        Public Overrides Sub Load()

            Dim stateStream As Stream
            stateStream = GetSecureStream()

            ' Read the state string, using the StateFormatter.
            Dim reader As New StreamReader(stateStream)

            Dim serializedStatePair As String
            serializedStatePair = reader.ReadToEnd
            Dim statePair As Pair

            Dim formatter As IStateFormatter
            formatter = Me.StateFormatter

            ' Deserilize returns the Pair object that is serialized in
            ' the Save method.      
            statePair = CType(formatter.Deserialize(serializedStatePair), Pair)

            ViewState = statePair.First
            ControlState = statePair.Second
            reader.Close()
            stateStream.Close()
        End Sub ' Load
