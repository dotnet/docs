using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HeaderVisibleCS
{
    public partial class HeaderVisible : Form
    {
        public HeaderVisible()
        {
            InitializeComponent();
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwndDataSet);

        }

        private void HeaderVisible_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwndDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.northwndDataSet.Customers);

        }

        // <Snippet1>
    private void button1_Click(System.Object sender, System.EventArgs e)
    {
        // Switch the visibility of the item header.
        if (dataRepeater1.ItemHeaderVisible==true)
        {
            dataRepeater1.ItemHeaderVisible = false;
        }
        else
        {
            dataRepeater1.ItemHeaderVisible = true;
        }
    }
    // </Snippet1>
    }
}
