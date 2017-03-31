//<snippet00>
#region Using directives

using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

#endregion

class Form1 : Form
{
    private DataGridView dataGridView1 = new DataGridView();
    private ContextMenuStrip employeeMenuStrip = new ContextMenuStrip();
    private ContextMenuStrip managerMenuStrip = new ContextMenuStrip();
    private ToolStripMenuItem toolStripMenuItem1 = new ToolStripMenuItem();
    private ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem();
    private ToolStripMenuItem toolStripMenuItem3 = new ToolStripMenuItem();

    private int contextMenuRowIndex;

    public Form1()
    {
        // Initialize the form.
        // This code can be replaced with designer generated code.
        this.Size = new Size(700, 300);
        this.Controls.Add(dataGridView1);

        toolStripMenuItem1.Text = "View Employee Sales Report";
        toolStripMenuItem2.Text = "View Team Sales Report";
        toolStripMenuItem3.Text = "View Company Sales Team Ranking Report";
    }

    protected override void OnLoad(EventArgs e)
    {
        dataGridView1.DataBindingComplete +=
            new DataGridViewBindingCompleteEventHandler(
            dataGridView1_DataBindingComplete);
        dataGridView1.CellToolTipTextNeeded +=
            new DataGridViewCellToolTipTextNeededEventHandler(
            dataGridView1_CellToolTipTextNeeded);
        dataGridView1.RowContextMenuStripNeeded +=
            new DataGridViewRowContextMenuStripNeededEventHandler(
            dataGridView1_RowContextMenuStripNeeded);
        toolStripMenuItem1.Click +=
            new EventHandler(toolStripMenuItem1_Click);
        toolStripMenuItem2.Click +=
            new EventHandler(toolStripMenuItem2_Click);
        toolStripMenuItem3.Click +=
            new EventHandler(toolStripMenuItem3_Click);

        employeeMenuStrip.Items.Add(toolStripMenuItem1);

        managerMenuStrip.Items.Add(toolStripMenuItem2);
        managerMenuStrip.Items.Add(toolStripMenuItem3);

        PopulateDataGridView();

        base.OnLoad(e);
    }

    // Establish the main entry point for the application.
    [STAThreadAttribute()]
    public static void Main()
    {
        Application.Run(new Form1());
    }

    // Replace this with your own code to populate the DataGridView.
    private void PopulateDataGridView()
    {
        dataGridView1.Dock = DockStyle.Fill;
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.MultiSelect = false;
        dataGridView1.ReadOnly = true;
        dataGridView1.AllowUserToDeleteRows = false;

        string query;
        query = "SELECT e1.*, e2.FirstName + ' ' + e2.LastName AS Manager "
            + "FROM employees AS e1 LEFT JOIN employees AS e2 "
            + "ON e1.ReportsTo = e2.EmployeeID";

        // Connect to the database
        SqlConnection sqlConnection1 = new SqlConnection(
            "Integrated Security=SSPI;Persist Security Info=False;" +
            "Initial Catalog=Northwind;Data Source=localhost");
        SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(query,
            sqlConnection1);

        DataTable dataTable1 = new DataTable();
        dataTable1.Locale = System.Globalization.CultureInfo.InvariantCulture;
        sqlDataAdapter1.Fill(dataTable1);

        dataGridView1.DataSource = dataTable1;
    }

