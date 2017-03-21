   private:
      void MyButtonPrint_Click( Object^ sender, System::EventArgs^ e )
      {
         // Set the paper size based upon the selection in the combo box.
         if ( comboPaperSize->SelectedIndex != -1 )
         {
            printDoc->DefaultPageSettings->PaperSize = printDoc->PrinterSettings->PaperSizes[ comboPaperSize->SelectedIndex ];
         }

         // Set the paper source based upon the selection in the combo box.
         if ( comboPaperSource->SelectedIndex != -1 )
         {
            printDoc->DefaultPageSettings->PaperSource = printDoc->PrinterSettings->PaperSources[ comboPaperSource->SelectedIndex ];
         }

         // Set the printer resolution based upon the selection in the combo box.
         if ( comboPrintResolution->SelectedIndex != -1 )
         {
            printDoc->DefaultPageSettings->PrinterResolution = printDoc->PrinterSettings->PrinterResolutions[ comboPrintResolution->SelectedIndex ];
         }

         // Print the document with the specified paper size, source, and print resolution.
         printDoc->Print();
      }