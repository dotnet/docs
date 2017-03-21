    private ComboBox comboInstalledPrinters = new ComboBox();
    private PrintDocument printDoc = new PrintDocument();

    private void PopulateInstalledPrintersCombo()
    {
        comboInstalledPrinters.Dock = DockStyle.Top;
        Controls.Add(comboInstalledPrinters);

        // Add list of installed printers found to the combo box.
        // The pkInstalledPrinters string will be used to provide the display string.
        int i;
        string pkInstalledPrinters;

        for (i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
        {
            pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
            comboInstalledPrinters.Items.Add(pkInstalledPrinters);
            if (printDoc.PrinterSettings.IsDefaultPrinter)
            {
                comboInstalledPrinters.Text = printDoc.PrinterSettings.PrinterName;
            }
        }
    }