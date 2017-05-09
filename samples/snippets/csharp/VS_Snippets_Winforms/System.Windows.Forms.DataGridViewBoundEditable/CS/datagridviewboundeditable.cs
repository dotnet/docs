//<snippet00>
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

public class Form1 : System.Windows.Forms.Form
{
    private DataGridView dataGridView1 = new DataGridView();
    private BindingSource bindingSource1 = new BindingSource();
    private SqlDataAdapter dataAdapter = new SqlDataAdapter();
    private Button reloadButton = new Button();
    private Button submitButton = new Button();

    [STAThreadAttribute()]
    public static void Main()
    {
        Application.Run(new Form1());
    }

    // Initialize the form.
    public Form1()
    {
        dataGridView1.Dock = DockStyle.Fill;

        reloadButton.Text = "reload";
        submitButton.Text = "submit";
        reloadButton.Click += new System.EventHandler(reloadButton_Click);
        submitButton.Click += new System.EventHandler(submitButton_Click);

        FlowLayoutPanel panel = new FlowLayoutPanel();
        panel.Dock = DockStyle.Top;
        panel.AutoSize = true;
        panel.Controls.AddRange(new Control[] { reloadButton, submitButton });

        this.Controls.AddRange(new Control[] { dataGridView1, panel });
        this.Load += new System.EventHandler(Form1_Load);
        this.Text = "DataGridView databinding and updating demo";
    }

    //<snippet10>
    private void Form1_Load(object sender, System.EventArgs e)
    {
        // Bind the DataGridView to the BindingSource
        // and load the data from the database.
        dataGridView1.DataSource = bindingSource1;
        GetData("select * from Customers");
    }
    //</snippet10>

    private void reloadButton_Click(object sender, System.EventArgs e)
    {
        // Reload the data from the database.
        GetData(dataAdapter.SelectCommand.CommandText);
    }

    private void submitButton_Click(object sender, System.EventArgs e)
    {
        // Update the database with the user's changes.
        dataAdapter.Update((DataTable)bindingSource1.DataSource);
    }

    //<snippet20>
    private void GetData(string selectCommand)
    {
        try
        {
            // Specify a connection string. Replace the given value with a 
            // valid connection string for a Northwind SQL Server sample
            // database accessible to your system.
            String connectionString =
                "Integrated Security=SSPI;Persist Security Info=False;" +
                "Initial Catalog=Northwind;Data Source=localhost";

            // Create a new data adapter based on the specified query.
            dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

            // Create a command builder to generate SQL update, insert, and
            // delete commands based on selectCommand. These are used to
            // update the database.
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            // Populate a new data table and bind it to the BindingSource.
            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            bindingSource1.DataSource = table;

            // Resize the DataGridView columns to fit the newly loaded content.
            dataGridView1.AutoResizeColumns( 
                DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        }
        catch (SqlException)
        {
            MessageBox.Show("To run this example, replace the value of the " +
                "connectionString variable with a connection string that is " +
                "valid for your system.");
        }
    }
    //</snippet20>

}
//</snippet00>