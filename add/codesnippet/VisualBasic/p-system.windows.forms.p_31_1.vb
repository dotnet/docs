
    'This method displays a PageSetupDialog object. If the
    ' user clicks OK in the dialog, selected results of
    ' the dialog are displayed in ListBox1.
    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        ' Initialize the dialog's PrinterSettings property to hold user
        ' defined printer settings.
        PageSetupDialog1.PageSettings = _
            New System.Drawing.Printing.PageSettings

        ' Initialize dialog's PrinterSettings property to hold user
        ' set printer settings.
        PageSetupDialog1.PrinterSettings = _
            New System.Drawing.Printing.PrinterSettings

        'Do not show the network in the printer dialog.
        PageSetupDialog1.ShowNetwork = False

        'Show the dialog storing the result.
        Dim result As DialogResult = PageSetupDialog1.ShowDialog()

        ' If the result is OK, display selected settings in
        ' ListBox1. These values can be used when printing the
        ' document.
        If (result = DialogResult.OK) Then
            Dim results() As Object = New Object() _
                {PageSetupDialog1.PageSettings.Margins, _
                 PageSetupDialog1.PageSettings.PaperSize, _
                 PageSetupDialog1.PageSettings.Landscape, _
                 PageSetupDialog1.PrinterSettings.PrinterName, _
                 PageSetupDialog1.PrinterSettings.PrintRange}
            ListBox1.Items.AddRange(results)
        End If

    End Sub