using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksDataRepeaterDataErrorCS
{
    public partial class DataError : Form
    {
        public DataError()
        {
            InitializeComponent();
        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwndDataSet);

        }

        private void DataError_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwndDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.northwndDataSet.Products);

        }

        // <Snippet1>
        private void dataRepeater1_DataError(object sender, 
            Microsoft.VisualBasic.PowerPacks.DataRepeaterDataErrorEventArgs e)
        {
            string ErrorMsg;
            // Create an error string.
            ErrorMsg = "Invalid value entered for " + e.Control.Name + ". ";
            ErrorMsg = ErrorMsg + e.Exception.Message;
            // Display the error to the user.
            MessageBox.Show(ErrorMsg);
            // Do not raise an exception.
            e.ThrowException = false;
        }
        // </Snippet1>
    }
}
