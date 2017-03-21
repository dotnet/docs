        ' Handle the QueryAccessibilityHelp event.
        Private Sub ChartControl_QueryAccessibilityHelp(sender As Object, _
                           e As System.Windows.Forms.QueryAccessibilityHelpEventArgs) Handles MyBase.QueryAccessibilityHelp
            e.HelpString = "Displays chart data"
        End Sub 