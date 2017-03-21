    Private Sub PopulateInstalledPrintersCombo()
        ' Add list of installed printers found to the combo box.
        ' The pkInstalledPrinters string will be used to provide the display string.
        Dim i as Integer
        Dim pkInstalledPrinters As String

        For i = 0 to PrinterSettings.InstalledPrinters.Count - 1
            pkInstalledPrinters = PrinterSettings.InstalledPrinters.Item(i)
            comboInstalledPrinters.Items.Add(pkInstalledPrinters)
        Next
    End Sub

    Private Sub comboInstalledPrinters_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboInstalledPrinters.SelectedIndexChanged
        ' Set the printer to a printer in the combo box when the selection changes.

        If comboInstalledPrinters.SelectedIndex <> -1 Then
            ' The combo box's Text property returns the selected item's text, which is the printer name.
            printDoc.PrinterSettings.PrinterName = comboInstalledPrinters.Text
        End If


    End Sub