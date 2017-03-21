        ' Get the history size.
        Dim historySize As Integer = _
        sessionPageState.HistorySize

        Dim msg As String = _
        String.Format( _
        "Current history size: {0}" + _
        ControlChars.Lf, historySize.ToString())

        Console.Write(msg)


        If Not sessionPageState.IsReadOnly() Then
            ' Double current history size.
            sessionPageState.HistorySize = _
            2 * sessionPageState.HistorySize

            configuration.Save()

            historySize = sessionPageState.HistorySize

            msg = String.Format( _
            "New history size: {0}" + _
            ControlChars.Lf, historySize.ToString())

            Console.Write(msg)
        End If
