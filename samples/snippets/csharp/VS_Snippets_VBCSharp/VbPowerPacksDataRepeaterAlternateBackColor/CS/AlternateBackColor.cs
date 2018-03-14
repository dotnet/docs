using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPwrPacksDataRepeaterAltBColorCS
{
    public partial class AlternateBackColor : Form
    {
        public AlternateBackColor()
        {
            InitializeComponent();
        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwndDataSet);

        }

        private void AlternateBackColor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwndDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.northwndDataSet.Products);

        }

        // <Snippet1>
        private void dataRepeater1_DrawItem(object sender, 
            Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            // Alternate the back color.
            if ((e.DataRepeaterItem.ItemIndex % 2) != 0)
            // Apply the secondary back color.
            {
                e.DataRepeaterItem.BackColor = Color.AliceBlue;
            }
            else
            {
                // Apply the default back color.
                e.DataRepeaterItem.BackColor = Color.White;
            }
            // Change the color of out-of-stock items to red.
            if (e.DataRepeaterItem.Controls["unitsInStockTextBox"].Text == "0")
            {
                e.DataRepeaterItem.Controls["unitsInStockTextBox"].BackColor = Color.Red;
            }
            else
            {
                e.DataRepeaterItem.Controls["unitsInStockTextBox"].BackColor = Color.White;
            }
        }
        // </Snippet1>
    }
}
