//<Snippet00>
using System;
using System.Windows.Forms;

public class DataGridViewObjectBinding : Form
{
    // These declarations and the Main() and New() methods 
    // below can be replaced with designer-generated code. 
    private Button invoiceButton = new Button();
    private DataGridView dataGridView1 = new DataGridView();

    // Entry point code. 
    [STAThreadAttribute()]
    public static void Main()
    {
        Application.Run(new DataGridViewObjectBinding());
    }

    // Sets up the form.
    public DataGridViewObjectBinding()
    {
        this.dataGridView1.Dock = DockStyle.Fill;
        this.Controls.Add(this.dataGridView1);

        this.invoiceButton.Text = "invoice the selected customers";
        this.invoiceButton.Dock = DockStyle.Top;
        this.invoiceButton.Click += new EventHandler(invoiceButton_Click);
        this.Controls.Add(this.invoiceButton);

        this.Load += new EventHandler(DataGridViewObjectBinding_Load);
        this.Text = "DataGridView collection-binding demo";
    }

    void  DataGridViewObjectBinding_Load(object sender, EventArgs e)
    {
        // Set up a collection of objects for binding.
        System.Collections.ArrayList customers = new System.Collections.ArrayList();
        customers.Add(new Customer("Harry"));
        customers.Add(new Customer("Sally"));
        customers.Add(new Customer("Roy"));
        customers.Add(new Customer("Pris"));

        // Initialize and bind the DataGridView.
        this.dataGridView1.SelectionMode = 
            DataGridViewSelectionMode.FullRowSelect;
        this.dataGridView1.AutoGenerateColumns = true;
        this.dataGridView1.DataSource = customers;
    }

    // Calls the SendInvoice() method for the Customer 
    // object bound to each selected row.
    //<Snippet10>
    void invoiceButton_Click(object sender, EventArgs e)
    {
        foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
        {
            Customer cust = row.DataBoundItem as Customer;
            if (cust != null)
            {
                cust.SendInvoice();
            }
        }
    }
    //</Snippet10>
}

public class Customer
{
    private String nameValue;

    public Customer(String name)
    {
        nameValue = name;
    }

    public String Name
    {
        get
        {
            return nameValue;
        }
        set 
        {
            nameValue = value;
        }
    }

    public void SendInvoice()
    {
        MessageBox.Show(nameValue + " has been billed.");
    }
}
//</Snippet00>