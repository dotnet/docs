   private:
      void PopulateInstalledPrintersCombo()
      {
         // Add list of installed printers found to the combo box.
         // The pkInstalledPrinters String will be used to provide the display String.
         String^ pkInstalledPrinters;
         for ( int i = 0; i < PrinterSettings::InstalledPrinters->Count; i++ )
         {
            pkInstalledPrinters = PrinterSettings::InstalledPrinters[ i ];
            comboInstalledPrinters->Items->Add( pkInstalledPrinters );
         }
      }

      void comboInstalledPrinters_SelectionChanged( Object^ sender, System::EventArgs^ e )
      {
         // Set the printer to a printer in the combo box when the selection changes.
         if ( comboInstalledPrinters->SelectedIndex != -1 )
         {
            // The combo box's Text property returns the selected item's text, which is the printer name.
            printDoc->PrinterSettings->PrinterName = comboInstalledPrinters->Text;
         }
      }