//<Snippet00>
//<Snippet01>
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

public class Form1 : System.Windows.Forms.Form
{
    private DataGridView dataGridView1 = new DataGridView();
    private BindingSource bindingSource1 = new BindingSource();

    public Form1()
    {
        // Initialize the form.
        this.dataGridView1.Dock = DockStyle.Fill;
        this.Controls.Add(dataGridView1);
        this.Load += new EventHandler(Form1_Load);
        this.Text = "DataGridView validation demo (disallows empty CompanyName)";
    }
    //</Snippet01>

    //<Snippet10>
    private void Form1_Load(System.Object sender, System.EventArgs e)
    {
        // Attach DataGridView events to the corresponding event handlers.
        this.dataGridView1.CellValidating += new
            DataGridViewCellValidatingEventHandler(dataGridView1_CellValidating);
        this.dataGridView1.CellEndEdit += new
            DataGridViewCellEventHandler(dataGridView1_CellEndEdit);

        // Initialize the BindingSource and bind the DataGridView to it.
        bindingSource1.DataSource = GetData("select * from Customers");
        this.dataGridView1.DataSource = bindingSource1;
        this.dataGridView1.AutoResizeColumns(
            DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
    }
    //</Snippet10>

    //<Snippet20>
    private void dataGridView1_CellValidating(object sender,
        DataGridViewCellValidatingEventArgs e)
    {
        string headerText = 
            dataGridView1.Columns[e.ColumnIndex].HeaderText;

        // Abort validation if cell is not in the CompanyName column.
        if (!headerText.Equals("CompanyName")) return;

        // Confirm that the cell is not empty.
        if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
        {
            dataGridView1.Rows[e.RowIndex].ErrorText =
                "Company Name must not be empty";
            e.Cancel = true;
        }
    }

    //<Snippet25>
    void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        // Clear the row error in case the user presses ESC.   
        dataGridView1.Rows[e.RowIndex].ErrorText = String.Empty;
    }
    //</Snippet25>
    //</Snippet20>

    //<Snippet30>   
    private static DataTable GetData(string selectCommand)
    {
        string connectionString =
            "Integrated Security=SSPI;Persist Security Info=False;" +
            "Initial Catalog=Northwind;Data Source=localhost;Packet Size=4096";

        // Connect to the database and fill a data table.
        SqlDataAdapter adapter =
            new SqlDataAdapter(selectCommand, connectionString);
        DataTable data = new DataTable();
        data.Locale = System.Globalization.CultureInfo.InvariantCulture;
        adapter.Fill(data);

        return data;
    }
    //</Snippet30>

    //<Snippet02>
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Form1());
    }

}
//</Snippet02>
//</Snippet00>