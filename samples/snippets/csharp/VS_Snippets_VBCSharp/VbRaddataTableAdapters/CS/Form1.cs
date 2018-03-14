using System;
using System.Data;
using System.Windows.Forms;

namespace CS
{
    public partial class Form1 : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {
            //<Snippet1>
            string cityValue = "Seattle";
            customersTableAdapter.FillByCity(northwindDataSet.Customers, cityValue);
            //</Snippet1>
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.customersTableAdapter.Update(this.northwindDataSet.Customers);
        }
    }
}