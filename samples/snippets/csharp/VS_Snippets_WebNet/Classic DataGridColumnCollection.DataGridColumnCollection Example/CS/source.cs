using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public class Form1: Page
{
 protected DataGrid ItemsGrid;
// <Snippet1>
void Page_Init(Object sender, EventArgs e) 
{
   ArrayList myList = new ArrayList();
   DataGridColumnCollection myColumnCollection = new DataGridColumnCollection(ItemsGrid, myList); 
}
   
// </Snippet1>
}

