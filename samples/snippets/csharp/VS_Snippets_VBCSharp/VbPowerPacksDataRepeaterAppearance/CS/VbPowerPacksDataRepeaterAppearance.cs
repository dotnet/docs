using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksDataRepeaterAppearanceCS
{
    public partial class VbPowerPacksDataRepeaterAppearance : Form
    {
        public VbPowerPacksDataRepeaterAppearance()
        {
            InitializeComponent();
        }

        private void VbPowerPacksDataRepeaterAppearance_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwndDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.northwndDataSet.Products);

        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwndDataSet);

        }

        private void dataRepeater1_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            // <Snippet1>
            // Set the default BackColor.
            e.DataRepeaterItem.BackColor = Color.White;
            // Loop through the controls on the DataRepeaterItem.
            foreach (Control c in e.DataRepeaterItem.Controls)
            {
                // Check the type of each control.
                if (c is TextBox)
                // If a TextBox, change the BackColor.
                {
                    c.BackColor = Color.AliceBlue;
                }
                else
                {
                    // Otherwise use the default BackColor.
                    c.BackColor = e.DataRepeaterItem.BackColor;
                }
            }
            // </Snippet1>
        }
    }
}
