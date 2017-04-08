<%-- <Snippet1> --%>
<%@ Page language="C#" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<script runat="server">

  void Page_Load()
  {
    Message.Text = String.Empty;
  }
      
  //<Snippet2>
  void ProductsListView_SelectedIndexChanging(Object sender, ListViewSelectEventArgs e)
  {
    ListViewItem item = (ListViewItem)ProductsListView.Items[e.NewSelectedIndex];
    Label l = (Label)item.FindControl("DiscontinuedDateLabel");

    if (String.IsNullOrEmpty(l.Text))
    {
      return;
    }

    DateTime discontinued = DateTime.Parse(l.Text);
    if (discontinued < DateTime.Now)
    {
      Message.Text = "You cannot select a discontinued item.";
      e.Cancel = true;
    }
  }
  //</Snippet2>

  protected void ProductsListView_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
  {
    // Clear selection.
    ProductsListView.SelectedIndex = -1;
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>ListView.SelectedIndexChanging Example</title>
  </head>
  <body>
    <form id="form1" runat="server">
        
      <h3>ListView.SelectedIndexChanging Example</h3>

      <asp:Label ID="Message"
        ForeColor="Red"          
        runat="server"/>
      <br/>
     
      <asp:ListView ID="ProductsListView" 
        DataSourceID="ProductsDataSource" 
        DataKeyNames="ProductID"
        OnSelectedIndexChanging="ProductsListView_SelectedIndexChanging"         
        OnPagePropertiesChanging="ProductsListView_PagePropertiesChanging"
        runat="server" >
        <LayoutTemplate>
          <table cellpadding="2" runat="server" id="tblProducts" width="640px">
            <tr runat="server" id="itemPlaceholder" />
          </table>
          <asp:DataPager runat="server" ID="ProductsDataPager" PageSize="12">
            <Fields>
              <asp:NextPreviousPagerField 
                ShowFirstPageButton="true" ShowLastPageButton="true"
                FirstPageText="|&lt;&lt; " LastPageText=" &gt;&gt;|"
                NextPageText=" &gt; " PreviousPageText=" &lt; " />
            </Fields>
          </asp:DataPager>
        </LayoutTemplate>
        <ItemTemplate>
          <tr runat="server">
            <td valign="top">
              <asp:LinkButton ID="SelectButton" runat="server" Text="..." CommandName="Select" />
            </td>
            <td valign="top">
              <asp:Label ID="NameLabel" runat="server" Text='<%#Eval("Name") %>' />
            </td>
            <td valign="top">
              <asp:Label ID="ProductNumberLabel" runat="server" Text='<%#Eval("ProductNumber") %>' />
            </td>
            <td>
              <asp:Label ID="DiscontinuedDateLabel" runat="server" Text='<%#Eval("DiscontinuedDate", "{0:d}") %>' />
            </td>
          </tr>
        </ItemTemplate>
        <SelectedItemTemplate>
          <tr runat="server" style="background-color:#ADD8E6">
            <td>&nbsp;</td>
            <td valign="top">
              <asp:Label ID="NameLabel" runat="server" Text='<%#Eval("Name") %>' />
            </td>
            <td valign="top">
              <asp:Label ID="ProductNumberLabel" runat="server" Text='<%#Eval("ProductNumber") %>' />
            </td>
            <td>
              <asp:Label ID="DiscontinuedDateLabel" runat="server" Text='<%#Eval("DiscontinuedDate", "{0:d}") %>' />
            </td>
          </tr>
        </SelectedItemTemplate>
      </asp:ListView>
            
      <asp:SqlDataSource ID="ProductsDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        SelectCommand="SELECT [ProductID], [Name], [ProductNumber], [DiscontinuedDate] 
          FROM Production.Product"
        UpdateCommand="UPDATE Production.Product
           SET Name = @Name, ProductNumber = @ProductNumber, DiscontinuedDate = @DiscontinuedDate
           WHERE ProductID = @ProductID">
      </asp:SqlDataSource>
      
    </form>
  </body>
</html>
<%-- </Snippet1> --%>