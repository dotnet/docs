<!-- <Snippet1> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  protected void Page_Init(object sender, EventArgs e)
  {
    DynamicDataManager1.RegisterControl(ListView1);
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>DynamicControl Sample</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:DynamicDataManager ID="DynamicDataManager1" runat="server"
        AutoLoadForeignKeys="true" />

      <asp:ValidationSummary ID="InsertValidationSummary" runat="server" EnableClientScript="true" 
        HeaderText="List of validation errors" ValidationGroup="Insert" />        
      <asp:DynamicValidator runat="server" ID="InsertValidator"
        ControlToValidate="ListView1" ValidationGroup="Insert" Display="None" />
      <asp:ValidationSummary ID="EditValidationSummary" runat="server" EnableClientScript="true" 
        HeaderText="List of validation errors" ValidationGroup="Edit" />
      <asp:DynamicValidator runat="server" ID="EditValidator" 
        ControlToValidate="ListView1" ValidationGroup="Edit" Display="None" />
      
      <asp:ListView ID="ListView1" runat="server" DataSourceID="LinqDataSource1"
        InsertItemPosition="LastItem">
        <LayoutTemplate>
          <table cellpadding="2" border="1" runat="server" id="tblCustomers">
            <tr runat="server">
              <th runat="server">&nbsp;</th>              
              <th runat="server">Name</th>
              <th runat="server">Number</th>
              <th runat="server">Standard Cost</th>
              <th runat="server">List Price</th>
              <th runat="server">Sell Start Date</th>
            </tr>
            <tr runat="server" id="itemPlaceholder" />
          </table>
          <asp:DataPager runat="server" ID="CustomersPager" PageSize="20">
            <Fields>
              <asp:NumericPagerField ButtonCount="10" />
            </Fields>
          </asp:DataPager>
        </LayoutTemplate>
        <ItemTemplate>
          <tr runat="server">
            <td>
              <asp:LinkButton ID="EditButton" runat="server" CommandName="Edit" 
                Text="Edit" CausesValidation="false" />
              <asp:LinkButton ID="DeleteButton" runat="server" CommandName="Delete" 
                Text="Delete" CausesValidation="false" 
                OnClientClick='return confirm("Are you sure you want to delete this item?");' />
            </td>
            <td>
              <asp:DynamicControl runat="server" DataField="Name" />
            </td>
            <td>
              <asp:DynamicControl runat="server" DataField="ProductNumber" />
            </td>
            <td align="right">
              <asp:DynamicControl runat="server" DataField="StandardCost" DataFormatString="{0:C}" />
            </td>
            <td align="right">
              <asp:DynamicControl runat="server" DataField="ListPrice" DataFormatString="{0:C}" />
            </td>
            <td align="center">
              <asp:DynamicControl runat="server" DataField="SellStartDate" 
                DataFormatString="{0:MM/dd/yyyy}" NullDisplayText="&nbsp;" />
            </td>
          </tr>
        </ItemTemplate>
        <EditItemTemplate>
          <tr>
            <td>
              <asp:LinkButton ID="UpdateButton" runat="server" CommandName="Update" 
                Text="Update" ValidationGroup="Edit" />
              <asp:LinkButton ID="CancelButton" runat="server" CommandName="Cancel" 
                Text="Cancel" CausesValidation="false" />
            </td>
            <td>
              <asp:DynamicControl runat="server" DataField="Name" Mode="Edit" ValidationGroup="Edit" />
            </td>
            <td>
              <asp:DynamicControl runat="server" DataField="ProductNumber" Mode="Edit" ValidationGroup="Edit" />
            </td>
            <td>
              <asp:DynamicControl runat="server" DataField="StandardCost" Mode="Edit" ValidationGroup="Edit" />
            </td>
            <td>
              <asp:DynamicControl runat="server" DataField="ListPrice" Mode="Edit" ValidationGroup="Edit" />
            </td>
            <td>
              <asp:DynamicControl runat="server" DataField="SellStartDate" Mode="Edit" 
                ValidationGroup="Edit" DataFormatString="{0:MM/dd/yyyy}" ApplyFormatInEditMode="true" />
            </td>
          </tr>
        </EditItemTemplate>
        <InsertItemTemplate>
          <tr>
            <td>
              <asp:LinkButton ID="InsertButton" runat="server" CommandName="Insert" 
                Text="Insert" ValidationGroup="Insert" />
              <asp:LinkButton ID="CancelButton" runat="server" CommandName="Cancel" 
                Text="Cancel" CausesValidation="false" />
            </td>
            <td>
              <asp:DynamicControl runat="server" DataField="Name" Mode="Insert" ValidationGroup="Insert" />
            </td>
            <td>
              <asp:DynamicControl runat="server" DataField="ProductNumber" Mode="Insert" ValidationGroup="Insert" />
            </td>
            <td>
              <asp:DynamicControl runat="server" DataField="StandardCost" Mode="Insert" ValidationGroup="Insert" />
            </td>
            <td>
              <asp:DynamicControl runat="server" DataField="ListPrice" Mode="Insert" ValidationGroup="Insert" />
            </td>
            <td>
              <asp:DynamicControl runat="server" DataField="SellStartDate" Mode="Insert" ValidationGroup="Insert" />
            </td>
          </tr>
        </InsertItemTemplate>
      </asp:ListView>

      <!-- This example uses Microsoft SQL Server and connects   -->
      <!-- to the AdventureWorksLT sample database.              -->
      <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        TableName="Products"
        ContextTypeName="AdventureWorksLTDataContext"
        EnableUpdate="true"
        EnableDelete="true"
        EnableInsert="true" >
      </asp:LinqDataSource>
          
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->