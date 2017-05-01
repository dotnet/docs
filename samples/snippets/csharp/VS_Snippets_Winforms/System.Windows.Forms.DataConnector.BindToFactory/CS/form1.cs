// <snippet1>
// <snippet2>
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;
// </snippet2>

// <snippet3>
// This form demonstrates using a BindingSource to bind to a factory
// object. 
public class Form1 : System.Windows.Forms.Form
{
    // <snippet4>
    // This is the TextBox for entering CustomerID values.
    private TextBox customerIdTextBox = new TextBox();

    // This is the DataGridView that displays orders for the 
    // specified customer.
    private DataGridView customersDataGridView = new DataGridView();

    // This is the BindingSource for binding the database query
    // result set to the DataGridView.
    private BindingSource ordersBindingSource = new BindingSource();
    // </snippet4>

    // <snippet5>
    public Form1()
    {
        // Set up the CustomerID TextBox.
        this.customerIdTextBox.Location = new Point(100, 200);
        this.customerIdTextBox.Size = new Size(500, 30);
        this.customerIdTextBox.Text =
            "Enter a valid Northwind CustomerID, for example: ALFKI," +
            " then RETURN or click outside the TextBox";
        this.customerIdTextBox.Leave +=
            new EventHandler(customerIdTextBox_Leave);
        this.customerIdTextBox.KeyDown +=
            new KeyEventHandler(customerIdTextBox_KeyDown);
        this.Controls.Add(this.customerIdTextBox);
       
        // Set up the DataGridView.
        customersDataGridView.Dock = DockStyle.Top;
        this.Controls.Add(customersDataGridView);

        // Set up the form.
        this.Size = new Size(800, 500);
        this.Load += new EventHandler(Form1_Load);
    }
    // </snippet5>

    // <snippet6>
    // This event handler binds the BindingSource to the DataGridView
    // control's DataSource property.
    private void Form1_Load(
        System.Object sender,
        System.EventArgs e)
    {
        // Attach the BindingSource to the DataGridView.
        this.customersDataGridView.DataSource =
            this.ordersBindingSource;
    }
    // </snippet6>

    // <snippet7>
    // This is a static factory method. It queries the Northwind 
    // database for the orders belonging to the specified
    // customer and returns an IEnumerable.
    public static IEnumerable GetOrdersByCustomerId(string id)
    {
        // Open a connection to the database.
        string connectString = "Integrated Security=SSPI;" +
            "Persist Security Info=False;Initial Catalog=Northwind;" +
            "Data Source= localhost";
        SqlConnection connection = new SqlConnection();
       
        connection.ConnectionString = connectString;
        connection.Open();

        // Execute the query.
        string queryString =
            String.Format("Select * From Orders where CustomerID = '{0}'",
            id);
        SqlCommand command = new SqlCommand(queryString, connection);
        SqlDataReader reader =
            command.ExecuteReader(CommandBehavior.CloseConnection);
        return reader;
               
    }
    // </snippet7>

     // <snippet8>
    // These event handlers are called when the user tabs or clicks
    // out of the customerIdTextBox or hits the return key.
    // The database is then queried with the CustomerID
    //  in the customerIdTextBox.Text property.
    void customerIdTextBox_Leave(object sender, EventArgs e)
    {
        // Attach the data source to the BindingSource control.
        this.ordersBindingSource.DataSource =
            GetOrdersByCustomerId(this.customerIdTextBox.Text);
    }

    void customerIdTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Return)
        {
            // Attach the data source to the BindingSource control.
            this.ordersBindingSource.DataSource =
                GetOrdersByCustomerId(this.customerIdTextBox.Text);
        }
    }
    // </snippet8>

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Form1());
    }
}
// </snippet3>
// </snippet1>
