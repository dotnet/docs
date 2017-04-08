<%-- <Snippet1> --%>
<%@ Page language="C#" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  protected void ContactsGridView_SelectedIndexChanged(object sender, EventArgs e)
  {
    if (ContactsGridView.SelectedIndex >= 0)
      ViewState["SelectedKey"] = ContactsGridView.SelectedValue;
    else
      ViewState["SelectedKey"] = null;
  }

  protected void ContactsGridView_DataBound(object sender, EventArgs e)
  {
    for (int i = 0; i < ContactsGridView.Rows.Count; i++)
    {
      // Ignore values that cannot be cast as integer.
      try
      {
        if ((int)ContactsGridView.DataKeys[i].Value == (int)ViewState["SelectedKey"])
          ContactsGridView.SelectedIndex = i;
      }
      catch { }
    }
  }

  protected void ContactsGridView_Sorting(object sender, GridViewSortEventArgs e)
  {
    ContactsGridView.SelectedIndex = -1;
  }

  protected void ContactsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
  {
    ContactsGridView.SelectedIndex = -1;
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>GridView OnSelectedIndexChanged Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridView OnSelectedIndexChanged Example</h3>
      
      <asp:GridView ID="ContactsGridView"
        DataSourceID="ContactsDataSource" 
        DataKeyNames="ContactID"        
        AutoGenerateSelectButton="True"
        OnSelectedIndexChanged="ContactsGridView_SelectedIndexChanged"        
        AllowPaging="True" AllowSorting="True" 
        OnDataBound="ContactsGridView_DataBound" 
        OnSorting="ContactsGridView_Sorting" 
        OnPageIndexChanging="ContactsGridView_PageIndexChanging"
        runat="server">
        <SelectedRowStyle BackColor="Aqua" />
      </asp:GridView>
            
      <!-- This example uses Microsoft SQL Server and connects      -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET    -->
      <!-- expression to retrieve the connection string value       -->
      <!-- from the Web.config file.                                -->
      <asp:SqlDataSource ID="ContactsDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        SelectCommand="SELECT [ContactID], [FirstName], [LastName] FROM Person.Contact">
      </asp:SqlDataSource>


    </form>
  </body>
</html>
<%-- </Snippet1> --%>