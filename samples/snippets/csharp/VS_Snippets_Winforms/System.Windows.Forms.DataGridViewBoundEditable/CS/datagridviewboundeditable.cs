using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
}
public class Form1 : Form
{
    private DataGridView dataGridView1 = new DataGridView();
    private BindingSource bindingSource1 = new BindingSource();
    private SqlDataAdapter dataAdapter = new SqlDataAdapter();
    private Button reloadButton = new Button();
    private Button submitButton = new Button();

    [STAThread()]
    public static void Main()
    {
        Application.Run(new Form1());
    }

    // Initialize the form.
    public Form1()
    {
        dataGridView1.Dock = DockStyle.Fill;

        reloadButton.Text = "Reload";
        submitButton.Text = "Submit";
        reloadButton.Click += new EventHandler(ReloadButton_Click);
        submitButton.Click += new EventHandler(SubmitButton_Click);

        FlowLayoutPanel panel = new FlowLayoutPanel
        {
            Dock = DockStyle.Top,
            AutoSize = true
        };
        panel.Controls.AddRange(new Control[] { reloadButton, submitButton });

        Controls.AddRange(new Control[] { dataGridView1, panel });
        Load += new EventHandler(Form1_Load);
        Text = "DataGridView data binding and updating demo";
    }

    private void GetData(string selectCommand)
    {
        try
        {
            // Specify a connection string.  
            // Replace <SQL Server> with the SQL Server for your Northwind sample database.
            // Replace "Integrated Security=True" with user login information if necessary.
            String connectionString =
                "Data Source=<SQL Server>;Initial Catalog=Northwind;" +
                "Integrated Security=True";

            // Create a new data adapter based on the specified query.
            dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

            // Create a command builder to generate SQL update, insert, and
            // delete commands based on selectCommand. 
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            // Populate a new data table and bind it to the BindingSource.
            DataTable table = new DataTable
            {
                Locale = CultureInfo.InvariantCulture
            };
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

    private void Form1_Load(object sender, EventArgs e)
    {
        // Bind the DataGridView to the BindingSource
        // and load the data from the database.
        dataGridView1.DataSource = bindingSource1;
        GetData("select * from Customers");
    }

    private void ReloadButton_Click(object sender, EventArgs e)
    {
        // Reload the data from the database.
        GetData(dataAdapter.SelectCommand.CommandText);
    }

    private void SubmitButton_Click(object sender, EventArgs e)
    {
        // Update the database with changes.
        dataAdapter.Update((DataTable)bindingSource1.DataSource);
    }
}
