using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksDataRepeaterIsCurrentCS
{
    public partial class IsCurrent : Form
    {
        public IsCurrent()
        {
            InitializeComponent();
        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwndDataSet);

        }

        private void IsCurrent_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwndDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.northwndDataSet.Products);

        }
        // <Snippet1>
        private void dataRepeater1_DrawItem(object sender, 
            Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            // If this is the selected item...
            if (e.DataRepeaterItem.IsCurrent)
            // ...display the PictureBox.
            {
                e.DataRepeaterItem.Controls["selectedPictureBox"].Visible = true;
            }
            else
            {
                // Otherwise, hide the PictureBox.
                e.DataRepeaterItem.Controls["selectedPictureBox"].Visible = false;
            }
        }
        // </Snippet1>
    }
}
