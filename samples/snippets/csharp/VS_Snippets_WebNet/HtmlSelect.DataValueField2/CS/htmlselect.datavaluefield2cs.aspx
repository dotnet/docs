<!--<Snippet1>-->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server" language="C#">
  
  void SubmitButton_Click (object sender, System.EventArgs e)
  {
    // Iterate through the list items in the 
    // HtmlSelect control to find the selected item.
    for (int i = 0; i <= Select1.Items.Count - 1; i++)
    {
      if (Select1.Items[i].Selected)
        // Display the Value property of the selected item.
        // This property is populated by the DataValueField property.
        Label1.Text = "The Product ID is " + Select1.Items[i].Value;
    }
  }
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>HtmlSelect.DataValueField</title>
</head>
<body>
  <form id="Form1" runat="server">  

    <h3> HtmlSelect.DataValueField Example 2</h3>

    <p>Select an item from the list:</p>

    <select id="Select1"
      name="Select1"             
      datasourceid="SqlDataSource1"
      datatextfield="ProductName"
      datavaluefield="ProductID"
      runat="server">
    </select>
       
    <asp:sqldatasource id="SqlDataSource1"          
          connectionstring="workstation id=localhost;integrated security=SSPI;initial catalog=Northwind"
      selectcommand="SELECT * FROM [Products] Where ProductID <= 5"
      runat="server">
    </asp:sqldatasource>
    
    <asp:button id="SubmitButton"
      text="Submit"
      onclick="SubmitButton_Click"
      runat="Server">
    </asp:button>
    
    <br /><br />
    
    <asp:label id="Label1"
      runat="Server">
    </asp:label>

   </form>

</body>

</html>
<!--</Snippet1>-->
