    Private Sub MyButtonPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyButtonPrint.Click

        ' Set the paper size based upon the selection in the combo box.
        If comboPaperSize.SelectedIndex <> -1 Then
            printDoc.DefaultPageSettings.PaperSize = _
            printDoc.PrinterSettings.PaperSizes.Item(comboPaperSize.SelectedIndex)
        End If

        ' Set the paper source based upon the selection in the combo box.
        If comboPaperSource.SelectedIndex <> -1 Then
            printDoc.DefaultPageSettings.PaperSource = _
            printDoc.PrinterSettings.PaperSources.Item(comboPaperSource.SelectedIndex)
        End If

        ' Set the printer resolution based upon the selection in the combo box.
        If comboPrintResolution.SelectedIndex <> -1 Then
            printDoc.DefaultPageSettings.PrinterResolution = _
            printDoc.PrinterSettings.PrinterResolutions.Item(comboPrintResolution.SelectedIndex)
        End If

        ' Print the document with the specified paper size and source.
        printDoc.Print()

    End Sub