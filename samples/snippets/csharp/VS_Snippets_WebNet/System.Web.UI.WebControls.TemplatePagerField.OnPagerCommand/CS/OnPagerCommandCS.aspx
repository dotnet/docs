<%-- <Snippet1> --%>
<%@ Page language="C#" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<script runat="server">

  // <Snippet2>  
  protected void TemplatePagerField_OnPagerCommand(object sender, DataPagerCommandEventArgs e)
  { 
    // Check which button raised the event
    switch(e.CommandName)
    {
      case "Next":
        int newIndex = e.Item.Pager.StartRowIndex + e.Item.Pager.PageSize;
        if (newIndex <= e.TotalRowCount)
        {
          e.NewStartRowIndex = newIndex;
          e.NewMaximumRows = e.Item.Pager.MaximumRows;
        }
        break;
      case "Previous":
        e.NewStartRowIndex = e.Item.Pager.StartRowIndex - e.Item.Pager.PageSize;
        e.NewMaximumRows = e.Item.Pager.MaximumRows;
        break;
      case "First":
        e.NewStartRowIndex = 0;
        e.NewMaximumRows = e.Item.Pager.MaximumRows;
        break;
    }
  }
  // </Snippet2>
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>TemplatePagerField.OnPagerCommand Example</title>    
    <style type="text/css">
      body 	
      {
      	text-align: center;
      	font: 12px Arial, Helvetica, sans-serif;
      }
      .item
      {
        border: solid 1px #2F4F4F;
        background: #E6E6FA;
      }
    </style>
  </head>
  <body>
    <form id="form1" runat="server">
        
      <h3>TemplatePagerField.OnPagerCommand Example</h3>
          
      <asp:ListView ID="StoresListView" 
        DataSourceID="StoresDataSource"
        runat="server">
        <LayoutTemplate>
          <table width="350" runat="server" id="tblStore">
            <tr runat="server">
              <th runat="server">ID</th>
              <th runat="server">Store Name</th>
            </tr>
            <tr id="itemPlaceholder" runat="server">
            </tr>
          </table>
         </LayoutTemplate>
         <ItemTemplate>
          <tr runat="server">
            <td class="item">
              <asp:Label ID="IDLabel" runat="server" Text='<%#Eval("CustomerID") %>' />
            </td>            
            <td align="left" class="item">
              <asp:Label ID="NameLabel" runat="server" Text='<%#Eval("Name")%>' />
            </td>
          </tr>
        </ItemTemplate>
      </asp:ListView>
      <br />
      
      <asp:DataPager runat="server" 
        ID="ContactsDataPager" 
        PageSize="30"
        PagedControlID="StoresListView">
        <Fields>
          <asp:TemplatePagerField OnPagerCommand="TemplatePagerField_OnPagerCommand">
            <PagerTemplate> 
              <asp:LinkButton ID="FirstButton" runat="server" CommandName="First" 
                Text="<<" Enabled='<%# Container.StartRowIndex > 0 %>' />
              <asp:LinkButton ID="PreviousButton" runat="server" CommandName="Previous" 
                Text='<%# (Container.StartRowIndex - Container.PageSize + 1) + " - " + (Container.StartRowIndex) %>'
                Visible='<%# Container.StartRowIndex > 0 %>' />
              <asp:Label ID="CurrentPageLabel" runat="server"
                Text='<%# (Container.StartRowIndex + 1) + "-" + (Container.StartRowIndex + Container.PageSize > Container.TotalRowCount ? Container.TotalRowCount : Container.StartRowIndex + Container.PageSize) %>' />
              <asp:LinkButton ID="NextButton" runat="server" CommandName="Next"
                Text='<%# (Container.StartRowIndex + Container.PageSize + 1) + " - " + (Container.StartRowIndex + Container.PageSize*2 > Container.TotalRowCount ? Container.TotalRowCount : Container.StartRowIndex + Container.PageSize*2) %>' 
                Visible='<%# (Container.StartRowIndex + Container.PageSize) < Container.TotalRowCount %>' />
            </PagerTemplate>
          </asp:TemplatePagerField>
        </Fields>
      </asp:DataPager>     

      <!-- This example uses Microsoft SQL Server and connects      -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET    -->
      <!-- expression to retrieve the connection string value       -->
      <!-- from the Web.config file.                                -->
      <asp:SqlDataSource ID="StoresDataSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
            SelectCommand="SELECT [CustomerID], [Name] FROM Sales.Store ORDER BY [Name]">
      </asp:SqlDataSource>
      
    </form>
  </body>
</html>
<%-- </Snippet1> --%>