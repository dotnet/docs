using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public class Form1: Page
{
// <Snippet1>
void Page_Load(Object sender, EventArgs e) 
{
   int index = 0;
   DataListItem myItem = new DataListItem(index, ListItemType.Item);
}
   
// </Snippet1>
}
