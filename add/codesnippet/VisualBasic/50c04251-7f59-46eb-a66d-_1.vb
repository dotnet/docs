        ' Add list of supported paper sizes found on the printer. 
        ' The DisplayMember property is used to identify the property that will provide the display string.
        comboPaperSize.DisplayMember = "PaperName"

        Dim pkSize As PaperSize
        For i = 0 to printDoc.PrinterSettings.PaperSizes.Count - 1
            pkSize = printDoc.PrinterSettings.PaperSizes.Item(i)
            comboPaperSize.Items.Add(pkSize)
        Next

        ' Create a PaperSize and specify the custom paper size through the constructor and add to combobox.
        Dim pkCustomSize1 As New PaperSize("Custom Paper Size", 100, 200)

        comboPaperSize.Items.Add(pkCustomSize1)