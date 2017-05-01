<%-- <Snippet1> --%>
<%@ Page language="C#" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<script runat="server">
  //<Snippet2>
  void ContactsListView_Sorting(Object sender, ListViewSortEventArgs e)
  {
    // Check the sort direction to set the image URL accordingly.
    string imgUrl;
    if (e.SortDirection == SortDirection.Ascending)
      imgUrl = "~/images/ascending.gif";
    else
      imgUrl = "~/images/descending.gif";
      
    // Check which field is being sorted
    // to set the visibility of the image controls.
    Image sortImage1 = (Image) ContactsListView.FindControl("SortImage1");
    Image sortImage2 = (Image)ContactsListView.FindControl("SortImage2");
    Image sortImage3 = (Image)ContactsListView.FindControl("SortImage3");
    switch (e.SortExpression)
    {
      case "FirstName":
        sortImage1.Visible = true;
        sortImage1.ImageUrl = imgUrl;
        sortImage2.Visible = false;
        sortImage3.Visible = false;
        break;
      case "LastName":
        sortImage1.Visible = false;
        sortImage2.Visible = true;
        sortImage2.ImageUrl = imgUrl;
        sortImage3.Visible = false;
        break;
      case "EmailAddress":
        sortImage1.Visible = false;
        sortImage2.Visible = false;
        sortImage3.Visible = true;
        sortImage3.ImageUrl = imgUrl;
        break;
    }
  }
  //</Snippet2>
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>ListView Sorting Example</title>
    <style type="text/css">
      body  { font: 10pt Trebuchet MS, Arial, Tahoma; }
      td { border: 1px solid #E6E6FA; }
      .header {	background: #B0C4DE; }
      .alternatingItem { background: #edf5fd; }
    </style>
  </head>
  <body>
    <form id="form1" runat="server">
        
      <h3>ListView Sorting Example</h3>
      
      <asp:ListView ID="ContactsListView" 
        DataSourceID="ContactsDataSource" 
        OnSorting="ContactsListView_Sorting"
        runat="server">
        <LayoutTemplate>
          <table width="640px" runat="server" id="tblContacts">
            <tr class="header" align="center" runat="server">
              <td>
                <asp:LinkButton runat="server" ID="SortByFirstNameButton"
                  CommandName="Sort" Text="First Name" 
                  CommandArgument="FirstName"/>
                <asp:Image runat="server" ID="SortImage1" 
                  ImageUrl="~/images/ascending.gif" Visible="false" />
              </td>
              <td>
                <asp:LinkButton runat="server" ID="SortByLastNameButton"
                  CommandName="Sort" Text="Last Name"
                  CommandArgument="LastName" />
                <asp:Image runat="server" ID="SortImage2" 
                  ImageUrl="~/images/ascending.gif" Visible="false" />
              </td>
              <td>
                <asp:LinkButton runat="server" ID="SortByEmailButton"
                  CommandName="Sort" Text="E-mail Address" 
                  CommandArgument="EmailAddress" />
                <asp:Image runat="server" ID="SortImage3" 
                  ImageUrl="~/images/ascending.gif" Visible="false" />
              </td>
            </tr>
            <tr runat="server" id="itemPlaceholder" />
          </table>
          <asp:DataPager runat="server" ID="PeopleDataPager" PageSize="12">
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
            <td>
              <asp:Label ID="FirstNameLabel" runat="server" Text='<%#Eval("FirstName") %>' />
            </td>
            <td>
              <asp:Label ID="LastNameLabel" runat="server" Text='<%#Eval("LastName") %>' />
            </td>
            <td>
              <asp:Label ID="EmailLabel" runat="server" Text='<%#Eval("EmailAddress") %>' />
            </td>
          </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
          <tr class="alternatingItem" runat="server">
            <td>
              <asp:Label ID="FirstNameLabel" runat="server" Text='<%#Eval("FirstName") %>' />
            </td>
            <td>
              <asp:Label ID="LastNameLabel" runat="server" Text='<%#Eval("LastName") %>' />
            </td>
            <td>
              <asp:Label ID="EmailLabel" runat="server" Text='<%#Eval("EmailAddress") %>' />
            </td>
          </tr>
        </AlternatingItemTemplate>
      </asp:ListView>
      
      <!-- This example uses Microsoft SQL Server and connects    -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET  -->
      <!-- expression to retrieve the connection string value     -->
      <!-- from the Web.config file.                              -->
      <asp:SqlDataSource ID="ContactsDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        SelectCommand="SELECT [ContactID], [FirstName], [LastName], [EmailAddress] 
          FROM Person.Contact" >
      </asp:SqlDataSource>
      
    </form>
  </body>
</html>
<%-- </Snippet1> --%>