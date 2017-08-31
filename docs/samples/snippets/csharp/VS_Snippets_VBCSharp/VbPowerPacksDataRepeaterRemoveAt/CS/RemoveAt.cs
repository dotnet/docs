using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksDataRepeaterRemoveAtCS
{
    public partial class RemoveAt : Form
    {
        public RemoveAt()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void removeButton_Click(object sender, System.EventArgs e)
        {
            // Remove the second item. (Index is zero-based.)
            dataRepeater1.RemoveAt(1);
        }
        // </Snippet1>

        private void employeesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwndDataSet);

        }

        private void RemoveAt_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwndDataSet.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.northwndDataSet.Employees);

        }
    }
}
