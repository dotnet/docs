<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub ProductFormView_ItemCommand(ByVal sender As Object, ByVal e As FormViewCommandEventArgs)

    ' The ItemCommand event is raised when any button within
    ' the FormView control is clicked. Use the CommandName property 
    ' to determine which button was clicked. 
    If e.CommandName = "Add" Then

      ' Add the product to the ListBox control. 
      
      ' Use the Row property to retrieve the data row.
      Dim row As FormViewRow = ProductFormView.Row
      
      ' Retrieve the ProductNameLabel control from
      ' the data row.
      Dim productNameLabel As Label = CType(row.FindControl("ProductNameLabel"), Label)

      ' Retrieve the QuantityTextBox control from
      ' the data row.
      Dim quantityTextBox As TextBox = CType(row.FindControl("QuantityTextBox"), TextBox)

      If productNameLabel IsNot Nothing And quantityTextBox IsNot Nothing Then
          
        ' Get the product name from the ProductNameLabel control.
        Dim name As String = productNameLabel.Text
        
        ' Get the quantity from the QuantityTextBox control.
        Dim quantity As String = quantityTextBox.Text

        ' Create the text to display in the ListBox control.
        Dim description As String = name & " - " & quantity & " Qty"

        ' Create a ListItem object using the description and
        ' product name.
        Dim item As new ListItem(description, name)

        ' Add the ListItem object to the ListBox.
        ProductListBox.Items.Add(item)

        ' Use the CommandSource property to retrieve
        ' the Add button. Disable the button after
        ' the user adds the currently displayed employee
        ' name to the ListBox control.
        Dim addButton As Button = CType(e.CommandSource, Button)
        addButton.Enabled = False
        
      End If

    End If

  End Sub

  Sub ProductFormView_DataBound(ByVal sender As Object, ByVal e As EventArgs)
    
    ' To prevent the user from adding duplicate items, 
    ' disable the Add button if the item being bound to the 
    ' FormView control is already in the ListBox control.
    
    ' Use the Row property to retrieve the data row.
    Dim row As FormViewRow = ProductFormView.Row

    ' Retrieve the Add button from the data row.
    Dim addButton As Button = CType(row.FindControl("AddButton"), Button)

    ' Retrieve the ProductNameLabel control from
    ' data row.
    Dim productNameLabel As Label = CType(row.FindControl("ProductNameLabel"), Label)

    If addButton IsNot Nothing And productNameLabel IsNot Nothing Then
    
      ' Get the product name from the ProductNameLabel 
      ' control.
      Dim name As String = productNameLabel.Text

      ' Use the FindByValue method to determine whether
      ' the ListBox control already contains an entry for
      ' the item.
      Dim item As ListItem = ProductListBox.Items.FindByValue(name)

      ' Disable the Add button if the ListBox control
      ' already contains the item.
      If item IsNot Nothing Then
      
        addButton.Enabled = False
      
      Else
      
        addButton.Enabled = True
        
      End If
      
    End If

  End Sub
    
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