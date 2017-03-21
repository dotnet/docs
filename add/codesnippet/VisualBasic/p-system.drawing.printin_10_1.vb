 Public Sub Printing(printer As String)
     Try
         streamToPrint = New StreamReader(filePath)
         Try
             printFont = New Font("Arial", 10)
             Dim pd As New PrintDocument()
             AddHandler pd.PrintPage, AddressOf pd_PrintPage
             ' Specify the printer to use.
             pd.PrinterSettings.PrinterName = printer

             If pd.PrinterSettings.IsValid then
                pd.Print()
             Else
                MessageBox.Show("Printer is invalid.")
             End If
         Finally
             streamToPrint.Close()
         End Try
     Catch ex As Exception
         MessageBox.Show(ex.Message)
     End Try
 End Sub
    