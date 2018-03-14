//<snippet1>
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BT2
{
    public class Form1 : Form
    {
        public Form1()
        {
            InitializeControlsAndDataSource();
        }

        // Declare the controls to be used.
        private BindingSource bindingSource1;
        private DataGridView dataGridView1;
        private Button button1;
        private DataGridView dataGridView2;
        private CheckBox cachePositionCheckBox;
        public DataSet set1;
       
        private void InitializeControlsAndDataSource()
        {
            // Initialize the controls and set location, size and 
            // other basic properties.
            this.dataGridView1 = new DataGridView();
            this.bindingSource1 = new BindingSource();
            this.button1 = new Button();
            this.dataGridView2 = new DataGridView();
            this.cachePositionCheckBox = new System.Windows.Forms.CheckBox();
            this.dataGridView1.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = DockStyle.Top;
            this.dataGridView1.Location = new Point(0, 20);
            this.dataGridView1.Size = new Size(292, 170);
            this.button1.Location = new System.Drawing.Point(18, 175);
            this.button1.Size = new System.Drawing.Size(125, 23);
        
            button1.Text = "Clear Parent Field";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.dataGridView2.ColumnHeadersHeightSizeMode = 
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(0, 225);
            this.dataGridView2.Size = new System.Drawing.Size(309, 130);
            this.cachePositionCheckBox.AutoSize = true;
            this.cachePositionCheckBox.Checked = true;
            this.cachePositionCheckBox.Location = new System.Drawing.Point(150, 175);
            this.cachePositionCheckBox.Name = "radioButton1";
            this.cachePositionCheckBox.Size = new System.Drawing.Size(151, 17);
            this.cachePositionCheckBox.Text = "Cache and restore position";
            this.ClientSize = new System.Drawing.Size(325, 420);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cachePositionCheckBox);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button1);
          
            // Initialize the data.
            set1 = InitializeDataSet();
           
            // Set the data source to the DataSet.
            bindingSource1.DataSource = set1;
           
            //Set the DataMember to the Menu table.
            bindingSource1.DataMember = "Customers";

            // Add the control data bindings.
            dataGridView1.DataSource = bindingSource1;

            // Set the data source and member for the second DataGridView.
            dataGridView2.DataSource = bindingSource1;
            dataGridView2.DataMember = "custOrders";

            // Get the currency manager for the customer orders binding.
            CurrencyManager relatedCM = 
                bindingSource1.GetRelatedCurrencyManager("custOrders");
            
            // Set the position in the child table for demonstration purposes.
            relatedCM.Position = 3;

            // Handle the current changed event. This event occurs when
            // the current item is changed, but not when a field of the current
            // item is changed.
            bindingSource1.CurrentChanged += 
                new EventHandler(bindingSource1_CurrentChanged);
            
            // Handle the two events for caching and resetting the position.
            relatedCM.ListChanged += new ListChangedEventHandler(relatedCM_ListChanged);
            relatedCM.PositionChanged
                += new EventHandler(relatedCM_PositionChanged);

            // Set cacheing to true in case current changed event
            // occured on set up.
            cacheChildPosition = true;
        }

      
        // Establish the data set with two tables and a relationship
        // between them.
        private DataSet InitializeDataSet()
        {
            set1 = new DataSet();
            // Declare the DataSet and add a table and column.
            set1.Tables.Add("Customers");
            set1.Tables[0].Columns.Add("CustomerID");
            set1.Tables[0].Columns.Add("Customer Name");
            set1.Tables[0].Columns.Add("Contact Name");

            // Add some rows to the table.
            set1.Tables["Customers"].Rows.Add("c1", "Fabrikam, Inc.", "Ellen Adams");
            set1.Tables[0].Rows.Add("c2", "Lucerne Publishing", "Don Hall");
            set1.Tables[0].Rows.Add("c3", "Northwind Traders", "Lori Penor");
            set1.Tables[0].Rows.Add("c4", "Tailspin Toys", "Michael Patten");
            set1.Tables[0].Rows.Add("c5", "Woodgrove Bank", "Jyothi Pai");

            // Declare the DataSet and add a table and column.
            set1.Tables.Add("Orders");
            set1.Tables[1].Columns.Add("CustomerID");
            set1.Tables[1].Columns.Add("OrderNo");
            set1.Tables[1].Columns.Add("OrderDate");

            // Add some rows to the table.
            set1.Tables[1].Rows.Add("c1", "119", "10/04/2006");
            set1.Tables[1].Rows.Add("c1", "149", "10/10/2006");
            set1.Tables[1].Rows.Add("c1", "159", "10/12/2006");
            set1.Tables[1].Rows.Add("c2", "169", "10/10/2006");
            set1.Tables[1].Rows.Add("c2", "179", "10/10/2006");
            set1.Tables[1].Rows.Add("c2", "189", "10/12/2006");
            set1.Tables[1].Rows.Add("c3", "122", "10/04/2006");
            set1.Tables[1].Rows.Add("c4", "130", "10/10/2006");
            set1.Tables[1].Rows.Add("c5", "1.29", "10/14/2006");

            DataRelation dr = new DataRelation("custOrders",
                set1.Tables["Customers"].Columns["CustomerID"],
                set1.Tables["Orders"].Columns["CustomerID"]);
            set1.Relations.Add(dr);
            return set1;
        }
        //<snippet4>
        private int cachedPosition = -1;
        private bool cacheChildPosition = true;
        //</snippet4>

        //<snippet2>
        void relatedCM_ListChanged(object sender, ListChangedEventArgs e)
        {
            // Check to see if this is a caching situation.
            if (cacheChildPosition && cachePositionCheckBox.Checked) 
            {
                // If so, check to see if it is a reset situation, and the current
                // position is greater than zero.
                CurrencyManager relatedCM = sender as CurrencyManager;
                if (e.ListChangedType == ListChangedType.Reset && relatedCM.Position > 0)

                    // If so, cache the position of the child table.
                    cachedPosition = relatedCM.Position;
            }
        }
        //</snippet2>
        //<snippet5>
        void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            // If the CurrentChanged event occurs, this is not a caching 
            // situation.
            cacheChildPosition = false;
        }
        //</snippet5>
        //<snippet3>
        void relatedCM_PositionChanged(object sender, EventArgs e)
        {
            // Check to see if this is a caching situation.
            if (cacheChildPosition && cachePositionCheckBox.Checked)
            {
                CurrencyManager relatedCM = sender as CurrencyManager;

                // If so, check to see if the current position is 
                // not equal to the cached position and the cached 
                // position is not out of bounds.
                if (relatedCM.Position != cachedPosition && cachedPosition
                    > 0 && cachedPosition < relatedCM.Count)
                {
                    relatedCM.Position = cachedPosition;
                    cachedPosition = -1;
                }
            }
        }
        //</snippet3>
        int count = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            // For demo purposes--modifies a value in the first row of the
            // parent table.
            DataRow row1 = set1.Tables[0].Rows[0];
            row1[1] = DBNull.Value;

        }
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    
}
//</snippet1>