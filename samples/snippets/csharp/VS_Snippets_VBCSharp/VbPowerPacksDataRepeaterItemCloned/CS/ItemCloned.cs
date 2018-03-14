using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataRepeaterItemClonedCS
{
    public partial class ItemCloned : Form
    {
        public ItemCloned()
        {
            InitializeComponent();
        }

        private void employeesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwndDataSet);

        }

        private void ItemCloned_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwndDataSet.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.northwndDataSet.Employees);

        }
        // <Snippet1>
        private void dataRepeater1_ItemCloned(object sender, 
            Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            ListBox Source = (ListBox)dataRepeater1.ItemTemplate.Controls["listBox1"];
            ListBox listBox1 = (ListBox)e.DataRepeaterItem.Controls["listBox1"];
            foreach (string s in Source.Items)
            {
                listBox1.Items.Add(s);
            }
        }
        // </Snippet1>
    }
}
