<%-- <Snippet1> --%>
<%@ Page language="VB" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Protected Sub GroupItemCountList_SelectedIndexChanged(ByVal sender As Object, _
    ByVal e As EventArgs)
          
    ' Changes the number of items displayed for each group.  
    ContactsListView.GroupItemCount = _
      Convert.ToInt32(GroupItemCountList.SelectedValue)
        
  End Sub
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>ListView GroupItemCount Example</title>
    <style type="text/css">
      body { font: 10pt Trebuchet MS; }        
    </style>
  </head>
  <body>
    <form id="form1" runat="server">
        
      <h3>ListView GroupItemCount Example</h3>

      Number of columns:
      <asp:DropDownList ID="GroupItemCountList"
        AutoPostBack="true"
        runat="server"         
        OnSelectedIndexChanged="GroupItemCountList_SelectedIndexChanged"        
        >
          <asp:ListItem>1</asp:ListItem>
          <asp:ListItem Selected="True">2</asp:ListItem>
          <asp:ListItem>3</asp:ListItem>
          <asp:ListItem>4</asp:ListItem>
      </asp:DropDownList>
      <br />
      <br />      
      <hr />
      
      <asp:ListView ID="ContactsListView" 
        DataSourceID="ContactsDataSource" 
        GroupItemCount="2"        
        runat="server">
        <LayoutTemplate>
          <table id="tblContacts" runat="server" cellspacing="0" cellpadding="2">
            <tr runat="server" id="groupPlaceholder" />
          </table>
          <asp:DataPager runat="server" ID="ContactsDataPager" PageSize="24">
            <Fields>
              <asp:NextPreviousPagerField 
                ShowFirstPageButton="true" ShowLastPageButton="true"
                FirstPageText="|&lt;&lt; " LastPageText=" &gt;&gt;|"
                NextPageText=" &gt; " PreviousPageText=" &lt; " />
            </Fields>
          </asp:DataPager>
        </LayoutTemplate>
        <ItemTemplate>
          <td align="center" style="width:10px" runat="server">
            <asp:Label ID="IDLabel" runat="Server" Text='<%#Eval("ContactID") %>' />
          </td>
          <td style="width:70px" runat="server">
            <asp:Label ID="FirstNameLabel" runat="Server" Text='<%#Eval("FirstName") %>' />
          </td>
          <td style="width:70px" runat="server">
            <asp:Label ID="LastNameLabel" runat="Server" Text='<%#Eval("LastName") %>' />
          </td>
        </ItemTemplate>
        <GroupTemplate>
          <tr runat="server" id="ContactsRow" style="background-color: #FFFFFF">
            <td runat="server" id="itemPlaceholder" />
          </tr>
        </GroupTemplate>
        <ItemSeparatorTemplate>
          <td runat="server" style="border-right: 1px solid #00C0C0">&nbsp;</td>
        </ItemSeparatorTemplate>
      </asp:ListView>

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