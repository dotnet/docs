using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cs_DataBinding
{
    class Program
    {
        static void Main(string[] args)
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");

            // <Snippet1>
            DataGrid dataGrid1 = new DataGrid();
            DataGrid dataGrid2 = new DataGrid();
            DataGrid dataGrid3 = new DataGrid();

            var custQuery =
                from cust in db.Customers
                select cust;
            dataGrid1.DataSource = custQuery;
            dataGrid2.DataSource = custQuery;
            dataGrid2.DataMember = "Orders";

            BindingSource bs = new BindingSource();
            bs.DataSource = custQuery;
            dataGrid3.DataSource = bs;
            // </Snippet1>
        }

        void method2()
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            // <Snippet2>
            ListView listView1 = new ListView();
            var custQuery2 =
                from cust in db.Customers
                select cust;

            ListViewItem ItemsSource = new ListViewItem();
            ItemsSource = (ListViewItem)custQuery2;
            // </Snippet2>
        }
    }
}