    //<snippet05>
    private void dataGridView1_DataBindingComplete(object sender,
        DataGridViewBindingCompleteEventArgs e)
    {
        // Hide some of the columns.
        dataGridView1.Columns["EmployeeID"].Visible = false;
        dataGridView1.Columns["Address"].Visible = false;
        dataGridView1.Columns["TitleOfCourtesy"].Visible = false;
        dataGridView1.Columns["BirthDate"].Visible = false;
        dataGridView1.Columns["HireDate"].Visible = false;
        dataGridView1.Columns["PostalCode"].Visible = false;
        dataGridView1.Columns["Photo"].Visible = false;
        dataGridView1.Columns["Notes"].Visible = false;
        dataGridView1.Columns["ReportsTo"].Visible = false;
        dataGridView1.Columns["PhotoPath"].Visible = false;

        // Disable sorting for the DataGridView.
        foreach (DataGridViewColumn i in
            dataGridView1.Columns)
        {
            i.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        dataGridView1.AutoResizeColumns();
    }
    //</snippet05>

    //<snippet10>
    void dataGridView1_RowContextMenuStripNeeded(object sender,
        DataGridViewRowContextMenuStripNeededEventArgs e)
    {
        DataGridViewRow dataGridViewRow1 = dataGridView1.Rows[e.RowIndex];

        toolStripMenuItem1.Enabled = true;

        // Show the appropriate ContextMenuStrip based on the employees title.
        if ((dataGridViewRow1.Cells["Title"].Value.ToString() ==
            "Sales Manager") ||
            (dataGridViewRow1.Cells["Title"].Value.ToString() ==
            "Vice President, Sales"))
        {
            e.ContextMenuStrip = managerMenuStrip;
        }
        else
        {
            e.ContextMenuStrip = employeeMenuStrip;
        }

        contextMenuRowIndex = e.RowIndex;
    }
    //</snippet10>

    //<snippet20>
    void dataGridView1_CellToolTipTextNeeded(object sender,
        DataGridViewCellToolTipTextNeededEventArgs e)
    {
        string newLine = Environment.NewLine;
        if (e.RowIndex > -1)
        {
            DataGridViewRow dataGridViewRow1 = dataGridView1.Rows[e.RowIndex];

            // Add the employee's ID to the ToolTipText.
            e.ToolTipText = String.Format("EmployeeID {0}:{1}",
                dataGridViewRow1.Cells["EmployeeID"].Value, newLine);

            // Add the employee's name to the ToolTipText.
            e.ToolTipText += String.Format("{0} {1} {2}{3}",
                dataGridViewRow1.Cells["TitleOfCourtesy"].Value.ToString(),
                dataGridViewRow1.Cells["FirstName"].Value.ToString(),
                dataGridViewRow1.Cells["LastName"].Value.ToString(),
                newLine);

            // Add the employee's title to the ToolTipText.
            e.ToolTipText += String.Format("{0}{1}{2}",
                dataGridViewRow1.Cells["Title"].Value.ToString(),
                newLine, newLine);

            // Add the employee's contact information to the ToolTipText.
            e.ToolTipText += String.Format("{0}{1}{2}, ",
                dataGridViewRow1.Cells["Address"].Value.ToString(), newLine,
                dataGridViewRow1.Cells["City"].Value.ToString());
            if (!String.IsNullOrEmpty(
                dataGridViewRow1.Cells["Region"].Value.ToString()))
            {
                e.ToolTipText += String.Format("{0}, ",
                    dataGridViewRow1.Cells["Region"].Value.ToString());
            }
            e.ToolTipText += String.Format("{0}, {1}{2}{3} EXT:{4}{5}{6}",
                dataGridViewRow1.Cells["Country"].Value.ToString(),
                dataGridViewRow1.Cells["PostalCode"].Value.ToString(),
                newLine, dataGridViewRow1.Cells["HomePhone"].Value.ToString(),
                dataGridViewRow1.Cells["Extension"].Value.ToString(),
                newLine, newLine);

            // Add employee information to the ToolTipText.
            DateTime HireDate =
                (DateTime)dataGridViewRow1.Cells["HireDate"].Value;
            e.ToolTipText +=
                String.Format("Employee since: {0}/{1}/{2}{3}Manager: {4}",
                HireDate.Month.ToString(), HireDate.Day.ToString(),
                HireDate.Year.ToString(), newLine,
                dataGridViewRow1.Cells["Manager"].Value.ToString());
        }
    }
    //</snippet20>

    void toolStripMenuItem1_Click(object sender, EventArgs e)
    {
        DataGridViewRow dataGridViewRow1 =
            dataGridView1.Rows[contextMenuRowIndex];

        MessageBox.Show(String.Format(
            "Sales Report for {0} {1}{2}{3}Reporting not implemented.",
            dataGridViewRow1.Cells["FirstName"].Value.ToString(),
            dataGridViewRow1.Cells["LastName"].Value.ToString(),
            Environment.NewLine, Environment.NewLine));
    }

    void toolStripMenuItem2_Click(object sender, EventArgs e)
    {
        DataGridViewRow dataGridViewRow1 =
            dataGridView1.Rows[contextMenuRowIndex];
        MessageBox.Show(String.Format(
            "Sales Report for {0} {1}'s Team{2}{3}Reporting not implemented.",
            dataGridViewRow1.Cells["FirstName"].Value.ToString(),
            dataGridViewRow1.Cells["LastName"].Value.ToString(),
            Environment.NewLine, Environment.NewLine));
    }

    void toolStripMenuItem3_Click(object sender, EventArgs e)
    {
        DataGridViewRow dataGridViewRow1 =
            dataGridView1.Rows[contextMenuRowIndex];
        MessageBox.Show(String.Format(
            "Company Sales Ranking Report:{0}{1}Reporting not implemented.",
            Environment.NewLine, Environment.NewLine));
    }
}
//</snippet00>
