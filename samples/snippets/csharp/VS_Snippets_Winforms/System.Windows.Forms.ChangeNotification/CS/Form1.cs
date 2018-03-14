//<snippet4>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;


namespace UpdateBindings
{
    //<snippet1>
    // This form demonstrates using a BindingSource to bind
    // a list to a simple user control. The list does not
    // raise change notifications, however the DemoCustomer type 
    // in the list does. In addition, an event is raised when the DataSource
    // property of the user control changes.
    public class Form1 : System.Windows.Forms.Form
    {
        // This button causes the value of a list element to be changed.
        private Button changeItemBtn = new Button();

        // This is the DataGridView control that displays the contents 
        // of the list.
        private CustomerControl customerControl1 = new CustomerControl();


        // This is the BindingSource used to bind the list to the control.
        private BindingSource customersBindingSource = new BindingSource();

        public Form1()
        {
            // Set up the "Change Item" button.
            this.changeItemBtn.Text = "Change Item";
            this.changeItemBtn.Dock = DockStyle.Bottom;
            this.changeItemBtn.Click +=
                new EventHandler(changeItemBtn_Click);
            this.Controls.Add(this.changeItemBtn);

            // Set up the DataGridView.
            customerControl1.Dock = DockStyle.Top;
            this.Controls.Add(customerControl1);
            this.Size = new Size(800, 200);
            this.Load += new EventHandler(Form1_Load);
            this.customerControl1.DataSourceChanged +=  
                new EventHandler(customerControl1_DataSourceChanged);
            
        }
        private void customerControl1_DataSourceChanged(Object sender, EventArgs e)
        {
            MessageBox.Show("Data Source has changed");
        }

        private void Form1_Load(System.Object sender, System.EventArgs e)
        {
            // Create and populate the list of DemoCustomer objects
            // which will supply data to the control.
            List<DemoCustomer> customerList = new List<DemoCustomer>();
            customerList.Add(DemoCustomer.CreateNewCustomer());
            customerList.Add(DemoCustomer.CreateNewCustomer());
            customerList.Add(DemoCustomer.CreateNewCustomer());

            // Bind the list to the BindingSource.
            this.customersBindingSource.DataSource = customerList;
            customerControl1.DataSource = customersBindingSource;
        }

        // This event handler changes the value of the CompanyName
        // property for the first item in the list.
        private void changeItemBtn_Click(object sender, EventArgs e)
        {
            // Get a reference to the list from the BindingSource.
            List<DemoCustomer> customerList =
                this.customersBindingSource.DataSource as List<DemoCustomer>;

            // Change the value of the CompanyName property for the 
            // first item in the list.
            customerList[0].CompanyName = "Tailspin Toys";
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }

    //</snippet1>
    //<snippet3>
    // This class implements a simple user control 
    // that demonstrates how to apply the propertyNameChanged pattern.
    [ComplexBindingProperties("DataSource", "DataMember")]
    public class CustomerControl : UserControl
    {
        private DataGridView dataGridView1;
        private Label label1;
        private DateTime lastUpdate = DateTime.Now;

        public EventHandler DataSourceChanged;

        public object DataSource
        {
            get
            {
                return this.dataGridView1.DataSource;
            }
            set
            {
                if (DataSource != value)
                {
                    this.dataGridView1.DataSource = value;
                    OnDataSourceChanged();
                }
            }
        }

        public string DataMember
        {
            get { return this.dataGridView1.DataMember; }

            set { this.dataGridView1.DataMember = value; }

        }

        private void OnDataSourceChanged()
        {
            if (DataSourceChanged != null)
            {
                DataSourceChanged(this, new EventArgs());
            }
        }
       
        public CustomerControl()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1.ColumnHeadersHeightSizeMode = 
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.dataGridView1.Location = new System.Drawing.Point(19, 55);
            this.dataGridView1.Size = new System.Drawing.Size(350, 150);
            this.dataGridView1.TabIndex = 1;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Customer List:";
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Size = new System.Drawing.Size(350, 216);
            
        }
    }
    //</snippet3>

    //<snippet2>
    // This class implements a simple customer type 
    // that implements the IPropertyChange interface.
    public class DemoCustomer : INotifyPropertyChanged
    {
        // These fields hold the values for the public properties.
        private Guid idValue = Guid.NewGuid();
        private string customerName = String.Empty;
        private string companyNameValue = String.Empty;
        private string phoneNumberValue = String.Empty;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

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
            get {return this.companyNameValue;}
           
            set
            {
                if (value != this.companyNameValue)
                {
                    this.companyNameValue = value;
                    NotifyPropertyChanged("CompanyName");
                }
            }
        }
        public string PhoneNumber
        {
            get { return this.phoneNumberValue; }
            
            set 
            {
                if (value != this.phoneNumberValue)
                {
                    this.phoneNumberValue = value;
                    NotifyPropertyChanged("PhoneNumber");
                }
            }
        }
    }
    //</snippet2>
}
//</snippet4>