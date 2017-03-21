        '
        ' Persist any ViewState and ControlState.
        '
        Public Overrides Sub Save()

            If Not (ViewState Is Nothing) OrElse Not (ControlState Is Nothing) Then
                If Not (Page.Session Is Nothing) Then

                    Dim stateStream As Stream
                    stateStream = GetSecureStream()

                    ' Write a state string, using the StateFormatter.
                    Dim writer As New StreamWriter(stateStream)

                    Dim formatter As IStateFormatter
                    formatter = Me.StateFormatter

                    Dim statePair As New Pair(ViewState, ControlState)

                    Dim serializedState As String
                    serializedState = formatter.Serialize(statePair)

                    writer.Write(serializedState)
                    writer.Close()
                    stateStream.Close()
                Else
                    Throw New InvalidOperationException("Session needed for StreamPageStatePersister.")
                End If
            End If
        End Sub 'Save