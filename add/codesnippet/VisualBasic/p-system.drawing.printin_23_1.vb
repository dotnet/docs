        ' Add list of paper sources found on the printer to the combo box.
        ' The DisplayMember property is used to identify the property that will provide the display string.
        comboPaperSource.DisplayMember = "SourceName"
        
        Dim pkSource As PaperSource
        For i = 0 to printDoc.PrinterSettings.PaperSources.Count - 1
            pkSource = printDoc.PrinterSettings.PaperSources.Item(i)
            comboPaperSource.Items.Add(pkSource)
        Next