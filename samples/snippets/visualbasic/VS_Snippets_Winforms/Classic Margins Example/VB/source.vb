Imports System
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms

Public Class Sample
    Inherits Form
    
    Protected streamToPrint As StreamReader
    Protected filePath As String
    Protected printer As String
    Protected printFont As Font
   
    
' <Snippet1>
 Public Sub Printing()
     Try
         ' This assumes that a variable of type string, named filePath,
         ' has been set to the path of the file to print. 
         streamToPrint = New StreamReader(filePath)
         Try
             printFont = New Font("Arial", 10)
             Dim pd As New PrintDocument()
             ' This assumes that a method, named pd_PrintPage, has been
             ' defined. pd_PrintPage handles the PrintPage event. 
             AddHandler pd.PrintPage, AddressOf pd_PrintPage
             ' This assumes that a variable of type string, named
             ' printer, has been set to the printer's name. 
             pd.PrinterSettings.PrinterName = printer
             ' Create a new instance of Margins with one inch margins.
             Dim margins As New Margins(100, 100, 100, 100)
             pd.DefaultPageSettings.Margins = margins
             pd.Print()
         Finally
             streamToPrint.Close()
         End Try
     Catch ex As Exception
         MessageBox.Show("An error occurred printing the file - " & ex.Message)
     End Try
 End Sub
    
' </Snippet1>

    Private Sub pd_PrintPage(sender As Object, e As PrintPageEventArgs)
    End Sub
End Class
