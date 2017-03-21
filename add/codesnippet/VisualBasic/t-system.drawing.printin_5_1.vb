        ' Add list of printer resolutions found on the printer to the combobox.
        ' The PrinterResolution's ToString() method will be used to provide the display string.
        Dim pkResolution As PrinterResolution
        For i = 0 to printDoc.PrinterSettings.PrinterResolutions.Count - 1
            pkResolution = printDoc.PrinterSettings.PrinterResolutions.Item(i)
            comboPrintResolution.Items.Add(pkResolution)
        Next