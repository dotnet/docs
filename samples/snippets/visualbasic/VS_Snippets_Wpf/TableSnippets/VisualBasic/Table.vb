Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Documents
Imports System.Threading

Namespace Table_Demo

    Public Class MyApp
        Inherits System.Windows.Application

        Dim flowDoc As New FlowDocument()
        Dim table1 as New Table()
        Dim mainWindow as New Window()

        Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
            MyBase.OnStartup(e)
            CreateAndShowMainWindow()
        End Sub

        Private Sub CreateAndShowMainWindow()

            ' Create the application's main window
            mainWindow = new System.Windows.Window()


            ' <Snippet_TableCreate>
            ' Create the parent FlowDocument...
            flowDoc = New FlowDocument()

            ' Create the Table...
            table1 = New Table()

            ' ...and add it to the FlowDocument Blocks collection.
            flowDoc.Blocks.Add(table1)


            ' Set some global formatting properties for the table.
            table1.CellSpacing = 10
            table1.Background = Brushes.White
            ' </Snippet_TableCreate>

            ' <Snippet_TableCreateColumns>
            ' Create 6 columns and add them to the table's Columns collection.
            Dim numberOfColumns = 6
            Dim x
            For x = 0 To numberOfColumns
                table1.Columns.Add(new TableColumn())

                ' Set alternating background colors for the middle colums.
                If x Mod 2 = 0 Then
                    table1.Columns(x).Background = Brushes.Beige
                Else
                    table1.Columns(x).Background = Brushes.LightSteelBlue
                End If
            Next x

            ' </Snippet_TableCreateColumns>

            ' <Snippet_TableAddTitleRow>
            ' Create and add an empty TableRowGroup to hold the table's Rows.
            table1.RowGroups.Add(new TableRowGroup())

            ' Add the first (title) row.
            table1.RowGroups(0).Rows.Add(new TableRow())

            ' Alias the current working row for easy reference.
            Dim currentRow As New TableRow()
            currentRow = table1.RowGroups(0).Rows(0)

            ' Global formatting for the title row.
            currentRow.Background = Brushes.Silver
            currentRow.FontSize = 40
            currentRow.FontWeight = System.Windows.FontWeights.Bold

            ' Add the header row with content, 
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("2004 Sales Project"))))
            ' and set the row to span all 6 columns.
            currentRow.Cells(0).ColumnSpan = 6
            ' </Snippet_TableAddTitleRow>

            ' <Snippet_TableAddHeaderRow>
            ' Add the second (header) row.
            table1.RowGroups(0).Rows.Add(new TableRow())
            currentRow = table1.RowGroups(0).Rows(1)

            ' Global formatting for the header row.
            currentRow.FontSize = 18
            currentRow.FontWeight = FontWeights.Bold

            ' Add cells with content to the second row.
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Product"))))
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Quarter 1"))))
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Quarter 2"))))
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Quarter 3"))))
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Quarter 4"))))
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("TOTAL"))))
            ' </Snippet_TableAddHeaderRow>

            ' <Snippet_TableAddDataRow>
            ' Add the third row.
            table1.RowGroups(0).Rows.Add(new TableRow())
            currentRow = table1.RowGroups(0).Rows(2)

            ' Global formatting for the row.
            currentRow.FontSize = 12
            currentRow.FontWeight = FontWeights.Normal

            ' Add cells with content to the third row.
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Widgets"))))
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("$50,000"))))
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("$55,000"))))
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("$60,000"))))
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("$65,000"))))
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("$230,000"))))

            ' Bold the first cell.
            currentRow.Cells(0).FontWeight = FontWeights.Bold
            ' </Snippet_TableAddDataRow>



            ' <Snippet_TableAddFooterRow>
            table1.RowGroups(0).Rows.Add(new TableRow())
            currentRow = table1.RowGroups(0).Rows(3)

            ' Global formatting for the footer row.
            currentRow.Background = Brushes.LightGray
            currentRow.FontSize = 18
            currentRow.FontWeight = System.Windows.FontWeights.Normal

            ' Add the header row with content, 
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Projected 2004 Revenue: $810,000"))))
            ' and set the row to span all 6 columns.
            currentRow.Cells(0).ColumnSpan = 6
            ' </Snippet_TableAddFooterRow>

            mainWindow.Content = flowDoc
            mainWindow.Show()
        End Sub
    End Class

    ' Starts the application.
    Public NotInheritable Class EntryClass

        Public Shared Sub Main()
            Dim app As New MyApp()
            app.Run()
        End Sub
    End Class

End Namespace

