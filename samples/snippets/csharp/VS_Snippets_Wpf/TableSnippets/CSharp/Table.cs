using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Documents;
using System.Threading;

namespace Table_Demo
{
	public class MyApp : System.Windows.Application
	{
            // System.Windows.Documents.TextFlow tf1;
        FlowDocument flowDoc;
        	System.Windows.Documents.Table table1;
		    System.Windows.Window mainWindow;

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			CreateAndShowMainWindow();
		}

		private void CreateAndShowMainWindow()
        {
            // Create the application's main window
            mainWindow = new System.Windows.Window();

            // <Snippet_TableCreate>
            // Create the parent FlowDocument...
            flowDoc = new FlowDocument();

            // Create the Table...
            table1 = new Table();
            // ...and add it to the FlowDocument Blocks collection.
            flowDoc.Blocks.Add(table1);

            // Set some global formatting properties for the table.
            table1.CellSpacing = 10;
            table1.Background = Brushes.White;
            // </Snippet_TableCreate>

            // <Snippet_TableCreateColumns>
            // Create 6 columns and add them to the table's Columns collection.
            int numberOfColumns = 6;
            for (int x = 0; x < numberOfColumns; x++)
            {
                table1.Columns.Add(new TableColumn());

                // Set alternating background colors for the middle colums.
                if(x%2 == 0)
                    table1.Columns[x].Background = Brushes.Beige;
                else
                    table1.Columns[x].Background = Brushes.LightSteelBlue;
            }

            // </Snippet_TableCreateColumns>

            // <Snippet_TableAddTitleRow>
            // Create and add an empty TableRowGroup to hold the table's Rows.
            table1.RowGroups.Add(new TableRowGroup());

            // Add the first (title) row.
            table1.RowGroups[0].Rows.Add(new TableRow());

            // Alias the current working row for easy reference.
            TableRow currentRow = table1.RowGroups[0].Rows[0];

            // Global formatting for the title row.
            currentRow.Background = Brushes.Silver;
            currentRow.FontSize = 40;
            currentRow.FontWeight = System.Windows.FontWeights.Bold;

            // Add the header row with content,
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("2004 Sales Project"))));
            // and set the row to span all 6 columns.
            currentRow.Cells[0].ColumnSpan = 6;
            // </Snippet_TableAddTitleRow>

            // <Snippet_TableAddHeaderRow>
            // Add the second (header) row.
            table1.RowGroups[0].Rows.Add(new TableRow());
            currentRow = table1.RowGroups[0].Rows[1];

            // Global formatting for the header row.
            currentRow.FontSize = 18;
            currentRow.FontWeight = FontWeights.Bold;

            // Add cells with content to the second row.
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Product"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Quarter 1"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Quarter 2"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Quarter 3"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Quarter 4"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("TOTAL"))));
            // </Snippet_TableAddHeaderRow>

            // <Snippet_TableAddDataRow>
            // Add the third row.
            table1.RowGroups[0].Rows.Add(new TableRow());
            currentRow = table1.RowGroups[0].Rows[2];

            // Global formatting for the row.
            currentRow.FontSize = 12;
            currentRow.FontWeight = FontWeights.Normal;

            // Add cells with content to the third row.
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Widgets"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("$50,000"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("$55,000"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("$60,000"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("$65,000"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("$230,000"))));

            // Bold the first cell.
            currentRow.Cells[0].FontWeight = FontWeights.Bold;
            // </Snippet_TableAddDataRow>

            // <Snippet_TableAddFooterRow>
            table1.RowGroups[0].Rows.Add(new TableRow());
            currentRow = table1.RowGroups[0].Rows[3];

            // Global formatting for the footer row.
            currentRow.Background = Brushes.LightGray;
            currentRow.FontSize = 18;
            currentRow.FontWeight = System.Windows.FontWeights.Normal;

            // Add the header row with content,
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Projected 2004 Revenue: $810,000"))));
            // and set the row to span all 6 columns.
            currentRow.Cells[0].ColumnSpan = 6;
            // </Snippet_TableAddFooterRow>

            mainWindow.Content = flowDoc;
            mainWindow.Show();
        }
	}

	internal static class EntryClass
	{
		[System.STAThread()]
		private static void Main ()
		{
			MyApp app = new MyApp ();
			app.Run ();
		}
	}
}
