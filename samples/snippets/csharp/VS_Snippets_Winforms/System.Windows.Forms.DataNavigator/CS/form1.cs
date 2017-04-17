//<snippet1>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;

// This form demonstrates using a BindingNavigator to display 
// rows from a database query sequentially.
public class Form1 : Form
{
    // This is the BindingNavigator that allows the user
    // to navigate through the rows in a DataSet.
    BindingNavigator customersBindingNavigator = new BindingNavigator(true);

    // This is the BindingSource that provides data for
    // the Textbox control.
    BindingSource customersBindingSource = new BindingSource();

    // This is the TextBox control that displays the CompanyName
    // field from the the DataSet.
    TextBox companyNameTextBox = new TextBox();

    public Form1()
    {
        // Set up the BindingSource component.
        this.customersBindingNavigator.BindingSource = this.customersBindingSource;
        this.customersBindingNavigator.Dock = DockStyle.Top;
        this.Controls.Add(this.customersBindingNavigator);

        // Set up the TextBox control for displaying company names.
        this.companyNameTextBox.Dock = DockStyle.Bottom;
        this.Controls.Add(this.companyNameTextBox);

        // Set up the form.
        this.Size = new Size(800, 200);
        this.Load += new EventHandler(Form1_Load);
    }

    void Form1_Load(object sender, EventArgs e)
    {
        // Open a connection to the database.
        // Replace the value of connectString with a valid 
        // connection string to a Northwind database accessible 
        // to your system.
        string connectString =
            "Integrated Security=SSPI;Persist Security Info=False;" +
            "Initial Catalog=Northwind;Data Source=localhost";
        
        using (SqlConnection connection = new SqlConnection(connectString))
        {

            SqlDataAdapter dataAdapter1 = 
                new SqlDataAdapter(new SqlCommand("Select * From Customers",connection));
            DataSet ds = new DataSet("Northwind Customers");
            ds.Tables.Add("Customers");
            dataAdapter1.Fill(ds.Tables["Customers"]);
            
            // Assign the DataSet as the DataSource for the BindingSource.
            this.customersBindingSource.DataSource = ds.Tables["Customers"];

            // Bind the CompanyName field to the TextBox control.
            this.companyNameTextBox.DataBindings.Add(
                new Binding("Text",
                this.customersBindingSource,
                "CompanyName",
                true));
        }
    }

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Form1());
    }
}
//</snippet1>