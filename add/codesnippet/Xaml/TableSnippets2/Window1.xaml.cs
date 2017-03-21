using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TableSnippets
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();

            TableRowGroupsProperty();
        }

        void WindowLoaded(Object sender, RoutedEventArgs args)
        {
            TableColumnsProperty();
            TableRowGroupsProperty();
            TableRowGroupRows();
            TableCellConst();
        }

        void TableColumnsProperty()
        {

            // <Snippet_Table_Columns_Add>
            Table tbl = new Table();
            int columnsToAdd = 4;
            for (int x = 0; x < columnsToAdd; x++)
                tbl.Columns.Add(new TableColumn());
            // </Snippet_Table_Columns_Add>

            // Insert a new first column.
            // <Snippet_Table_Columns_Insert>
            tbl.Columns.Insert(0, new TableColumn());
            // </Snippet_Table_Columns_Insert>

            // Manipulating columns.
            // <Snippet_Table_Columns_Manip>
            tbl.Columns[0].Width = new GridLength(20);
            tbl.Columns[1].Background = Brushes.AliceBlue;
            tbl.Columns[2].Width = new GridLength(20);
            tbl.Columns[3].Background = Brushes.AliceBlue;
            // </Snippet_Table_Columns_Manip>

            // Get a count of columns hosted by the table.
            // <Snippet_Table_Columns_Count>
            int columns = tbl.Columns.Count;
            // </Snippet_Table_Columns_Count>

            // Remove a particular column by reference (the 4th).
            // <Snippet_Table_Columns_DelRef>
            tbl.Columns.Remove(tbl.Columns[3]);
            // </Snippet_Table_Columns_DelRef>

            // Remove a particular column by index (the 3rd).
            // <Snippet_Table_Columns_DelIndex>
            tbl.Columns.RemoveAt(2);
            // </Snippet_Table_Columns_DelIndex>

            // Remove all columns from the table's columns collection.
            // <Snippet_Table_Columns_Clear>
            tbl.Columns.Clear();
            // </Snippet_Table_Columns_Clear>
        }

        void TableRowGroupsProperty()
        {
            // Add rowgroups...
            // <Snippet_Table_RowGroups_Add>
            Table tbl = new Table();
            int rowGroupsToAdd = 4;
            for (int x = 0; x < rowGroupsToAdd; x++)
                tbl.RowGroups.Add(new TableRowGroup());
            // </Snippet_Table_RowGroups_Add>

            // Insert rowgroup...
            // <Snippet_Table_RowGroups_Insert>
            tbl.RowGroups.Insert(0, new TableRowGroup());
            // </Snippet_Table_RowGroups_Insert>

            // Adding rows to a rowgroup...
            {
                // <Snippet_Table_RowGroups_AddRows>
                int rowsToAdd = 10;
                for (int x = 0; x < rowsToAdd; x++)
                    tbl.RowGroups[0].Rows.Add(new TableRow());
                // </Snippet_Table_RowGroups_AddRows>
            }

            // Manipulating rows (through rowgroups)...

            // <Snippet_Table_RowGroups_ManipRows>
            // Alias the working TableRowGroup for ease in referencing.
            TableRowGroup trg = tbl.RowGroups[0];
            trg.Rows[0].Background = Brushes.CornflowerBlue;
            trg.Rows[1].FontSize = 24;
            trg.Rows[2].ToolTip = "This row's tooltip";
            // </Snippet_Table_RowGroups_ManipRows>

            // Adding cells to a row...
            {
                // <Snippet_Table_RowGroups_AddCells>
                int cellsToAdd = 10;
                for (int x = 0; x < cellsToAdd; x++)
                    tbl.RowGroups[0].Rows[0].Cells.Add(new TableCell(new Paragraph(new Run("Cell " + (x + 1)))));
                // </Snippet_Table_RowGroups_AddCells>
            }

            // Manipulating cells (through rowgroups)...

            // <Snippet_Table_RowGroups_ManipCells>
            // Alias the working for for ease in referencing.
            TableRow row = tbl.RowGroups[0].Rows[0];
            row.Cells[0].Background = Brushes.PapayaWhip;
            row.Cells[1].FontStyle = FontStyles.Italic;
            // This call clears all of the content from this cell.
            row.Cells[2].Blocks.Clear();
            // </Snippet_Table_RowGroups_ManipCells>

            // Count rowgroups...
            // <Snippet_Table_RowGroups_Count>
            int rowGroups = tbl.RowGroups.Count;
            // </Snippet_Table_RowGroups_Count>

            // Remove rowgroup by ref...
            // <Snippet_Table_RowGroups_DelRef>
            tbl.RowGroups.Remove(tbl.RowGroups[0]);
            // </Snippet_Table_RowGroups_DelRef>

            // Remove rowgroup by index...
            // <Snippet_Table_RowGroups_DelIndex>
            tbl.RowGroups.RemoveAt(0);
            // </Snippet_Table_RowGroups_DelIndex>

            // Remove all rowgroups...
            // <Snippet_Table_RowGroups_Clear>
            tbl.RowGroups.Clear();
            // </Snippet_Table_RowGroups_Clear>
        }

        void TableRowGroupRows()
        {
            // <Snippet_TableRowGroup_Rows>
            Table tbl = new Table();
            TableRowGroup trg = new TableRowGroup();

            tbl.RowGroups.Add(trg);

            // Add rows to a TableRowGroup collection.
            int rowsToAdd = 4; 
            for (int x = 0; x < rowsToAdd; x++)
                trg.Rows.Add(new TableRow());

            // Insert a new first row (at the zero-index position).
            trg.Rows.Insert(0, new TableRow());

            // Manipulate rows...

            // Set the background on the first row.
            trg.Rows[0].Background = Brushes.CornflowerBlue;
            // Set the font size on the second row.
            trg.Rows[1].FontSize = 24;
            // Set a tooltip for the third row.
            trg.Rows[2].ToolTip = "This row's tooltip";

            // Adding cells to a row...
            {
                int cellsToAdd = 10;
                for (int x = 0; x < cellsToAdd; x++)
                    trg.Rows[0].Cells.Add(new TableCell(new Paragraph(new Run("Cell " + (x + 1)))));
            }

            // Count rows.
            int rows = trg.Rows.Count;

            // Remove 1st row by reference.
            trg.Rows.Remove(trg.Rows[0]);

            // Remove all rows...
            trg.Rows.Clear();
            // </Snippet_TableRowGroup_Rows>        
        }

        void TableCellConst()
        {
            // <Snippet_TableCell_Const1>
            // A child Block element for the new TableCell element.
            Paragraph parx = new Paragraph(new Run("A bit of text content..."));

            // After this line executes, the new element "cellx"
            // contains the specified Block element, "parx".
            TableCell cellx = new TableCell(parx);
            // </Snippet_TableCell_Const1>
        }
    }
}