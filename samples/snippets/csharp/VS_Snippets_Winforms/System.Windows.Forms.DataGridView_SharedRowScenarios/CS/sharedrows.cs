//<Snippet0>
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

class SharedRows : Form
{
    private DataGridView dataGridView1 = new DataGridView();
    private Label counterLabel = new Label();
    private Label description = new Label();
    private FlowLayoutPanel leftToRight = new FlowLayoutPanel();
    private FlowLayoutPanel topToBottom = new FlowLayoutPanel();

    public SharedRows()
    {
        this.Load += new EventHandler(SharedRows_Load);
        this.AutoSize = true;
        this.Controls.Add(topToBottom);
    }

    [STAThreadAttribute()]
    static void Main()
    {
        Application.Run(new SharedRows());
    }

    private void SharedRows_Load(object ignored, EventArgs e)
    {
        counterLabel.Text = "Unshared Rows: ";
        counterLabel.AutoSize = true;
        count.AutoSize = true;

        description.MaximumSize = new Size(600, 300);
        description.AutoSize = true;
        description.Text =
            "Try out the contextual menu, and hovering over the cells in the 'ReportsTo' column. " +
            "Notice what happens when trying to lookup a picture cell. " +
            "Row unsharing is minimized through the use of events.";

        leftToRight.FlowDirection = FlowDirection.LeftToRight;
        leftToRight.Controls.AddRange(new Control[] { dataGridView1, counterLabel, count });
        leftToRight.AutoSize = true;

        topToBottom.FlowDirection = FlowDirection.TopDown;
        topToBottom.AutoSize = true;
        topToBottom.Controls.AddRange(new Control[] { leftToRight, description });

        dataGridView1.MaximumSize = new Size(500, 300);
        dataGridView1.AutoSize = true;
        dataGridView1.MultiSelect = false;
        dataGridView1.ReadOnly = true;
        dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.AllowUserToDeleteRows = false;
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        wholeTable.Click += new EventHandler(wholeTable_Click);
        lookUp.Click += new EventHandler(lookUp_Click);
        dataGridView1.RowUnshared +=
            new DataGridViewRowEventHandler(dataGridView1_RowUnshared);
        dataGridView1.CellMouseEnter +=
            new DataGridViewCellEventHandler(dataGridView1_CellMouseEnter);
        dataGridView1.CellErrorTextNeeded +=
            new DataGridViewCellErrorTextNeededEventHandler(dataGridView1_CellErrorTextNeeded);
        dataGridView1.CellContextMenuStripNeeded +=
            new DataGridViewCellContextMenuStripNeededEventHandler(dataGridView1_CellContextMenuStripNeeded);
        dataGridView1.CellToolTipTextNeeded +=
            new DataGridViewCellToolTipTextNeededEventHandler(dataGridView1_CellToolTipTextNeeded);

        dataGridView1.DataSource = Populate("Select * from employees", true);
    }

    //<Snippet20>
    //<Snippet22>
    //<Snippet24>
    private ToolStripMenuItem wholeTable = new ToolStripMenuItem();
    private ToolStripMenuItem lookUp = new ToolStripMenuItem();
    private ContextMenuStrip strip;
    private string cellErrorText;

    private void dataGridView1_CellContextMenuStripNeeded(object sender,
        DataGridViewCellContextMenuStripNeededEventArgs e)
    {
        cellErrorText = String.Empty;

        if (strip == null)
        {
            strip = new ContextMenuStrip();
            lookUp.Text = "Look Up";
            wholeTable.Text = "See Whole Table";
            strip.Items.Add(lookUp);
            strip.Items.Add(wholeTable);
        }
        e.ContextMenuStrip = strip;
    }

    private void wholeTable_Click(object sender, EventArgs e)
    {
        dataGridView1.DataSource = Populate("Select * from employees", true);
    }

    private DataGridViewCellEventArgs theCellImHoveringOver;

    private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
    {
        theCellImHoveringOver = e;
    }

    private DataGridViewCellEventArgs cellErrorLocation;

    private void lookUp_Click(object sender, EventArgs e)
    {
        try
        {
            dataGridView1.DataSource = Populate("Select * from employees where " +
                dataGridView1.Columns[theCellImHoveringOver.ColumnIndex].Name + " = '" +
                dataGridView1.Rows[theCellImHoveringOver.RowIndex].
                Cells[theCellImHoveringOver.ColumnIndex].Value + "'",
                true);
        }
        catch (SqlException)
        {
            cellErrorText = "Can't look this cell up";
            cellErrorLocation = theCellImHoveringOver;
        }
    }

    private void dataGridView1_CellErrorTextNeeded(object sender,
        DataGridViewCellErrorTextNeededEventArgs e)
    {
        if (cellErrorLocation != null)
        {
            if (e.ColumnIndex == cellErrorLocation.ColumnIndex &&
                e.RowIndex == cellErrorLocation.RowIndex)
            {
                e.ErrorText = cellErrorText;
            }
        }
    }

    //<Snippet30>
    private DataTable Populate(string query, bool resetUnsharedCounter)
    {
        if (resetUnsharedCounter)
        {
            ResetCounter();
        }

        // Alter the data source as necessary
        SqlDataAdapter adapter = new SqlDataAdapter(query,
            new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;" +
            "Initial Catalog=Northwind;Data Source=localhost"));

        DataTable table = new DataTable();
        table.Locale = System.Globalization.CultureInfo.InvariantCulture;
        adapter.Fill(table);
        return table;
    }

    private Label count = new Label();
    private int unsharedRowCounter;

    private void ResetCounter()
    {
        unsharedRowCounter = 0;
        count.Text = unsharedRowCounter.ToString();
    }
    //</Snippet24>
    //</Snippet22>
    //</Snippet20>

    private void dataGridView1_CellToolTipTextNeeded(object sender,
        DataGridViewCellToolTipTextNeededEventArgs e)
    {

        if (theCellImHoveringOver.ColumnIndex == dataGridView1.Columns["ReportsTo"].Index &&
            theCellImHoveringOver.RowIndex > -1)
        {

            string reportsTo = dataGridView1.Rows[theCellImHoveringOver.RowIndex].
                Cells[theCellImHoveringOver.ColumnIndex].Value.ToString();

            if (String.IsNullOrEmpty(reportsTo))
            {
                e.ToolTipText = "The buck stops here!";
            }
            else
            {
                DataTable table = Populate(
                    "select firstname, lastname from employees where employeeid = '" +
                    dataGridView1.Rows[theCellImHoveringOver.RowIndex].
                    Cells[theCellImHoveringOver.ColumnIndex].Value.ToString() +
                    "'", false);

                e.ToolTipText = "Reports to " + table.Rows[0].ItemArray[0] + " " +
                    table.Rows[0].ItemArray[1];
            }
        }
    }
    //</Snippet30>

    private void dataGridView1_RowUnshared(object sender, DataGridViewRowEventArgs row)
    {
        unsharedRowCounter += 1;
        count.Text = unsharedRowCounter.ToString();
    }
}
//</Snippet0>
