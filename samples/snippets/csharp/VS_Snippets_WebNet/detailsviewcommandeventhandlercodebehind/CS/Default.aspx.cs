// <Snippet2>
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Create a new DetailsView object.
        DetailsView customerDetailsView = new DetailsView();

        // Set the DetailsView object's properties.
        customerDetailsView.ID = "CustomerDetailsView";
        customerDetailsView.DataSourceID = "DetailsViewSource";
        customerDetailsView.AutoGenerateRows = true;
        customerDetailsView.AllowPaging = true;
        customerDetailsView.DataKeyNames = new String[1] { "CustomerID" };

        // Add a button field to the DetailsView control.
        ButtonField field = new ButtonField();
        field.ButtonType = ButtonType.Link;
        field.CausesValidation = false;
        field.Text = "Add to List";
        field.CommandName = "Add";

        customerDetailsView.Fields.Add(field);

        // Programmatically register the event-handling method
        // for the ItemDeleting event of a DetailsView control.
        customerDetailsView.ItemCommand += new DetailsViewCommandEventHandler(this.CustomerDetailsView_ItemCommand);

        // Add the DetailsView object to the Controls collection
        // of the PlaceHolder control.
        DetailsViewPlaceHolder.Controls.Add(customerDetailsView);
    }

    void CustomerDetailsView_ItemCommand(Object sender, DetailsViewCommandEventArgs e)
    {

        // Use the CommandName property to determine which button
        // was clicked. 
        if (e.CommandName == "Add")
        {
            // Get the DetailsView control that raised the event.
            DetailsView customerDetailsView = (DetailsView)sender;

            // Add the current customer to the customer list. 

            // Get the row that contains the company name. In this
            // example, the company name is in the second row (index 1)  
            // of the DetailsView control.
            DetailsViewRow row = customerDetailsView.Rows[1];

            // Get the company's name from the appropriate cell.
            // In this example, the company name is in the second cell  
            // (index 1) of the row.
            String name = row.Cells[1].Text;

            // Create a ListItem object with the company name.
            ListItem item = new ListItem(name);

            // Add the ListItem object to the ListBox, if the 
            // item doesn't already exist.
            if (!CustomerListBox.Items.Contains(item))
            {
                CustomerListBox.Items.Add(item);
            }

        }

    }
}
// </Snippet2>
