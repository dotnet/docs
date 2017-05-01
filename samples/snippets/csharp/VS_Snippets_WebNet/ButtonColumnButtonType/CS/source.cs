using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public class Page1: Page
{
    protected DataGrid ItemsGrid;
    // <Snippet1>
    private void Page_Init(Object sender, EventArgs e) 
    {

       // Create dynamic column to add to Columns collection.
       ButtonColumn AddColumn = new ButtonColumn();
       AddColumn.HeaderText="Add Item"; 
       AddColumn.Text="Add";
       AddColumn.CommandName="Add";
       AddColumn.ButtonType = ButtonColumnType.PushButton;


       // Add column to Columns collection.
       ItemsGrid.Columns.AddAt(2, AddColumn);

    }
   
// </Snippet1>
}
