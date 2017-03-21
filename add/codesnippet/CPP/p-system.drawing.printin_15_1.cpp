         // Add list of paper sources found on the printer to the combo box.
         // The DisplayMember property is used to identify the property that will provide the display String*.
         comboPaperSource->DisplayMember = "SourceName";
         PaperSource^ pkSource;
         for ( int i = 0; i < printDoc->PrinterSettings->PaperSources->Count; i++ )
         {
            pkSource = printDoc->PrinterSettings->PaperSources[ i ];
            comboPaperSource->Items->Add( pkSource );
         }