
    Private WithEvents comboInstalledPrinters As New ComboBox
    Private WithEvents printDoc As New PrintDocument

    Private Sub PopulateInstalledPrintersCombo()
        comboInstalledPrinters.Dock = DockStyle.Top
        Controls.Add(comboInstalledPrinters)

        ' Add list of installed printers found to the combo box.
        ' The pkInstalledPrinters string will be used to provide the display string.
        Dim i As Integer
        Dim pkInstalledPrinters As String

        For i = 0 To PrinterSettings.InstalledPrinters.Count - 1
            pkInstalledPrinters = PrinterSettings.InstalledPrinters.Item(i)
            comboInstalledPrinters.Items.Add(pkInstalledPrinters)
            If (printDoc.PrinterSettings.IsDefaultPrinter()) Then
                comboInstalledPrinters.Text = printDoc.PrinterSettings.PrinterName
            End If
        Next
    End Sub
