
    private void MyButtonPrint_OnClick(object sender, System.EventArgs e)
    {
        
        // Set the printer name and ensure it is valid. If not, provide a message to the user.
        printDoc.PrinterSettings.PrinterName = "\\mynetworkprinter";

        if (printDoc.PrinterSettings.IsValid) {
        
            // If the printer supports printing in color, then override the printer's default behavior.
            if (printDoc.PrinterSettings.SupportsColor) {

                // Set the page default's to not print in color.
                printDoc.DefaultPageSettings.Color = false;
            }

            // Provide a friendly name, set the page number, and print the document.
            printDoc.DocumentName = "My Presentation";
            currentPageNumber = 1;
            printDoc.Print();
        }
        else {
            MessageBox.Show("Printer is not valid");
        }
    }

    private void MyPrintQueryPageSettingsEvent(object sender, QueryPageSettingsEventArgs e)
    {
        // Determines if the printer supports printing in color.
        if (printDoc.PrinterSettings.SupportsColor) {

            // If the printer supports color printing, use color.
            if (currentPageNumber == 1 ) {

                e.PageSettings.Color = true;
            }

        }    
    }