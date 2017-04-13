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
                
             ' Set the left and right margins to 1 inch.
             pd.DefaultPageSettings.Margins.Left = 100
             pd.DefaultPageSettings.Margins.Right = 100
             ' Set the top and bottom margins to 1.5 inches.
             pd.DefaultPageSettings.Margins.Top = 150
             pd.DefaultPageSettings.Margins.Bottom = 150
                
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

