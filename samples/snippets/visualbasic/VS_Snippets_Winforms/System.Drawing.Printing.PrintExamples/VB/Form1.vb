 '<snippet0>
Imports System
Imports System.Drawing
Imports System.IO
Imports System.Drawing.Printing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Private printButton As Button

    '<snippet8>
    Private printDocument1 As New PrintDocument()
    Private stringToPrint As String
    '</snippet8>

    Public Sub New() 
        Me.printButton = New System.Windows.Forms.Button()
        Me.printButton.Location = New System.Drawing.Point(12, 51)
        Me.printButton.Size = New System.Drawing.Size(75, 23)
        Me.printButton.Text = "Print"
        Me.ClientSize = New System.Drawing.Size(292, 266)
    End Sub

    Private Sub ReadFile() 
        '<snippet1>
        Dim docName As String = "testPage.txt"
        Dim docPath As String = "c:\"
        printDocument1.DocumentName = docName
        Dim stream As New FileStream(docPath + docName, FileMode.Open)
        Try
            Dim reader As New StreamReader(stream)
            Try
                stringToPrint = reader.ReadToEnd()
            Finally
                reader.Dispose()
            End Try
        Finally
            stream.Dispose()
        End Try
     '</snippet1>
    End Sub
    
    '<snippet2>
    Private Sub printDocument1_PrintPage(ByVal sender As Object, _
        ByVal e As PrintPageEventArgs)

        Dim charactersOnPage As Integer = 0
        Dim linesPerPage As Integer = 0

        ' Sets the value of charactersOnPage to the number of characters 
        ' of stringToPrint that will fit within the bounds of the page.
        e.Graphics.MeasureString(stringToPrint, Me.Font, e.MarginBounds.Size, _
            StringFormat.GenericTypographic, charactersOnPage, linesPerPage)

        ' Draws the string within the bounds of the page
        e.Graphics.DrawString(stringToPrint, Me.Font, Brushes.Black, _
            e.MarginBounds, StringFormat.GenericTypographic)

        ' Remove the portion of the string that has been printed.
        stringToPrint = stringToPrint.Substring(charactersOnPage)

        ' Check to see if more pages are to be printed.
        e.HasMorePages = stringToPrint.Length > 0

    End Sub
    '</snippet2>

    Private Sub printButton_Click(ByVal sender As Object, ByVal e As EventArgs) 
        ReadFile()
        '<snippet5>
        printDocument1.Print()
        '</snippet5>
    End Sub

    
    <STAThread()>  _
    Shared Sub Main() 
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New Form1())
    End Sub
End Class
'</snippet0>