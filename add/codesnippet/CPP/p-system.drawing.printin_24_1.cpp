         // Add list of printer resolutions found on the printer to the combobox.
         // The PrinterResolution's ToString() method will be used to provide the display String.
         PrinterResolution^ pkResolution;
         for ( int i = 0; i < printDoc->PrinterSettings->PrinterResolutions->Count; i++ )
         {
            pkResolution = printDoc->PrinterSettings->PrinterResolutions[ i ];
            comboPrintResolution->Items->Add( pkResolution );
         }