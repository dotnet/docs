using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DisplayedCountCS
{
    public partial class DisplayedCount : Form
    {
        public DisplayedCount()
        {
            InitializeComponent();
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwndDataSet);

        }

        private void DisplayedCount_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwndDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.northwndDataSet.Customers);

        }

        // <Snippet1>
        private void button1_Click(System.Object sender, System.EventArgs e)
        {
            string msgString;
            int intFull;
            int intPartial;
            string stringFull;
            string stringPartial;
            // Get the count without including partially displayed items.
            intFull = dataRepeater1.get_DisplayedItemCount(false);
            // Get the count, including partially displayed items.
            intPartial = dataRepeater1.get_DisplayedItemCount(true);
            // Create the message string.
            stringFull = intFull.ToString();
            msgString = stringFull;
            msgString = msgString + " items are fully visible and ";
            // Subtract the full count from the partial count.
            intPartial = intPartial - intFull;
            stringPartial = intPartial.ToString();
            msgString = msgString + stringPartial;
            msgString = msgString + " items are partially visible.";
            MessageBox.Show(msgString);
        }
        // </Snippet1>
    }
}
