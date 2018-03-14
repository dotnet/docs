using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public class Form1: Page
{
// <Snippet1>
void Item_Created(Object sender, DataListItemEventArgs e) 
{
   DataListItemEventArgs item_arg = new DataListItemEventArgs(e.Item);
}
   
// </Snippet1>
}
