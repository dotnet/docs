// <snippet1>
// <snippet2>
using System;
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
// This form demonstrates using a BindingSource to bind
// a list to a DataGridView control. The list does not
// raise change notifications, so the ResetItem method 
// on the BindingSource is used.
public class Form1 : System.Windows.Forms.Form
{
    // <snippet4>
    // This button causes the value of a list element to be changed.
    private Button changeItemBtn = new Button();

    // This is the DataGridView control that displays the contents 
    // of the list.
    private DataGridView customersDataGridView = new DataGridView();

    // This is the BindingSource used to bind the list to the 
    // DataGridView control.
    private BindingSource customersBindingSource = new BindingSource();
    // </snippet4>

    // <snippet5>
    public Form1()
    {
        // Set up the "Change Item" button.
        this.changeItemBtn.Text = "Change Item";
        this.changeItemBtn.Dock = DockStyle.Bottom;
        this.changeItemBtn.Click += 
            new EventHandler(changeItemBtn_Click);
        this.Controls.Add(this.changeItemBtn);
        
        // Set up the DataGridView.
        customersDataGridView.Dock = DockStyle.Top;
        this.Controls.Add(customersDataGridView);
        this.Size = new Size(800, 200);
        this.Load += new EventHandler(Form1_Load);
    }
    // </snippet5>

    // <snippet6>
    private void Form1_Load(System.Object sender, System.EventArgs e)
    {
        // Create and populate the list of DemoCustomer objects
        // which will supply data to the DataGridView.
        List<DemoCustomer> customerList = new List<DemoCustomer>();
        customerList.Add(DemoCustomer.CreateNewCustomer());
        customerList.Add(DemoCustomer.CreateNewCustomer());
        customerList.Add(DemoCustomer.CreateNewCustomer());

        // Bind the list to the BindingSource.
        this.customersBindingSource.DataSource = customerList;

        
        // Attach the BindingSource to the DataGridView.
        this.customersDataGridView.DataSource = 
            this.customersBindingSource;
    }
    // </snippet6>

    // <snippet7>
    // This event handler changes the value of the CompanyName
    // property for the first item in the list.
    void changeItemBtn_Click(object sender, EventArgs e)
    {
        // Get a reference to the list from the BindingSource.
        List<DemoCustomer> customerList = 
            this.customersBindingSource.DataSource as List<DemoCustomer>;

        // Change the value of the CompanyName property for the 
        // first item in the list.
        customerList[0].CompanyName = "Tailspin Toys";

        // Call ResetItem to alert the BindingSource that the 
        // list has changed.
        this.customersBindingSource.ResetItem(0);
    }
    // </snippet7>

   
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Form1());
    }
}
// </snippet3>

// <snippet9>
// This class implements a simple customer type.
public class DemoCustomer
{
    // These fields hold the values for the public properties.
    private Guid idValue = Guid.NewGuid();
    private string customerName = String.Empty;
    private string companyNameValue = String.Empty;
    private string phoneNumberValue = String.Empty;

    // The constructor is private to enforce the factory pattern.
    private DemoCustomer()
    {
        customerName = "no data";
        companyNameValue = "no data";
        phoneNumberValue = "no data";
    }

    // This is the public factory method.
    public static DemoCustomer CreateNewCustomer()
    {
        return new DemoCustomer();
    }

    // This property represents an ID, suitable
    // for use as a primary key in a database.
    public Guid ID
    {
        get
        {
            return this.idValue;
        }
    }

    public string CompanyName
    {
        get
        {
            return this.companyNameValue;
        }

        set
        {
            this.companyNameValue = value;
        }
    }

    public string PhoneNumber
    {
        get
        {
            return this.phoneNumberValue;
        }

        set
        {
            this.phoneNumberValue = value;
        }
    }
}
// </snippet9>
// </snippet1>
