using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public class Page1: Page
{
// <Snippet1>
void Page_Load(Object sender, EventArgs e) 
{
   int index = 0;
   RepeaterItem myItem = new RepeaterItem(index, ListItemType.Item);
}
   
// </Snippet1>
}
