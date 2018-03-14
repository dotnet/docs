using System;
using System.Data;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

public class Page1: Page
{
// <Snippet1>
void Item_Created(Object sender, DataGridItemEventArgs e) 
{
    DataGridItemEventArgs DG_event_arg = new DataGridItemEventArgs(e.Item);
}
// </Snippet1>
}
