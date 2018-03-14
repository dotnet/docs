using System;
using System.Data;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

public class Page1: Page
{
// <Snippet1>
void Page_Load(Object sender, EventArgs e) 
{
   int index = 0;
   int setindex = 1;
   DataGridItem myItem = new DataGridItem(index, setindex, ListItemType.Item);
}
// </Snippet1>
}
