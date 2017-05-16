Imports System
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO
Imports System.Windows.Forms

Public Class Sample
    
    Protected streamToPrint As StreamReader
    Protected printFont As Font
    Protected filePath As String
    Protected printer As String   
    
' <Snippet1>
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
        
' </Snippet1>

    ' Method added so sample will compile
    Private Sub pd_PrintPage(sender As Object, e As PrintPageEventArgs)    
    End Sub
    
End Class
