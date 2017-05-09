<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void ProductFormView_ItemCommand(Object sender, FormViewCommandEventArgs e)
  {

    // The ItemCommand event is raised when any button within
    // the FormView control is clicked. Use the CommandName property 
    // to determine which button was clicked. 
    if (e.CommandName == "Add")
    {

      // Add the product to the ListBox control. 
      
      // Use the Row property to retrieve the data row.
      FormViewRow row = ProductFormView.Row;
      
      // Retrieve the ProductNameLabel control from
      // the data row.
      Label productNameLabel = (Label)row.FindControl("ProductNameLabel");

      // Retrieve the QuantityTextBox control from
      // the data row.
      TextBox quantityTextBox = (TextBox)row.FindControl("QuantityTextBox");

      if (productNameLabel != null && quantityTextBox != null)
      {    
        // Get the product name from the ProductNameLabel control.
        string name = productNameLabel.Text;
        
        // Get the quantity from the QuantityTextBox control.
        string quantity = quantityTextBox.Text;

        // Create the text to display in the ListBox control.
        string description = name + " - " + quantity + " Qty";

        // Create a ListItem object using the description and
        // product name.
        ListItem item = new ListItem(description, name);

        // Add the ListItem object to the ListBox.
        ProductListBox.Items.Add(item);

        // Use the CommandSource property to retrieve
        // the Add button. Disable the button after
        // the user adds the currently displayed employee
        // name to the ListBox control.
        Button addButton = (Button)e.CommandSource;
        addButton.Enabled = false;
      }

    }

  }

  void ProductFormView_DataBound(Object sender, EventArgs e)
  {
    
    // To prevent the user from adding duplicate items, 
    // disable the Add button if the item being bound to the 
    // FormView control is already in the ListBox control.
    
    // Use the Row property to retrieve the data row.
    FormViewRow row = ProductFormView.Row;

    // Retrieve the Add button from the data row.
    Button addButton = (Button)row.FindControl("AddButton");

    // Retrieve the ProductNameLabel control from
    // data row.
    Label productNameLabel = (Label)row.FindControl("ProductNameLabel");

    if (addButton != null && productNameLabel != null)
    {
      // Get the product name from the ProductNameLabel 
      // control.
      string name = productNameLabel.Text;

      // Use the FindByValue method to determine whether
      // the ListBox control already contains an entry for
      // the item.
      ListItem item = ProductListBox.Items.FindByValue(name);

      // Disable the Add button if the ListBox control
      // already contains the item.
      if (item != null)
      {
        addButton.Enabled = false;
      }
      else
      {
        addButton.Enabled = true;
      }
    }

  }
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>FormViewCommandEventArgs Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>FormViewCommandEventArgs Example</h3>
                       
      <asp:formview id="ProductFormView"
        datasourceid="ProductSource"
        allowpaging="true"
        datakeynames="ProductID"
        onitemcommand="ProductFormView_ItemCommand"
        ondatabound="ProductFormView_DataBound"  
        runat="server">
        
        <itemtemplate>
        
          <table>
            <tr>
              <td style="width:400px">
                <b>Description:</b>
                <asp:label id="ProductNameLabel"
                  text='<%# Eval("ProductName") %>'
                  runat='server'/>
                <br/>      
                <b>Price:</b>
                <asp:label id="PriceLabel"
                  text='<%# Eval("UnitPrice", "{0:c}") %>'
                  runat='server'/>
                <br/>  
                <asp:textbox id="QuantityTextBox"
                  width="50px"
                  maxlength="3" 
                  runat="server"/> Qty                   
              </td>
            </tr>
            <tr>
              <td>
                <asp:requiredfieldvalidator ID="QuantityRequiredValidator"
                  controltovalidate="QuantityTextBox"
                  text="Please enter a quantity."
                  display="Static"
                  runat="server"/>
                <br/>
                <asp:CompareValidator id="QuantityCompareValidator"
                  controltovalidate="QuantityTextBox"
                  text="Please enter an integer value."
                  display="Static"
                  type="Integer"
                  operator="DataTypeCheck"  
                  runat="server"/>    
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:button id="AddButton"
                  text="Add"
                  commandname="Add"
                  runat="server"/>
              </td>
            </tr>
          </table>
        
        </itemtemplate>
                  
      </asp:formview>
      
      <br/><br/><hr/>
      
      Items:<br/>
      <asp:listbox id="ProductListBox"
        runat="server"/>
          
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="ProductSource"
        selectcommand="Select [ProductID], [ProductName], [UnitPrice] From [Products]"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->