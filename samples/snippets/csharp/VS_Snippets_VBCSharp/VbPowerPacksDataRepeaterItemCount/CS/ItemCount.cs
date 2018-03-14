using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ItemCountCS
{
    public partial class ItemCount : Form
    {
        public ItemCount()
        {
            InitializeComponent();
        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwndDataSet);

        }

        private void ItemCount_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwndDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.northwndDataSet.Products);

        }

        // <Snippet1>
        private void button1_Click(System.Object sender, System.EventArgs e)
        {
            string stringCount;
            stringCount = dataRepeater1.ItemCount.ToString();
            MessageBox.Show("The DataRepeater contains " + stringCount + " items.");
        }
        // </Snippet1>
    }
}
