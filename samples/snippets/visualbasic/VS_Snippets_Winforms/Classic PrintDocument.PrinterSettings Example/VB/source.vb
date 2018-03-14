Imports System
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected printer As String
    
    Private printFont As Font
    Private streamToPrint As StreamReader
    Protected Shared filePath As String    
    
' <Snippet1>
 Public Sub Printing()
     Try
         streamToPrint = New StreamReader(filePath)
         Try
             printFont = New Font("Arial", 10)
             Dim pd As New PrintDocument()
             AddHandler pd.PrintPage, AddressOf pd_PrintPage
             ' Specify the printer to use.
             pd.PrinterSettings.PrinterName = printer
             pd.Print()
         Finally
                streamToPrint.Close()
         End Try
     Catch ex As Exception
         MessageBox.Show(ex.Message)
     End Try
 End Sub    
    
' </Snippet1>

    ' The PrintPage event is raised for each page to be printed.
    Private Sub pd_PrintPage(sender As Object, ev As PrintPageEventArgs)
        Dim linesPerPage As Single = 0
        Dim yPos As Single = 0
        Dim count As Integer = 0
        Dim leftMargin As Single = ev.MarginBounds.Left
        Dim topMargin As Single = ev.MarginBounds.Top
        Dim line As String = Nothing
        
        ' Calculate the number of lines per page.
        linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics)
        
        ' Iterate over the file, printing each line.
        While count < linesPerPage
            line = streamToPrint.ReadLine()
            If line Is Nothing Then
                Exit While
            End If
            yPos = topMargin + count * printFont.GetHeight(ev.Graphics)
            ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, New StringFormat())
            count += 1
        End While
        
        ' If more lines exist, print another page.
        If (line IsNot Nothing) Then
            ev.HasMorePages = True
        Else
            ev.HasMorePages = False
        End If
    End Sub 'pd_PrintPage
End Class 'Form1
