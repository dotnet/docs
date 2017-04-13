<%-- <Snippet1> --%>
<%@ Page language="C#" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  // <Snippet2>
  protected void TemplatePagerField_OnPagerCommand(object sender, DataPagerCommandEventArgs e)
  {     
      // Get the new page number 
      TextBox PageNumberTextBox = (TextBox)e.Item.FindControl("PageNumberTextBox");
      int newPageNumber = -1;
      try
      {
        newPageNumber = Convert.ToInt32(PageNumberTextBox.Text.Trim());
      }
      catch (FormatException)
      {
        Message.Text = "Invalid page number.";
        return;
      }
      catch (OverflowException)
      {
        Message.Text = "Invalid page number.";
        return;
      }

      int newIndex = (newPageNumber - 1) * e.Item.Pager.PageSize;
      //Verify if the new index is valid
      if (newIndex >= 0 && newIndex <= e.TotalRowCount)
      {
        //Set the new start index and maximum rows
        e.NewStartRowIndex = newIndex;
        e.NewMaximumRows = e.Item.Pager.MaximumRows;
      }
      else
        Message.Text = "Invalid page number.";
  }
  // </Snippet2>

  protected void Page_Load(object sender, EventArgs e)
  {
    Message.Text = "";
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>DataPagerCommandEventArgs Example</title>    
    <style type="text/css">
      body 	
      {
      	text-align: center;
      	font: 12px Arial, Helvetica, sans-serif;
      }
      .item
      {
          border: 1px solid #8b7e66;
          background: white;
          min-height: 19px;
          width: 33%;
      }
      .alternatingItem
      {
        border: solid 1px #8b7e66;
        background: #f5deb3;
        width: 33%;
        min-height: 19px;
      }      
    </style>
  </head>
  <body>
    <form id="form1" runat="server">
        
    <h3>DataPagerCommandEventArgs Example</h3>

      <asp:ListView ID="ContactsListView" 
        DataSourceID="ContactsDataSource"
        GroupItemCount="3"
        runat="server">
        <LayoutTemplate>
          <table cellpadding="4" width="640px" id="tblProducts" runat="server">
            <tr runat="server" id="groupPlaceholder" />
          </table>
          <asp:DataPager runat="server" 
            ID="ContactsDataPager" 
            PageSize="30"
            PagedControlID="ContactsListView">
            <Fields>
              <asp:TemplatePagerField OnPagerCommand="TemplatePagerField_OnPagerCommand">
                <PagerTemplate>
                  <b>
                  Page
                  <asp:Label runat="server" ID="CurrentPageLabel" 
                    Text="<%# Container.TotalRowCount>0 ? (Container.StartRowIndex / Container.PageSize) + 1 : 0 %>" />
                  of
                  <asp:Label runat="server" ID="TotalPagesLabel" 
                    Text="<%# Math.Ceiling ((double)Container.TotalRowCount / Container.PageSize) %>" />
                  </b>              
                  <br /><br />
                  Jump to page:
                  <asp:TextBox ID="PageNumberTextBox" runat="server" 
                    Width="30px" 
                    Text="<%# Container.TotalRowCount>0 ? (Container.StartRowIndex / Container.PageSize) + 1 : 0 %>" />                      
                  <asp:Button ID="GoButton" runat="server" Text="Go" />
                  <br /><br />
                </PagerTemplate>
              </asp:TemplatePagerField>
            </Fields>
          </asp:DataPager>
        </LayoutTemplate>
        <GroupTemplate>
          <tr runat="server" id="ProductsRow">
            <td runat="server" id="itemPlaceholder" />
          </tr>
        </GroupTemplate>
        <ItemTemplate>
          <td class="item" runat="server">
            <asp:Label ID="NameLabel" runat="server" 
              Text='<%# Eval("LastName") + ", " + Eval("FirstName")%>' />
          </td>
        </ItemTemplate>
        <AlternatingItemTemplate>
          <td class="alternatingItem" runat="server">
            <asp:Label ID="NameLabel" runat="server" 
              Text='<%# Eval("LastName") + ", " + Eval("FirstName")%>' />
          </td>
        </AlternatingItemTemplate>
      </asp:ListView>
      <br />      

      <asp:Label ID="Message"
        ForeColor="Red"
        runat="server"/>

      <!-- This example uses Microsoft SQL Server and connects      -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET    -->
      <!-- expression to retrieve the connection string value       -->
      <!-- from the Web.config file.                                -->
      <asp:SqlDataSource ID="ContactsDataSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
            SelectCommand="SELECT [ContactID], [FirstName], [LastName] 
              FROM Person.Contact">
      </asp:SqlDataSource>
      
    </form>
  </body>
</html>
<%-- </Snippet1> --%>
