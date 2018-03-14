using System;
// <Snippet2>
using System.Web.DynamicData;

public partial class DynamicData_FieldTemplates_UnitsInStock :  FieldTemplateUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // DataBinding event handler.
    public void DataBindingHandler(object sender, EventArgs e)
    {
        // Define product understocked threshold.
        short underStockedThreshold = 150;
  
        // Get the current number of items in stock.
        short currentValue = (short)FieldValue;
       
        // Check product stock. 
        if (currentValue < underStockedThreshold)
        {
            // The product is understocked, set its 
            // foreground color to red.
            TextLabel1.ForeColor = System.Drawing.Color.Red;
        }
    }

}
// </Snippet2>