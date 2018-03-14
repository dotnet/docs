//<Snippet00>
//<Snippet01>
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

public class Form1 : System.Windows.Forms.Form
{
    private DataGridView masterDataGridView = new DataGridView();
    private BindingSource masterBindingSource = new BindingSource();
    private DataGridView detailsDataGridView = new DataGridView();
    private BindingSource detailsBindingSource = new BindingSource();

    [STAThreadAttribute()]
    public static void Main()
    {
        Application.Run(new Form1());
    }

    // Initializes the form.
    public Form1()
    {
        masterDataGridView.Dock = DockStyle.Fill;
        detailsDataGridView.Dock = DockStyle.Fill;

        SplitContainer splitContainer1 = new SplitContainer();
        splitContainer1.Dock = DockStyle.Fill;
        splitContainer1.Orientation = Orientation.Horizontal;
        splitContainer1.Panel1.Controls.Add(masterDataGridView);
        splitContainer1.Panel2.Controls.Add(detailsDataGridView);

        this.Controls.Add(splitContainer1);
        this.Load += new System.EventHandler(Form1_Load);
        this.Text = "DataGridView master/detail demo";
    }
    //</Snippet01>

    //<Snippet10>
    private void Form1_Load(object sender, System.EventArgs e)
    {
        // Bind the DataGridView controls to the BindingSource
        // components and load the data from the database.
        masterDataGridView.DataSource = masterBindingSource;
        detailsDataGridView.DataSource = detailsBindingSource;
        GetData();

        // Resize the master DataGridView columns to fit the newly loaded data.
        masterDataGridView.AutoResizeColumns();

        // Configure the details DataGridView so that its columns automatically
        // adjust their widths when the data changes.
        detailsDataGridView.AutoSizeColumnsMode = 
            DataGridViewAutoSizeColumnsMode.AllCells;
    }
    //</Snippet10>

    //<Snippet20>
    private void GetData()
    {
        try
        {
            // Specify a connection string. Replace the given value with a 
            // valid connection string for a Northwind SQL Server sample
            // database accessible to your system.
            String connectionString =
                "Integrated Security=SSPI;Persist Security Info=False;" +
                "Initial Catalog=Northwind;Data Source=localhost";
            SqlConnection connection = new SqlConnection(connectionString);

            // Create a DataSet.
            DataSet data = new DataSet();
            data.Locale = System.Globalization.CultureInfo.InvariantCulture;

            // Add data from the Customers table to the DataSet.
            SqlDataAdapter masterDataAdapter = new
                SqlDataAdapter("select * from Customers", connection);
            masterDataAdapter.Fill(data, "Customers");

            // Add data from the Orders table to the DataSet.
            SqlDataAdapter detailsDataAdapter = new
                SqlDataAdapter("select * from Orders", connection);
            detailsDataAdapter.Fill(data, "Orders");

            // Establish a relationship between the two tables.
            DataRelation relation = new DataRelation("CustomersOrders",
                data.Tables["Customers"].Columns["CustomerID"],
                data.Tables["Orders"].Columns["CustomerID"]);
            data.Relations.Add(relation);

            // Bind the master data connector to the Customers table.
            masterBindingSource.DataSource = data;
            masterBindingSource.DataMember = "Customers";

            // Bind the details data connector to the master data connector,
            // using the DataRelation name to filter the information in the 
            // details table based on the current row in the master table. 
            detailsBindingSource.DataSource = masterBindingSource;
            detailsBindingSource.DataMember = "CustomersOrders";
        }
        catch (SqlException)
        {
            MessageBox.Show("To run this example, replace the value of the " +
                "connectionString variable with a connection string that is " +
                "valid for your system.");
        }
    }
    //</Snippet20>
    //<Snippet02>
}
//</Snippet02>
//</Snippet00>