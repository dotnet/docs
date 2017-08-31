using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace SelectionColorChangedCS
{
    public partial class SelectionColorChanged : Form
    {
        public SelectionColorChanged()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataRepeater1.SelectionColor = Color.Purple;
        }

        private void categoriesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.categoriesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwndDataSet);

        }

        private void SelectionColorChanged_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwndDataSet.Categories' table. You can move, or remove it, as needed.
            this.categoriesTableAdapter.Fill(this.northwndDataSet.Categories);

        }
        // <Snippet1>
        private void dataRepeater1_SelectionColorChanged(object sender, System.EventArgs e)
        {
            StringBuilder MyStringBuilder = new StringBuilder(dataRepeater1.SelectionColor.ToString());
            string searchWithinThis = dataRepeater1.SelectionColor.ToString();
            // Find the color name.
            string searchForThis = "[";
            int firstCharacter = searchWithinThis.IndexOf(searchForThis);
            MyStringBuilder.Remove(0, firstCharacter + 1);
            MyStringBuilder.Replace(']', ' ');
                        
            // Display a message.
            MessageBox.Show("Selections will be indicated by a " + MyStringBuilder + "header.");
        }
        // </Snippet1>
    }
}
