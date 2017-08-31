using System;
using System.Windows.Forms;

namespace CS
{
    public partial class Form2 : Form
    {
        private void Form2_Load(object sender, EventArgs e)
        {
            //<Snippet8>
            ordersTableAdapter.FillByShippedDate(northwindDataSet.Orders, null);
            //</Snippet8>
        }


        public Form2()
        {
            InitializeComponent();
        }


        private void ordersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.ordersBindingSource.EndEdit();
            this.ordersTableAdapter.Update(this.northwindDataSet.Orders);
        }
    }
}