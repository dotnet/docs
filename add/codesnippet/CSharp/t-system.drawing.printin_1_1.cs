        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (e.PageSettings.Color && !printDocument1.PrinterSettings.SupportsColor)
                MessageBox.Show("Color printing not supported on selected printer.", "Printer Warning", MessageBoxButtons.OKCancel);
        }