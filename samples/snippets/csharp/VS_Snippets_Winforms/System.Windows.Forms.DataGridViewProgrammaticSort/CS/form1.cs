//<snippet00>
using System;
using System.ComponentModel;
using System.Windows.Forms;

class Form1 : Form
{
    private Button sortButton = new Button();
    private DataGridView dataGridView1 = new DataGridView();

    // Initializes the form.
    // You can replace this code with designer-generated code.
    public Form1()
    {
        dataGridView1.Dock = DockStyle.Fill;
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.SelectionMode =
            DataGridViewSelectionMode.ColumnHeaderSelect;
        dataGridView1.MultiSelect = false;

        sortButton.Dock = DockStyle.Bottom;
        sortButton.Text = "Sort";

        Controls.Add(dataGridView1);
        Controls.Add(sortButton);
        Text = "DataGridView programmatic sort demo";
    }

    // Establishes the main entry point for the application.
    [STAThreadAttribute()]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Form1());
    }

    //<snippet20>
    // Populates the DataGridView.
    // Replace this with your own code to populate the DataGridView.
    public void PopulateDataGridView()
    {
        // Add columns to the DataGridView.
        dataGridView1.ColumnCount = 2;
        dataGridView1.Columns[0].HeaderText = "Last Name";
        dataGridView1.Columns[1].HeaderText = "City";
        // Put the new columns into programmatic sort mode
        dataGridView1.Columns[0].SortMode = 
            DataGridViewColumnSortMode.Programmatic;
        dataGridView1.Columns[1].SortMode =
            DataGridViewColumnSortMode.Programmatic;

        // Populate the DataGridView.
        dataGridView1.Rows.Add(new string[] { "Parker", "Seattle" });
        dataGridView1.Rows.Add(new string[] { "Watson", "Seattle" });
        dataGridView1.Rows.Add(new string[] { "Osborn", "New York" });
        dataGridView1.Rows.Add(new string[] { "Jameson", "New York" });
        dataGridView1.Rows.Add(new string[] { "Brock", "New Jersey" });
    }
    //</snippet20>

    protected override void OnLoad(EventArgs e)
    {
        sortButton.Click += new EventHandler(sortButton_Click);

        PopulateDataGridView();
        base.OnLoad(e);
    }

    //<snippet10>
    private void sortButton_Click(object sender, System.EventArgs e)
    {
        // Check which column is selected, otherwise set NewColumn to null.
        DataGridViewColumn newColumn =
            dataGridView1.Columns.GetColumnCount(
            DataGridViewElementStates.Selected) == 1 ?
            dataGridView1.SelectedColumns[0] : null;

        DataGridViewColumn oldColumn = dataGridView1.SortedColumn;
        ListSortDirection direction;

        // If oldColumn is null, then the DataGridView is not currently sorted.
        if (oldColumn != null)
        {
            // Sort the same column again, reversing the SortOrder.
            if (oldColumn == newColumn &&
                dataGridView1.SortOrder == SortOrder.Ascending)
            {
                direction = ListSortDirection.Descending;
            }
            else
            {
                // Sort a new column and remove the old SortGlyph.
                direction = ListSortDirection.Ascending;
                oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
            }
        }
        else
        {
            direction = ListSortDirection.Ascending;
        }

        // If no column has been selected, display an error dialog  box.
        if (newColumn == null)
        {
            MessageBox.Show("Select a single column and try again.",
                "Error: Invalid Selection", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        else
        {
            dataGridView1.Sort(newColumn, direction);
            newColumn.HeaderCell.SortGlyphDirection =
                direction == ListSortDirection.Ascending ?
                SortOrder.Ascending : SortOrder.Descending;
        }
    }
    //</snippet10>
}
//</snippet00>