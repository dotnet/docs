using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DataGrid.NavigateTo
{
    public partial class Form1 : Form
    {
        protected System.Windows.Forms.DataGrid dataGrid1;

        public Form1()
        {
            // Not a runnable example.
        }
        // <Snippet1>
        private void NavToGrid(System.Windows.Forms.DataGrid dataGrid)
        {
            // Presumes a relationship named OrderDetails exists.
            dataGrid.NavigateTo(2, "OrderDetails");
        }
        // </Snippet1>


    }
}
