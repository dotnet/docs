        Public Function CreateActiveDesignerEventArgs(ByVal losingFocus As IDesignerHost, ByVal gainingFocus As IDesignerHost) As ActiveDesignerEventArgs
            Dim e As New ActiveDesignerEventArgs(losingFocus, gainingFocus)
            Return e
        End Function