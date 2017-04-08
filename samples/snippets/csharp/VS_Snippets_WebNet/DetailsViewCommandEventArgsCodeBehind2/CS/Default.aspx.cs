// <Snippet2>
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page
{
	public void ItemDetailsView_ItemCommand(Object sender, DetailsViewCommandEventArgs e)
	{

		// Use the CommandName property to determine which button
		// was clicked. 
		if (e.CommandName == "Add")
		{

			// Add the customer to the customer list. 

			// Get the row that contains the company name. In this
			// example, the company name is in the second row (index 1)  
			// of the DetailsView control.
			DetailsViewRow row = ItemDetailsView.Rows[1];

			// Get the company's name from the appropriate cell.
			// In this example, the company name is in the second cell  
			// (index 1) of the row.
			String name = row.Cells[1].Text;

			// Create a ListItem object with the company name.
			ListItem item = new ListItem(name);

			// Add the ListItem object to the ListBox control, if the 
			// item does not already exist.
			if (!CustomerListBox.Items.Contains(item))
			{
				CustomerListBox.Items.Add(item);
			}

		}

	}
}
// </Snippet2>