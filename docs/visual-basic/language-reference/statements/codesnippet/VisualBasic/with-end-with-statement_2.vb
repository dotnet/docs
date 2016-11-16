        Dim theWindow As New EntryWindow

        With theWindow
            With .InfoLabel
                .Content = "This is a message."
                .Foreground = Brushes.DarkSeaGreen
                .Background = Brushes.LightYellow
            End With

            .Title = "The Form Title"
            .Show()
        End With