
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System;

public class MyGridForm:Form{ 
  DataGrid grid = new DataGrid();	

static void Main(){
    Application.Run(new MyGridForm());

}

public MyGridForm(){
 
   grid.Size = this.Size;
   string connstr = 
  "Data Source=localhost;Initial Catalog=NORTHWIND;Integrated Security=SSPI";
    SqlDataAdapter custAdapter, orderAdapter;
  custAdapter = 
  	new SqlDataAdapter("select * from customers", connstr);
  orderAdapter = 
  	new SqlDataAdapter("select * from orders", connstr);

  DataSet ds = new DataSet();
  custAdapter.Fill(ds, "Customers");
  orderAdapter.Fill(ds, "Orders");
  ds.Relations.Add
  ("CustOrders", ds.Tables["Customers"].Columns["CustomerID"], ds.Tables["Orders"].Columns["CustomerID"]);
  
  Controls.Add(grid);
  grid.SetDataBinding(ds, "Customers");
  grid.Navigate+=new NavigateEventHandler(Grid_Navigate);
}
//<Snippet1>
private void Grid_Navigate(object sender, NavigateEventArgs e){
   if (e.Forward ){
      DataSet ds = (DataSet) grid.DataSource;
      CurrencyManager cm  = 
      (CurrencyManager)BindingContext[ds,"Customers.CustOrders"];
      // Cast the IList to a DataView to set the AllowNew property.
      DataView dv  = (DataView) cm.List;
      dv.AllowNew = false;
   }
}
   //</Snippet1>
}


