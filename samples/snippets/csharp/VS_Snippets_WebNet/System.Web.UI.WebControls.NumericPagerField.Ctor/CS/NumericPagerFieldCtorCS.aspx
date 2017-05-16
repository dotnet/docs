<%-- <Snippet1> --%>
<%@ Page language="C#" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<script runat="server">

  // <Snippet2>  
  void Page_Load(Object sender, EventArgs e)
  {

    // Dynamically generated field pagers need to be created only 
    // the first time the page is loaded.
    if (!IsPostBack)
    {

      //Find the DataPager control within the ListView control.
      DataPager pagerControl = 
        (DataPager) ContactsListView.FindControl("ContactsDataPager");
      
      // Create a NumericPagerField object to display
      // the page numbers to navigate.
      NumericPagerField pagerField = new NumericPagerField();
      pagerField.ButtonCount = 15;
      pagerField.ButtonType = ButtonType.Button;

      // Add the pager field to the Fields collection of the
      // DataPager control.
      pagerControl.Fields.Add(pagerField);
    }

    ContactsListView.DataBind();
  
  }
  // </Snippet2>
  
</script>
    
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>NumericPagerField Constructor Example</title>
  </head>
  <body>
    <form id="form1" runat="server">
        
      <h3>NumericPagerField Constructor Example</h3>
          
      <asp:ListView ID="ContactsListView" 
        DataSourceID="ContactsDataSource"
        runat="server">
        <LayoutTemplate>
          <asp:Panel runat="server" ID="Panel1" BorderStyle="Groove">
            <asp:Label runat="server" ID="itemPlaceholder"></asp:Label>
          </asp:Panel>
          <br />
          <asp:DataPager runat="server" 
            PageSize="25"
            ID="ContactsDataPager" />      
        </LayoutTemplate>
        <ItemTemplate>
          <asp:Label runat="server" ID="NameLabel" 
            Text='<%#Eval("LastName") + ", " + Eval("FirstName")%>' />
          <br />
        </ItemTemplate>
      </asp:ListView>

      <!-- This example uses Microsoft SQL Server and connects      -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET    -->
      <!-- expression to retrieve the connection string value       -->
      <!-- from the Web.config file.                                -->
      <asp:SqlDataSource ID="ContactsDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        SelectCommand="SELECT [ContactID], [FirstName], [LastName] 
          FROM Person.Contact
          ORDER BY [LastName]">
      </asp:SqlDataSource>
      
    </form>
  </body>
</html>
<%-- </Snippet1> --%>