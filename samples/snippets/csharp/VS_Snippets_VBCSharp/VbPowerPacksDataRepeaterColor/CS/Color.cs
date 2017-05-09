using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace RepeaterColor
{
    public partial class Color : Form
    {
        public Color()
        {
            InitializeComponent();
        }

        private void contactsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.contactsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwndDataSet);

        }

        private void Color_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwndDataSet.Contacts' table. You can move, or remove it, as needed.
            this.contactsTableAdapter.Fill(this.northwndDataSet.Contacts);

        }

        private void button1_Click(System.Object sender, System.EventArgs e)
        {
            if (dataRepeater1.LayoutStyle == DataRepeaterLayoutStyles.Vertical)
            {
                dataRepeater1.LayoutStyle = DataRepeaterLayoutStyles.Horizontal;
            }
            else
            {
                dataRepeater1.LayoutStyle = DataRepeaterLayoutStyles.Vertical;
            }            
        }
        // <Snippet1>
        private void dataRepeater1_LayoutStyleChanged(object sender, System.EventArgs e)
        {
            // Set the SelectionColor based on orientation.
            if (dataRepeater1.LayoutStyle == DataRepeaterLayoutStyles.Vertical)
            {
                dataRepeater1.SelectionColor = System.Drawing.Color.Blue;
            }
            else
            {
                dataRepeater1.SelectionColor = System.Drawing.Color.Red;
            }
        }
        // </Snippet1>

    }
}
