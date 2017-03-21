    Private Sub printDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)  Handles printDocument1.PrintPage
        If e.PageSettings.Color AndAlso Not printDocument1.PrinterSettings.SupportsColor Then
            MessageBox.Show("Color printing not supported on selected printer.", "Printer Warning", MessageBoxButtons.OKCancel)
        End If
    
    End Sub