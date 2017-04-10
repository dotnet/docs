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
  void ProductsListView_ItemEditing(Object sender, ListViewEditEventArgs e)
  {
    ListViewItem item = ProductsListView.Items[e.NewEditIndex];
    Label dateLabel = (Label)item.FindControl("DiscontinuedDateLabel");
    
    if (String.IsNullOrEmpty(dateLabel.Text))
      return;
    
    //Verify if the item is discontinued.
    DateTime discontinuedDate = DateTime.Parse(dateLabel.Text);
    if (discontinuedDate < DateTime.Now)
    {
      Message.Text = "You cannot edit a discontinued item.";
      e.Cancel = true;
      ProductsListView.SelectedIndex = -1;
    }       
  }
  //</Snippet2>

  void DiscontinuedDateCalendar_OnSelectionChanged(Object sender, EventArgs e)
  {
    TextBox dateTextBox = 
      (TextBox)ProductsListView.EditItem.FindControl("DiscontinuedDateTextBox");
    Calendar calendarObject = (Calendar)sender;
    dateTextBox.Text = calendarObject.SelectedDate.ToString("d");
  }

  DateTime GetDateTime(object dateValue)
  {
    if (dateValue == DBNull.Value)
      return DateTime.Now;
    else
      return (DateTime)dateValue;
  }

  protected void ProductsListView_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
  {
    // Clears the edit index selection when paging.
    ProductsListView.EditIndex = -1;
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>ListView Edit Item Example</title>
  </head>
  <body>
    <form id="form1" runat="server">
        
      <h3>ListView Edit Item Example</h3>
            
      <asp:Label ID="Message"
        ForeColor="Red"          
        runat="server"/>
      <br/>
     
      <asp:ListView ID="ProductsListView" 
        DataSourceID="ProductsDataSource" 
        DataKeyNames="ProductID"
        OnItemEditing="ProductsListView_ItemEditing" 
        ConvertEmptyStringToNull="true"        
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
              <asp:LinkButton ID="EditButton" runat="server" Text="Edit" CommandName="Edit" />
            </td>
            <td valign="top">
              <asp:Label ID="NameLabel" runat="server" Text='<%#Eval("Name") %>' />
            </td>
            <td valign="top">
              <asp:Label ID="ProductNumberLabel" runat="server" Text='<%#Eval("ProductNumber") %>' />
            </td>
            <td>
              <asp:Label ID="DiscontinuedDateLabel" runat="server" 
                Text='<%#Eval("DiscontinuedDate", "{0:d}") %>' />
            </td>
          </tr>
        </ItemTemplate>
        <EditItemTemplate>
          <tr style="background-color:#ADD8E6">
            <td valign="top">
              <asp:LinkButton ID="UpdateButton" runat="server" 
                CommandName="Update" Text="Update" /><br />
              <asp:LinkButton ID="CancelButton" runat="server" 
                CommandName="Cancel" Text="Cancel" />
            </td>
            <td valign="top" colspan="2">
              <asp:Label runat="server" ID="NameLabel" 
                AssociatedControlID="NameTextBox" 
                Text="Name"/>
              <asp:TextBox ID="NameTextBox" runat="server" 
                Text='<%#Bind("Name") %>' MaxLength="50" /><br />
              <asp:Label runat="server" ID="ProductNumberLabel" 
                AssociatedControlID="ProductNumberTextBox" 
                Text="Product Number" />
              <asp:TextBox ID="ProductNumberTextBox" runat="server" 
                Text='<%#Bind("ProductNumber") %>' MaxLength="25" /><br />
            </td>
            <td>
              <asp:Label runat="server" ID="DiscontinuedDateLabel" 
                AssociatedControlID="DiscontinuedDateTextBox" 
                Text="Discontinued Date"/>
              <asp:TextBox ID="DiscontinuedDateTextBox" runat="server" 
                Text='<%# Bind("DiscontinuedDate", "{0:d}") %>'
                MaxLength="10" /><br />
              <asp:Calendar ID="DiscontinuedDateCalendar" runat="server" 
                SelectedDate='<%# GetDateTime(Eval("DiscontinuedDate")) %>'
                OnSelectionChanged="DiscontinuedDateCalendar_OnSelectionChanged" />
            </td>
          </tr>
        </EditItemTemplate>
      </asp:ListView>

      <!-- This example uses Microsoft SQL Server and connects      -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET    -->
      <!-- expression to retrieve the connection string value       -->
      <!-- from the Web.config file.                                -->            
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