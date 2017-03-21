 Public Sub Printing()
     Try
         streamToPrint = New StreamReader(filePath)
         Try
             printFont = New Font("Arial", 10)
             Dim pd As New PrintDocument()
             AddHandler pd.PrintPage, AddressOf pd_PrintPage
             pd.PrinterSettings.PrinterName = printer
             ' Set the page orientation to landscape.
             pd.DefaultPageSettings.Landscape = True
             pd.Print()
         Finally
             streamToPrint.Close()
         End Try
     Catch ex As Exception
         MessageBox.Show(ex.Message)
     End Try
 End Sub    
    