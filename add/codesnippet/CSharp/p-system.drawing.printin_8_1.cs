            // Add list of supported paper sizes found on the printer. 
            // The DisplayMember property is used to identify the property that will provide the display string.
            comboPaperSize.DisplayMember = "PaperName";

            PaperSize pkSize;
            for (int i = 0; i < printDoc.PrinterSettings.PaperSizes.Count; i++){
                pkSize = printDoc.PrinterSettings.PaperSizes[i];
                comboPaperSize.Items.Add(pkSize);
            }

            // Create a PaperSize and specify the custom paper size through the constructor and add to combobox.
            PaperSize pkCustomSize1 = new PaperSize("First custom size", 100, 200);

            comboPaperSize.Items.Add(pkCustomSize1);
