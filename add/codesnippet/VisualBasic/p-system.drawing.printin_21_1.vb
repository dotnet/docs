 Public Sub Printing()
     Try
         streamToPrint = New StreamReader(filePath)
         Try
             printFont = New Font("Arial", 10)
             Dim pd As New PrintDocument()
             AddHandler pd.PrintPage, AddressOf pd_PrintPage
             pd.PrinterSettings.PrinterName = printer
             ' Create a new instance of Margins with 1-inch margins.
             Dim margins As New Margins(100, 100, 100, 100)
             pd.DefaultPageSettings.Margins = margins
             pd.Print()
         Finally
             streamToPrint.Close()
         End Try
     Catch ex As Exception
         MessageBox.Show(ex.Message)
     End Try
 End Sub 'Printing
       