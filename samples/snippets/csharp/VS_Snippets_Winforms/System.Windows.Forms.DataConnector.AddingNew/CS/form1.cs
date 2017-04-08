// <snippet1>
// <snippet2>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;
// </snippet2>

// <snippet3>
// This form demonstrates using a BindingSource to provide
// data from a collection of custom types to a DataGridView control.
public class Form1 : System.Windows.Forms.Form
{
    // <snippet5>
    // This is the BindingSource that will provide data for
    // the DataGridView control.
    private BindingSource customersBindingSource = new BindingSource();

    // This is the DataGridView control that will display our data.
    private DataGridView customersDataGridView = new DataGridView();

    // Set up the StatusBar for displaying ListChanged events.
    private StatusBar status = new StatusBar();

    // </snippet5>

    // <snippet6>
    public Form1()
    {
        // Set up the form.
        this.Size = new Size(800, 800);
        this.Load += new EventHandler(Form1_Load);
        this.Controls.Add(status);

        // Set up the DataGridView control.
        this.customersDataGridView.Dock = DockStyle.Fill;
        this.Controls.Add(customersDataGridView);

        // Attach an event handler for the AddingNew event.
        this.customersBindingSource.AddingNew += 
            new AddingNewEventHandler(customersBindingSource_AddingNew);

        // Attach an event handler for the ListChanged event.
        this.customersBindingSource.ListChanged += 
            new ListChangedEventHandler(customersBindingSource_ListChanged);
    }
    // </snippet6>

    // <snippet7>
    private void Form1_Load(System.Object sender, System.EventArgs e)
    {
        // Add a DemoCustomer to cause a row to be displayed.
        this.customersBindingSource.AddNew();

        // Bind the BindingSource to the DataGridView 
        // control's DataSource.
        this.customersDataGridView.DataSource = 
            this.customersBindingSource;
    }
    // </snippet7>

    // <snippet8>
    // This event handler provides custom item-creation behavior.
    void customersBindingSource_AddingNew(
        object sender, 
        AddingNewEventArgs e)
    {
        e.NewObject = DemoCustomer.CreateNewCustomer();
    }
    // </snippet8>

    // <snippet9>
    // This event handler detects changes in the BindingSource 
    // list or changes to items within the list.
    void customersBindingSource_ListChanged(
        object sender, 
        ListChangedEventArgs e)
    {
        status.Text = e.ListChangedType.ToString();
    }
    // </snippet9>

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Form1());
    }
}
// </snippet3>

// <snippet4>
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
// </snippet4>
// </snippet1>