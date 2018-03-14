 '<snippet0>
Imports System
Imports System.Drawing
Imports System.IO
Imports System.Drawing.Printing
Imports System.Windows.Forms



Class Form1
    Inherits Form

    Private WithEvents printPreviewButton As Button
    
    '<snippet1>
    Private printPreviewDialog1 As New PrintPreviewDialog()
    Private WithEvents printDocument1 As New PrintDocument()
    
    ' Declare a string to hold the entire document contents.
    Private documentContents As String
    
    ' Declare a variable to hold the portion of the document that
    ' is not printed.
    Private stringToPrint As String
    '</snippet1>

    Public Sub New() 
        Me.printPreviewButton = New System.Windows.Forms.Button()
        Me.printPreviewButton.Location = New System.Drawing.Point(12, 12)
        Me.printPreviewButton.Size = New System.Drawing.Size(125, 23)
        Me.printPreviewButton.Text = "Print Preview"
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.printPreviewButton)

    End Sub
    
    '<snippet2>
    Private Sub ReadDocument() 
        Dim docName As String = "testPage.txt"
        Dim docPath As String = "c:\"
        printDocument1.DocumentName = docName
        Dim stream As New FileStream(docPath + docName, FileMode.Open)
        Try
            Dim reader As New StreamReader(stream)
            Try
                documentContents = reader.ReadToEnd()
            Finally
                reader.Dispose()
            End Try
        Finally
            stream.Dispose()
        End Try
        stringToPrint = documentContents
    
    End Sub
    '</snippet2>

    '<snippet3>
    Sub printDocument1_PrintPage(ByVal sender As Object, _
        ByVal e As PrintPageEventArgs) Handles printDocument1.PrintPage

        Dim charactersOnPage As Integer = 0
        Dim linesPerPage As Integer = 0

        ' Sets the value of charactersOnPage to the number of characters 
        ' of stringToPrint that will fit within the bounds of the page.
        e.Graphics.MeasureString(stringToPrint, Me.Font, e.MarginBounds.Size, _
            StringFormat.GenericTypographic, charactersOnPage, linesPerPage)

        ' Draws the string within the bounds of the page.
        e.Graphics.DrawString(stringToPrint, Me.Font, Brushes.Black, _
            e.MarginBounds, StringFormat.GenericTypographic)

        ' Remove the portion of the string that has been printed.
        stringToPrint = stringToPrint.Substring(charactersOnPage)

        ' Check to see if more pages are to be printed.
        e.HasMorePages = stringToPrint.Length > 0

        ' If there are no more pages, reset the string to be printed.
        If Not e.HasMorePages Then
            stringToPrint = documentContents
        End If

    End Sub
    '</snippet3>

    '<snippet4>
    Private Sub printPreviewButton_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles printPreviewButton.Click

        ReadDocument()
        '<snippet5>
        printPreviewDialog1.Document = printDocument1
        '</snippet5>
        printPreviewDialog1.ShowDialog()
    End Sub
    '</snippet4>

    <STAThread()>  _
    Shared Sub Main() 
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New Form1())
    
    End Sub
End Class 
'</snippet0>