//<snippet1>
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

public class Form1 : System.Windows.Forms.Form
{
    private DataGridView dataGridView1 = new DataGridView();
    private BindingSource bindingSource1 = new BindingSource();

    public Form1()
    {
        dataGridView1.Dock = DockStyle.Fill;
        this.Controls.Add(dataGridView1);
        InitializeDataGridView();
    }

    //<snippet2>
    private void InitializeDataGridView()
    {
        try
        {
            // Set up the DataGridView.
            dataGridView1.Dock = DockStyle.Fill;

            // Automatically generate the DataGridView columns.
            dataGridView1.AutoGenerateColumns = true;

            // Set up the data source.
            bindingSource1.DataSource = GetData("Select * From Products");
            dataGridView1.DataSource = bindingSource1;

            // Automatically resize the visible rows.
            dataGridView1.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;

            // Set the DataGridView control's border.
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;

            // Put the cells in edit mode when user enters them.
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
        }
        catch (SqlException)
        {
            MessageBox.Show("To run this sample replace connection.ConnectionString" +
                " with a valid connection string to a Northwind" +
                " database accessible to your system.", "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            System.Threading.Thread.CurrentThread.Abort();
        }
    }
    //</snippet2>

    //<snippet3>
    private static DataTable GetData(string sqlCommand)
    {
        string connectionString = "Integrated Security=SSPI;" +
            "Persist Security Info=False;" +
            "Initial Catalog=Northwind;Data Source=localhost";

        SqlConnection northwindConnection = new SqlConnection(connectionString);

        SqlCommand command = new SqlCommand(sqlCommand, northwindConnection);
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = command;

        DataTable table = new DataTable();
        table.Locale = System.Globalization.CultureInfo.InvariantCulture;
        adapter.Fill(table);

        return table;
    }
    //</snippet3>

    [STAThreadAttribute()]
    public static void Main()
    {
        Application.Run(new Form1());
    }
}
//</snippet1>


