using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace ItemHeaderCS
{
    public partial class ItemHeader : Form
    {
        public ItemHeader()
        {
            InitializeComponent();
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwndDataSet);

        }

        private void ItemHeader_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwndDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.northwndDataSet.Customers);

        }

        // <Snippet1>
        private void button1_Click(System.Object sender, System.EventArgs e)
        {
            // Change the orientation and set the ItemHeaderSize accordingly.
            if (dataRepeater1.LayoutStyle == DataRepeaterLayoutStyles.Vertical)
            {
                dataRepeater1.LayoutStyle = DataRepeaterLayoutStyles.Horizontal;
                dataRepeater1.ItemHeaderSize = 12;
            }
            else
            {
                dataRepeater1.LayoutStyle = DataRepeaterLayoutStyles.Vertical;
                dataRepeater1.ItemHeaderSize = 18;
            }
        }
        // </Snippet1>
    }
}
