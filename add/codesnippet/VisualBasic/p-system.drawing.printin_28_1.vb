
    Private Sub MyButtonPrint_OnClick(ByVal sender As Object, ByVal e As System.EventArgs)

        ' Set the printer name and ensure it is valid. If not, provide a message to the user.
        printDoc.PrinterSettings.PrinterName = "\\mynetworkprinter"

        If printDoc.PrinterSettings.IsValid Then

            ' If the printer supports printing in color, then override the printer's default behavior.
            if printDoc.PrinterSettings.SupportsColor then

                ' Set the page default's to not print in color.
                printDoc.DefaultPageSettings.Color = False
            End If

            ' Provide a friendly name, set the page number, and print the document.
            printDoc.DocumentName = "My Presentation"
            currentPageNumber = 1
            printDoc.Print()
        Else
            MessageBox.Show("Printer is not valid")
        End If
    End Sub

    Private Sub MyPrintQueryPageSettingsEvent(ByVal sender As Object, ByVal e As QueryPageSettingsEventArgs)

        ' Determines if the printer supports printing in color.
        If printDoc.PrinterSettings.SupportsColor Then

            ' If the printer supports color printing, use color.
            If currentPageNumber = 1 Then

                e.PageSettings.Color = True
            End If

        End If
    End Sub
