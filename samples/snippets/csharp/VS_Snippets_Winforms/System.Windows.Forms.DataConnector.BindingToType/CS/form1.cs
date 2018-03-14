//<snippet1>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

class Form1 : Form
{
    BindingSource bSource = new BindingSource();
    private Button button1;
    DataGridView dgv = new DataGridView();

    public Form1()
    {
        this.button1 = new System.Windows.Forms.Button();
        this.button1.Location = new System.Drawing.Point(140, 326);
        this.button1.Name = "button1";
        this.button1.AutoSize = true;
        this.button1.Text = "Add Customer";
        this.button1.Click += new System.EventHandler(this.button1_Click);
        this.ClientSize = new System.Drawing.Size(362, 370);
        this.Controls.Add(this.button1);

        // Bind the BindingSource to the DemoCustomer type.
        bSource.DataSource = typeof(DemoCustomer);

        // Set up the DataGridView control.
        dgv.Dock = DockStyle.Top;
        this.Controls.Add(dgv);

        // Bind the DataGridView control to the BindingSource.
        dgv.DataSource = bSource;
       
    }
    public static void Main()
    {
        Application.Run(new Form1());
     
    }

    private void button1_Click(object sender, EventArgs e)
    {
        bSource.Add(new DemoCustomer(DateTime.Today));
    }
}

// This simple class is used to demonstrate binding to a type.
public class DemoCustomer
{
    public DemoCustomer()
    {
        idValue = Guid.NewGuid();
    }

    public DemoCustomer(DateTime FirstOrderDate)
    {
        FirstOrder = FirstOrderDate;
        idValue = Guid.NewGuid();
    }
    // These fields hold the data that backs the public properties.
    private DateTime firstOrderDateValue;
    private Guid idValue;
    private string custNameValue;

    public string CustomerName
    {
        get { return custNameValue; }
        set { custNameValue = value; }
    }
	
    // This is a property that represents a birth date.
    public DateTime FirstOrder
    {
        get
        {
            return this.firstOrderDateValue;
        }
        set
        {
            if (value != this.firstOrderDateValue)
            {
                this.firstOrderDateValue = value;
            }
        }
    }

    // This is a property that represents a customer ID.
    public Guid ID
    {
        get
        {
            return this.idValue;
        }
    }
}
//</snippet1>